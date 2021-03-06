USE [master]
GO
/****** Object:  Database [CONSULTORIO]    Script Date: 01/06/2022 11:29:31 p. m. ******/
CREATE DATABASE [CONSULTORIO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CONSULTORIO', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SRVTSMDEV\MSSQL\DATA\CONSULTORIO.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CONSULTORIO_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SRVTSMDEV\MSSQL\DATA\CONSULTORIO_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CONSULTORIO] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CONSULTORIO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CONSULTORIO] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CONSULTORIO] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CONSULTORIO] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CONSULTORIO] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CONSULTORIO] SET ARITHABORT OFF 
GO
ALTER DATABASE [CONSULTORIO] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CONSULTORIO] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CONSULTORIO] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CONSULTORIO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CONSULTORIO] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CONSULTORIO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CONSULTORIO] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CONSULTORIO] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CONSULTORIO] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CONSULTORIO] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CONSULTORIO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CONSULTORIO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CONSULTORIO] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CONSULTORIO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CONSULTORIO] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CONSULTORIO] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CONSULTORIO] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CONSULTORIO] SET RECOVERY FULL 
GO
ALTER DATABASE [CONSULTORIO] SET  MULTI_USER 
GO
ALTER DATABASE [CONSULTORIO] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CONSULTORIO] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CONSULTORIO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CONSULTORIO] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CONSULTORIO] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CONSULTORIO] SET QUERY_STORE = OFF
GO
USE [CONSULTORIO]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [CONSULTORIO]
GO
/****** Object:  Table [dbo].[Cita]    Script Date: 01/06/2022 11:29:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cita](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_medico] [int] NULL,
	[ID_paciente] [int] NULL,
	[diaCita] [date] NULL,
	[horaCita] [time](7) NULL,
	[expediente] [varchar](100) NULL,
	[estudios] [bit] NULL,
	[observaciones] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medico]    Script Date: 01/06/2022 11:29:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medico](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[clave] [varchar](15) NULL,
	[nombre] [varchar](30) NULL,
	[apPaterno] [varchar](30) NULL,
	[apMaterno] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 01/06/2022 11:29:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paciente](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NULL,
	[apPaterno] [varchar](30) NULL,
	[apMaterno] [varchar](30) NULL,
	[fechaNacimiento] [date] NULL,
	[localidad] [varchar](100) NULL,
	[telefono] [varchar](20) NULL,
	[email] [varchar](50) NULL,
	[medio] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cita] ON 

INSERT [dbo].[Cita] ([ID], [ID_medico], [ID_paciente], [diaCita], [horaCita], [expediente], [estudios], [observaciones]) VALUES (1, 3, 2, CAST(N'2022-06-01' AS Date), CAST(N'10:30:00' AS Time), N'2_2022-06-01.pdf', 1, N'prueba')
INSERT [dbo].[Cita] ([ID], [ID_medico], [ID_paciente], [diaCita], [horaCita], [expediente], [estudios], [observaciones]) VALUES (2, 1, 4, CAST(N'2022-06-03' AS Date), CAST(N'12:30:00' AS Time), N'4_2022-06-03.pdf', 0, N'prueba')
SET IDENTITY_INSERT [dbo].[Cita] OFF
GO
SET IDENTITY_INSERT [dbo].[Medico] ON 

INSERT [dbo].[Medico] ([ID], [email], [clave], [nombre], [apPaterno], [apMaterno]) VALUES (1, N'ivette.marquez98@gmail.com', N'hola123', N'Ivette', N'Márquez', N'Rodríguez')
INSERT [dbo].[Medico] ([ID], [email], [clave], [nombre], [apPaterno], [apMaterno]) VALUES (2, N'ivette.marquez@gmail.com', N'123', N'aa', N'bb', N'cc')
INSERT [dbo].[Medico] ([ID], [email], [clave], [nombre], [apPaterno], [apMaterno]) VALUES (3, N'ivette@gmail.com', N'hola123', N'KAREN', N'MARQUEZ', N'RAMIREZ')
SET IDENTITY_INSERT [dbo].[Medico] OFF
GO
SET IDENTITY_INSERT [dbo].[Paciente] ON 

INSERT [dbo].[Paciente] ([ID], [nombre], [apPaterno], [apMaterno], [fechaNacimiento], [localidad], [telefono], [email], [medio]) VALUES (1, N'KAREN', N'MARQUEZ', N'RAMOS', CAST(N'1998-05-05' AS Date), N'AGUASCALIENTES', N'4494346300', N'ivette.marquez98@gmail.com', N'FB')
INSERT [dbo].[Paciente] ([ID], [nombre], [apPaterno], [apMaterno], [fechaNacimiento], [localidad], [telefono], [email], [medio]) VALUES (2, N'Miss', N'Lea', N'Rasmussen', CAST(N'1984-10-07' AS Date), N'Rønnede', N'66068046', N'lea.rasmussen@example.com', N'Television')
INSERT [dbo].[Paciente] ([ID], [nombre], [apPaterno], [apMaterno], [fechaNacimiento], [localidad], [telefono], [email], [medio]) VALUES (3, N'Monsieur', N'Clément', N'Lemaire', CAST(N'1991-04-05' AS Date), N'Wil (Zh)', N'079 366 31 98', N'clement.lemaire@example.com', N'Television')
INSERT [dbo].[Paciente] ([ID], [nombre], [apPaterno], [apMaterno], [fechaNacimiento], [localidad], [telefono], [email], [medio]) VALUES (4, N'Mr', N'Alessio', N'Guillot', CAST(N'1995-05-11' AS Date), N'Nanterre', N'06-16-64-63-26', N'alessio.guillot@example.com', N'Radio')
INSERT [dbo].[Paciente] ([ID], [nombre], [apPaterno], [apMaterno], [fechaNacimiento], [localidad], [telefono], [email], [medio]) VALUES (5, N'Mr', N'Charlie', N'Francois', CAST(N'1986-06-06' AS Date), N'Metz', N'06-92-61-08-84', N'charlie.francois@example.com', N'Facebook')
SET IDENTITY_INSERT [dbo].[Paciente] OFF
GO
ALTER TABLE [dbo].[Cita]  WITH CHECK ADD FOREIGN KEY([ID_medico])
REFERENCES [dbo].[Medico] ([ID])
GO
ALTER TABLE [dbo].[Cita]  WITH CHECK ADD FOREIGN KEY([ID_paciente])
REFERENCES [dbo].[Paciente] ([ID])
GO
/****** Object:  StoredProcedure [dbo].[getCita]    Script Date: 01/06/2022 11:29:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getCita]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	  SELECT cita.ID, concat(med.nombre,' ', med.apPaterno, ' ', med.apMaterno) as medico, concat(pac.nombre,' ', pac.apPaterno, ' ', pac.apMaterno) as paciente,
  cita.diaCita, cita.horaCita, cita.estudios, cita.observaciones, cita.expediente
  FROM Cita as cita
  LEFT JOIN Medico as med on med.ID = cita.ID_medico
  LEFT JOIN Paciente as pac on pac.ID = cita.ID_paciente ORDER BY cita.diaCita, cita.horaCita;
END
GO
/****** Object:  StoredProcedure [dbo].[getLogin]    Script Date: 01/06/2022 11:29:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[getLogin]
    @prEmail varchar(50),   
    @prClave varchar(15)   
AS   

    SET NOCOUNT ON;  
    select ID, email, nombre, apPaterno, apMaterno from [CONSULTORIO].[dbo].[Medico] WHERE email = @prEmail AND clave = @prClave;
GO
/****** Object:  StoredProcedure [dbo].[getMedico]    Script Date: 01/06/2022 11:29:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getMedico] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    SELECT [ID],concat ([nombre],' ', [apPaterno],' ', [apMaterno]) as NOMBRE
  FROM [CONSULTORIO].[dbo].[Medico]
END
GO
/****** Object:  StoredProcedure [dbo].[getPaciente]    Script Date: 01/06/2022 11:29:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getPaciente] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ID],concat ([nombre],' ', [apPaterno],' ', [apMaterno]) as NOMBRE
  FROM [CONSULTORIO].[dbo].[Paciente]
END
GO
/****** Object:  StoredProcedure [dbo].[getPacientes]    Script Date: 01/06/2022 11:29:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
CREATE PROCEDURE [dbo].[getPacientes]
	-- Add the parameters for the stored procedure here
AS

	SET NOCOUNT ON;
	SELECT [ID]
      ,[nombre]
      ,[apPaterno]
      ,[apMaterno]
      ,[fechaNacimiento]
      ,[localidad]
      ,[telefono]
      ,[email]
      ,[medio], DATEDIFF(year, fechaNacimiento, GETDATE()) as edad
  FROM [CONSULTORIO].[dbo].[Paciente]
GO
/****** Object:  StoredProcedure [dbo].[IUDCita]    Script Date: 01/06/2022 11:29:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[IUDCita]
	@prMedico int,
	@prPaciente int,
	@prDiaCita date,
	@prHoraCita time,
	@prExpediente varchar(100),
	@prEstudios char(1),
	@prObservaciones varchar(250)
AS
BEGIN
	
	  INSERT INTO [dbo].[Cita] (ID_medico, ID_paciente, diaCita, horaCita, expediente, estudios, observaciones) VALUES (@prMedico,@prPaciente, @prDiaCita, @prHoraCita, @prExpediente,
	  @prEstudios, @prObservaciones)
	
END

GO
/****** Object:  StoredProcedure [dbo].[IUDMedico]    Script Date: 01/06/2022 11:29:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IUDMedico]
	@Res int OUTPUT,
	@prEmail varchar (50),
	@prClave varchar (15),
	@prNombre varchar (30),
	@prApPaterno varchar (30),
	@prApMaterno varchar (30)
	
AS
BEGIN
    DECLARE @CONTEO int
	-- COMPROBAR SI YA EXISTE EL USUARIO
	SET @CONTEO = (SELECT COUNT (ID) FROM [CONSULTORIO].[dbo].[Medico] WHERE email = @prEmail);

	IF (@CONTEO = 0) 
	BEGIN 
	  INSERT INTO [dbo].[Medico] (email, clave, nombre, apPaterno, apMaterno) VALUES (@prEmail, @prClave, @prNombre, @prApPaterno, @prApMaterno)
	  SET @Res = 1;
	END
	ELSE
	BEGIN 
		SET @Res = 0;
	END

END

RETURN 
GO
/****** Object:  StoredProcedure [dbo].[IUDPaciente]    Script Date: 01/06/2022 11:29:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[IUDPaciente]
	@Res int OUTPUT,
	@prNombre varchar (50),
	@prApPaterno varchar (30),
	@prApMaterno varchar (30),
	@prFechaNacimiento date,
	@prLocalidad varchar(100),
	@prTelefono varchar(20),
	@prEmail varchar(50),
	@prMedio varchar(30)
AS
BEGIN
	DECLARE @CONTEO int
	-- COMPROBAR SI YA EXISTE EL USUARIO
	SET @CONTEO = (SELECT COUNT (ID) FROM [CONSULTORIO].[dbo].[Paciente] WHERE email = @prEmail);

	IF (@CONTEO = 0) 
	BEGIN 
	  INSERT INTO [dbo].[Paciente] (nombre, apPaterno, apMaterno, fechaNacimiento, localidad, telefono, email, medio) VALUES (@prNombre,@prApPaterno, @prApMaterno, @prFechaNacimiento, @prLocalidad,
	  @prTelefono, @prEmail, @prMedio)
	  SET @Res = 1;
	END
	ELSE
	BEGIN 
		SET @Res = 0;
	END

END

RETURN 
GO
USE [master]
GO
ALTER DATABASE [CONSULTORIO] SET  READ_WRITE 
GO
