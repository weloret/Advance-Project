SET NOCOUNT ON
GO

set nocount    on
set dateformat mdy

USE master

declare @dttm varchar(55)
select  @dttm=convert(varchar,getdate(),113)
raiserror('Beginning authDB.SQL at %s ....',1,1,@dttm) with nowait

GO

if exists (select * from sysdatabases where name='aspDB')
begin
  raiserror('Dropping existing aspDB database ....',0,1)
  DROP database aspDB 
end
GO

CHECKPOINT
go

raiserror('Creating aspDB database....',0,1)
go
/*
   Use default size with autogrow
*/

CREATE DATABASE aspDB 
GO

CHECKPOINT

GO
ALTER DATABASE [aspDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [aspDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [aspDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [aspDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [aspDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [aspDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [aspDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [aspDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [aspDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [aspDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [aspDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [aspDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [aspDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [aspDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [aspDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [aspDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [aspDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [aspDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [aspDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [aspDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [aspDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [aspDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [aspDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [aspDB] SET  MULTI_USER 
GO
ALTER DATABASE [aspDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [aspDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [aspDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [aspDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [aspDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [aspDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [aspDB] SET QUERY_STORE = OFF
GO
USE [aspDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/4/2023 10:17:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 6/4/2023 10:17:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 6/4/2023 10:17:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 6/4/2023 10:17:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 6/4/2023 10:17:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 6/4/2023 10:17:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 6/4/2023 10:17:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 6/4/2023 10:17:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'078121b6-a3f5-45a8-bdbf-8357c13ddd7f', N'Admin', N'ADMIN', N'8bad11be-62d3-47c5-a412-d6fe6d4688a4')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'bc2ad8e6-5dfc-4b2a-9552-cab273da5245', N'User', N'USER', N'160f3ad3-fbc7-43dd-b901-ea4bce94811c')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e926f9f8-5af4-4539-ac64-bf0bfcdbc545', N'078121b6-a3f5-45a8-bdbf-8357c13ddd7f')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'55c85820-aa6f-4a23-861a-ed9a11fdceac', N'bc2ad8e6-5dfc-4b2a-9552-cab273da5245')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5b80c8d0-bcaa-4cbd-ab3a-9f2c75cc85c2', N'bc2ad8e6-5dfc-4b2a-9552-cab273da5245')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c929131e-bbea-4f61-ade7-57c49a2c5ee6', N'bc2ad8e6-5dfc-4b2a-9552-cab273da5245')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [Name]) VALUES (N'55c85820-aa6f-4a23-861a-ed9a11fdceac', N'user1@test.com', N'USER1@TEST.COM', N'user1@test.com', N'USER1@TEST.COM', 1, N'AQAAAAEAACcQAAAAEL2JH7kuKNWBg27Xw1T6Ye6iWzRgqu+6G9Beya8RSNFexGhf45c2t0fQiLXsVAYHWw==', N'KL5IUSCSGJU5WNMOO6XPB2RMI6RDHWD4', N'620272c6-ec64-49bc-82a4-5ee3295a5cc1', NULL, 1, 0, NULL, 1, 0, N'', NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [Name]) VALUES (N'5b80c8d0-bcaa-4cbd-ab3a-9f2c75cc85c2', N'user2@test.com', N'USER2@TEST.COM', N'user2@test.com', N'USER2@TEST.COM', 1, N'AQAAAAEAACcQAAAAEB4oYU7brljHviIhBdNBAfP3MuBvJ4eNAjsSInxd+ypb9yvWAood0FPa7XzuBAJJhw==', N'I376YAEXDDZT55STKXZXCJDQLD5OQVKJ', N'0329924e-c5d5-4fc0-b66d-fb26e6be10f2', NULL, 1, 0, NULL, 1, 0, N'', NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [Name]) VALUES (N'c929131e-bbea-4f61-ade7-57c49a2c5ee6', N'user3@test.com', N'USER3@TEST.COM', N'user3@test.com', N'USER3@TEST.COM', 1, N'AQAAAAEAACcQAAAAEDzFL9PqPJgpN1NbVf7hwbbd4gfZSDDjKs5V+jSji9KSqTNBYGbzv0DFkvwzbPhGZg==', N'U2442RGSBX6LCSP7LJ4QGOWV6E6TMINT', N'9603f65a-6817-4368-898e-da821f7327b9', NULL, 1, 0, NULL, 1, 0, N'', NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [Name]) VALUES (N'e926f9f8-5af4-4539-ac64-bf0bfcdbc545', N'admin@test.com', N'ADMIN@TEST.COM', N'admin@test.com', N'ADMIN@TEST.COM', 1, N'AQAAAAEAACcQAAAAENb1syQJgPkLfHq9B7BlMCFoqBzBavOV5V5gHc4as52LhaYaci85s2dAlyCSXyQfGQ==', N'3DHPS4CU5ZCAMMIXAXJCBWUDW626CYG2', N'bbc24064-f96c-43ba-b7c1-89ec5901a125', NULL, 1, 0, NULL, 1, 0, N'', NULL)
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (N'') FOR [Discriminator]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
