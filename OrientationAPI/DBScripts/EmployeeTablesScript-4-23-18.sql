USE [BRBangazon]
GO
/****** Object:  Table [dbo].[Computers]    Script Date: 4/23/2018 8:15:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Computers](
	[ComputerId] [int] IDENTITY(1,1) NOT NULL,
	[Manufacturer] [varchar](50) NOT NULL,
	[Make] [varchar](50) NOT NULL,
	[PurchaseDate] [date] NOT NULL,
 CONSTRAINT [PK_Computers] PRIMARY KEY CLUSTERED 
(
	[ComputerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 4/23/2018 8:15:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee_Computers]    Script Date: 4/23/2018 8:15:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee_Computers](
	[EmployeeComputerId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[ComputerId] [int] NOT NULL,
	[AssignedDate] [date] NOT NULL,
	[ReturnedDate] [date] NULL,
 CONSTRAINT [PK_Employee_Computers] PRIMARY KEY CLUSTERED 
(
	[EmployeeComputerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee_Training]    Script Date: 4/23/2018 8:15:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee_Training](
	[EmployeeTrainingId] [int] IDENTITY(1,1) NOT NULL,
	[TrainingProgramId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_Employee_Training] PRIMARY KEY CLUSTERED 
(
	[EmployeeTrainingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 4/23/2018 8:15:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[EmployeeStartDate] [date] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrainingPrograms]    Script Date: 4/23/2018 8:15:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrainingPrograms](
	[ProgramId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[MaxAttendees] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_TrainingPrograms] PRIMARY KEY CLUSTERED 
(
	[ProgramId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee_Computers]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Computers_Computers] FOREIGN KEY([ComputerId])
REFERENCES [dbo].[Computers] ([ComputerId])
GO
ALTER TABLE [dbo].[Employee_Computers] CHECK CONSTRAINT [FK_Employee_Computers_Computers]
GO
ALTER TABLE [dbo].[Employee_Computers]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Computers_Employee_Computers] FOREIGN KEY([EmployeeComputerId])
REFERENCES [dbo].[Employee_Computers] ([EmployeeComputerId])
GO
ALTER TABLE [dbo].[Employee_Computers] CHECK CONSTRAINT [FK_Employee_Computers_Employee_Computers]
GO
ALTER TABLE [dbo].[Employee_Training]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Training_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Employee_Training] CHECK CONSTRAINT [FK_Employee_Training_Employees]
GO
ALTER TABLE [dbo].[Employee_Training]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Training_TrainingPrograms] FOREIGN KEY([TrainingProgramId])
REFERENCES [dbo].[TrainingPrograms] ([ProgramId])
GO
ALTER TABLE [dbo].[Employee_Training] CHECK CONSTRAINT [FK_Employee_Training_TrainingPrograms]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Employees] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Employees]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Employees1] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Employees1]
GO
