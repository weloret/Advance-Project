using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using TaskCentralWebApp.Areas.Identity.Data;

namespace TaskCentralWebApp.Models
{
    public partial class TaskCentralDBContext : DbContext
    {
        private readonly UserManager<Users> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TaskCentralDBContext()
        {
        }

        public TaskCentralDBContext(DbContextOptions<TaskCentralDBContext> options, UserManager<Users> userManager, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Document> Documents { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectMember> ProjectMembers { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProjectDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Task");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_User");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_Task");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_User");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Log_User");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notification_Task");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notification_User");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_User");
            });

            modelBuilder.Entity<ProjectMember>(entity =>
            {
                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectMembers)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectMember_Project");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProjectMembers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectMember_User");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_Project");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var modifiedEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                .ToList();

            foreach (var entityEntry in modifiedEntities)
            {
                string entityName = entityEntry.Entity.GetType().Name;
                string actionType = entityEntry.State.ToString();
                DateTime dateTime = DateTime.Now;

                // Get the current logged-in user's ID (replace with your authentication logic)
                var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

                int? userId;
                if (currentUser != null)
                {
                    userId = Users.Where(u => u.AspUserId == currentUser.Id).Select(u => u.UserId).FirstOrDefault();
                }
                else
                {
                    userId = null;
                }
                var log = new Log
                {
                    Source = "Web", // Or "Form" if you want to differentiate between web and form actions
                    Type = "Action", // Or "Exception" for exceptions
                    DateTime = dateTime,
                    UserId = userId,
                    Message = GetLogMessage(entityEntry),
                    OriginalValue = GetOriginalValues(entityEntry),
                    CurrentValue = GetCurrentValues(entityEntry)
                };

                Logs.Add(log);
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
        private string GetLogMessage(EntityEntry entityEntry)
        {
            // Customize the log message based on your requirements
            string entityName = entityEntry.Entity.GetType().Name;
            string actionType = entityEntry.State.ToString();
            return $"{actionType} {entityName}";
        }

        private string GetOriginalValues(EntityEntry entityEntry)
        {
            // Serialize the original values if needed, or return null
            return JsonConvert.SerializeObject(entityEntry.OriginalValues.ToObject());
            //return null;
        }

        private string GetCurrentValues(EntityEntry entityEntry)
        {
            // Serialize the current values if needed, or return null
            return JsonConvert.SerializeObject(entityEntry.CurrentValues.ToObject());
            //return null;
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
