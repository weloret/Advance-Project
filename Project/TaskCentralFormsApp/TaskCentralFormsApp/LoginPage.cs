using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskCentralClassLibrary;
using TaskCentralClassLibrary.Identity;

namespace TaskCentralFormsApp
{
    public partial class LoginPage : Form
    {
        private IServiceProvider serviceProvider;


        IdentityContext IdentityContext = new IdentityContext();
        TaskCentralDBContext context = new TaskCentralDBContext(Global.loggedUser);
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var signInResults = await VerifyEmailPassword(inputEmail.Text, InputPassword.Text);
            if (signInResults == true)
            {




                ProjectListPage projectList = new ProjectListPage();
                this.Hide();
                projectList.Show();
            }
            else
            {
                MessageBox.Show("Error. The email or password are not correct");
            }
        }
        public async Task<bool> VerifyEmailPassword(string email, string password)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();

            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var founduser = await userManager.FindByEmailAsync(email);

            if (founduser != null)
            {
                var passCheck = await userManager.CheckPasswordAsync(founduser, password) == true;

                if (passCheck)
                {
                    User loggedUser = new User();
                    loggedUser = context.Users.Where(x => x.AspUserId == founduser.Id).FirstOrDefault();
                    //save into global class
                    Global.loggedUser = loggedUser;
                }
                return passCheck;
            }
            return false;
        }

        private void ConfigureServices(IServiceCollection services)
        {

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<IdentityContext>();
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<TaskCentralDBContext>();

            // Register UserManager & RoleManager
            services.AddIdentity<IdentityUser, IdentityRole>()
               .AddEntityFrameworkStores<IdentityContext>()
               .AddDefaultTokenProviders();

            // UserManager & RoleManager require logging and HttpContext dependencies
            services.AddLogging();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
