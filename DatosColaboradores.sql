USE [master]
GO
/****** Object:  Database [DatosColaboradores]    Script Date: 6/11/2023 16:19:20 ******/
CREATE DATABASE [DatosColaboradores]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DatosColaboradores', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DatosColaboradores.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DatosColaboradores_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DatosColaboradores_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DatosColaboradores] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DatosColaboradores].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DatosColaboradores] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DatosColaboradores] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DatosColaboradores] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DatosColaboradores] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DatosColaboradores] SET ARITHABORT OFF 
GO
ALTER DATABASE [DatosColaboradores] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DatosColaboradores] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DatosColaboradores] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DatosColaboradores] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DatosColaboradores] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DatosColaboradores] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DatosColaboradores] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DatosColaboradores] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DatosColaboradores] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DatosColaboradores] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DatosColaboradores] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DatosColaboradores] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DatosColaboradores] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DatosColaboradores] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DatosColaboradores] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DatosColaboradores] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DatosColaboradores] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DatosColaboradores] SET RECOVERY FULL 
GO
ALTER DATABASE [DatosColaboradores] SET  MULTI_USER 
GO
ALTER DATABASE [DatosColaboradores] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DatosColaboradores] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DatosColaboradores] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DatosColaboradores] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DatosColaboradores] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DatosColaboradores] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DatosColaboradores', N'ON'
GO
ALTER DATABASE [DatosColaboradores] SET QUERY_STORE = ON
GO
ALTER DATABASE [DatosColaboradores] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DatosColaboradores]
GO
/****** Object:  Table [dbo].[Colaboradores]    Script Date: 6/11/2023 16:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colaboradores](
	[ColaboradorID] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NULL,
	[Apellidos] [varchar](50) NULL,
	[Genero] [char](1) NULL,
	[EstadoCivil] [varchar](20) NULL,
	[FechaNac] [date] NULL,
	[Edad] [int] NULL,
	[DPI] [varchar](20) NULL,
	[NIT] [varchar](15) NULL,
	[AfIGSS] [varchar](20) NULL,
	[AfIRTRA] [varchar](20) NULL,
	[Pasaporte] [varchar](20) NULL,
	[Telefono] [varchar](15) NULL,
	[Correo] [varchar](50) NULL,
	[Direccion] [varchar](100) NULL,
	[Ciudad] [varchar](50) NULL,
	[Pais] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ColaboradorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [DatosColaboradores] SET  READ_WRITE 
GO
