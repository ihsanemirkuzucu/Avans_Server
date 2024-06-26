CREATE DATABASE [Advance]
GO	
USE [Advance]
GO
/****** Object:  Table [dbo].[Advance]    Script Date: 19.12.2023 16:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advance](
	[AdvanceID] [int] IDENTITY(1,1) NOT NULL,
	[TitleAmountApprovalRuleID] [int] NULL,
	[AdvanceAmount] [decimal](18, 0) NULL,
	[AdvanceExplanation] [nvarchar](max) NULL,
	[WorkerID] [int] NULL,
	[RequestDate] [datetime] NULL,
	[DesiredDate] [datetime] NULL,
	[isApproved] [bit] NULL,
	[ProjectID] [int] NULL,
 CONSTRAINT [PK_Advance] PRIMARY KEY CLUSTERED 
(
	[AdvanceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdvanceApproveStatus]    Script Date: 19.12.2023 16:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdvanceApproveStatus](
	[ApproveStatusID] [int] IDENTITY(1,1) NOT NULL,
	[AdvanceID] [int] NULL,
	[ApproverOrRejecterID] [int] NULL,
	[ApprovalStatusID] [int] NULL,
	[Approved/DeclinedDate] [datetime] NULL,
	[ApprovedAmount] [decimal](18, 0) NULL,
	[IsReview] [bit] NULL,
	[NextApproverID] [int] NULL,
	[DeterminedAdvanceDate] [datetime] NULL,
	[PaymentDate] [datetime] NULL,
 CONSTRAINT [PK_AdvanceApproveStatus] PRIMARY KEY CLUSTERED 
(
	[ApproveStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdvanceReceipt]    Script Date: 19.12.2023 16:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdvanceReceipt](
	[AdvanceID] [int] NOT NULL,
	[PaybackReceiptID] [int] NULL,
	[PaymantReceiptID] [int] NULL,
	[PaybackDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Amount]    Script Date: 19.12.2023 16:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amount](
	[AmountID] [int] IDENTITY(1,1) NOT NULL,
	[MinAmount] [decimal](18, 0) NULL,
	[MaxAmount] [decimal](18, 0) NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_Amount] PRIMARY KEY CLUSTERED 
(
	[AmountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApprovalStatus]    Script Date: 19.12.2023 16:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApprovalStatus](
	[ApprovalStatusID] [int] IDENTITY(1,1) NOT NULL,
	[ApprovalName] [nvarchar](50) NULL,
	[NextApprovalStatusID] [int] NULL,
	[NextApprovalName] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK_ApprovalStatus] PRIMARY KEY CLUSTERED 
(
	[ApprovalStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authorization]    Script Date: 19.12.2023 16:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authorization](
	[AuthorizationID] [int] IDENTITY(1,1) NOT NULL,
	[AutherizationPath] [nvarchar](250) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Authorization] PRIMARY KEY CLUSTERED 
(
	[AuthorizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 19.12.2023 16:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[MessageName] [nvarchar](100) NULL,
	[MessageDescription] [nvarchar](max) NULL,
	[MessageTakerID] [int] NULL,
	[MessageSenderID] [int] NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PageAuthorization]    Script Date: 19.12.2023 16:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PageAuthorization](
	[PageAuthorizationID] [int] IDENTITY(1,1) NOT NULL,
	[PageAuthrizationName] [nvarchar](50) NULL,
	[PageAuthorizationPath] [nvarchar](max) NULL,
	[IsActive] [nchar](10) NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK_PageAuthorization] PRIMARY KEY CLUSTERED 
(
	[PageAuthorizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaybackReceipt]    Script Date: 19.12.2023 16:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaybackReceipt](
	[PaybackReceiptID] [int] IDENTITY(1,1) NOT NULL,
	[ReceiptDate] [datetime] NULL,
	[ReceiptDescription] [nvarchar](50) NULL,
	[IsActive] [nchar](10) NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK_PaybackReceipt] PRIMARY KEY CLUSTERED 
(
	[PaybackReceiptID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentReceipt]    Script Date: 19.12.2023 16:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentReceipt](
	[PaymentReceiptID] [int] IDENTITY(1,1) NOT NULL,
	[ReceiptDate] [datetime] NULL,
	[ReceiptDescription] [nvarchar](50) NULL,
	[DeterminedPaybackDate] [datetime] NULL,
	[IsActive] [nchar](10) NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK_PaymentReceipt] PRIMARY KEY CLUSTERED 
(
	[PaymentReceiptID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 19.12.2023 16:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](50) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[ProjectExplanation] [nvarchar](max) NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectWorker]    Script Date: 19.12.2023 16:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectWorker](
	[WorkerID] [int] NULL,
	[ProjectID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report]    Script Date: 19.12.2023 16:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[ReportID] [int] IDENTITY(1,1) NOT NULL,
	[WorkerID] [int] NULL,
	[AdvanceID] [int] NULL,
	[IsActive] [nchar](10) NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[ReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 19.12.2023 16:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleAuthorization]    Script Date: 19.12.2023 16:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleAuthorization](
	[RoleID] [int] NOT NULL,
	[AuthorizationID] [int] NOT NULL,
	[PageAuthorizationID] [int] NOT NULL,
	[IsActive] [nchar](10) NOT NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rule]    Script Date: 19.12.2023 16:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rule](
	[RuleID] [int] IDENTITY(1,1) NOT NULL,
	[RuleName] [nvarchar](50) NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_Rule] PRIMARY KEY CLUSTERED 
(
	[RuleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RuleWorker]    Script Date: 19.12.2023 16:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RuleWorker](
	[RuleID] [int] NULL,
	[TitleID] [int] NULL,
	[ApprovalOrder] [tinyint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Title]    Script Date: 19.12.2023 16:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Title](
	[TitleID] [int] IDENTITY(1,1) NOT NULL,
	[TitleName] [nvarchar](50) NULL,
	[TitleDescription] [nvarchar](max) NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_Title] PRIMARY KEY CLUSTERED 
(
	[TitleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TitleAmountApprovalRule]    Script Date: 19.12.2023 16:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TitleAmountApprovalRule](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AmountID] [int] NULL,
	[Date] [datetime] NULL,
	[TitleID] [int] NULL,
 CONSTRAINT [PK_TitleAmountApprovalRule] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 19.12.2023 16:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[UnitID] [int] IDENTITY(1,1) NOT NULL,
	[UnitName] [nvarchar](50) NULL,
	[UnitExplanation] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[UnitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Worker]    Script Date: 19.12.2023 16:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Worker](
	[WorkerID] [int] IDENTITY(1,1) NOT NULL,
	[WorkerName] [nvarchar](50) NULL,
	[WorkerEmail] [nvarchar](50) NULL,
	[WorkerPhonenumber] [nvarchar](50) NULL,
	[UnitID] [int] NULL,
	[TitleID] [int] NULL,
	[UpperWorkerID] [int] NULL,
	[PasswordSalt] [varbinary](max) NULL,
	[PasswordHash] [varbinary](max) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Worker] PRIMARY KEY CLUSTERED 
(
	[WorkerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Advance] ADD  CONSTRAINT [DF_Advance_RequestDate]  DEFAULT (getdate()) FOR [RequestDate]
GO
ALTER TABLE [dbo].[Advance] ADD  CONSTRAINT [DF_Advance_isApproved]  DEFAULT ((0)) FOR [isApproved]
GO
ALTER TABLE [dbo].[AdvanceApproveStatus] ADD  CONSTRAINT [DF_AdvanceApproveStatus_IsReview]  DEFAULT ((0)) FOR [IsReview]
GO
ALTER TABLE [dbo].[ApprovalStatus] ADD  CONSTRAINT [DF_ApprovalStatus_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[ApprovalStatus] ADD  CONSTRAINT [DF_ApprovalStatus_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[Authorization] ADD  CONSTRAINT [DF_Authorization_CreatedDate_1]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Authorization] ADD  CONSTRAINT [DF_Authorization_IsActive_1]  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[PageAuthorization] ADD  CONSTRAINT [DF_PageAuthorization_CreatedDate_1]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[PageAuthorization] ADD  CONSTRAINT [DF_PageAuthorization_ModifiedDate_1]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[PaybackReceipt] ADD  CONSTRAINT [DF_PaybackReceipt_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[PaybackReceipt] ADD  CONSTRAINT [DF_PaybackReceipt_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[PaymentReceipt] ADD  CONSTRAINT [DF_PaymentReceipt_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[PaymentReceipt] ADD  CONSTRAINT [DF_PaymentReceipt_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[Report] ADD  CONSTRAINT [DF_Report_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Report] ADD  CONSTRAINT [DF_Report_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_CreatedDate_1]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_ModifiedDate_1]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[RoleAuthorization] ADD  CONSTRAINT [DF_RoleAuthorization_CreatedDate_1]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[RoleAuthorization] ADD  CONSTRAINT [DF_RoleAuthorization_ModifiedDate_1]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[Worker] ADD  CONSTRAINT [DF_Worker_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Advance]  WITH CHECK ADD  CONSTRAINT [FK_Advance_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[Advance] CHECK CONSTRAINT [FK_Advance_Project]
GO
ALTER TABLE [dbo].[Advance]  WITH CHECK ADD  CONSTRAINT [FK_Advance_TitleAmountApprovalRule] FOREIGN KEY([TitleAmountApprovalRuleID])
REFERENCES [dbo].[TitleAmountApprovalRule] ([ID])
GO
ALTER TABLE [dbo].[Advance] CHECK CONSTRAINT [FK_Advance_TitleAmountApprovalRule]
GO
ALTER TABLE [dbo].[Advance]  WITH CHECK ADD  CONSTRAINT [FK_Advance_Worker] FOREIGN KEY([WorkerID])
REFERENCES [dbo].[Worker] ([WorkerID])
GO
ALTER TABLE [dbo].[Advance] CHECK CONSTRAINT [FK_Advance_Worker]
GO
ALTER TABLE [dbo].[AdvanceApproveStatus]  WITH CHECK ADD  CONSTRAINT [FK_AdvanceApproveStatus_Advance] FOREIGN KEY([AdvanceID])
REFERENCES [dbo].[Advance] ([AdvanceID])
GO
ALTER TABLE [dbo].[AdvanceApproveStatus] CHECK CONSTRAINT [FK_AdvanceApproveStatus_Advance]
GO
ALTER TABLE [dbo].[AdvanceApproveStatus]  WITH CHECK ADD  CONSTRAINT [FK_AdvanceApproveStatus_ApprovalStatus] FOREIGN KEY([ApprovalStatusID])
REFERENCES [dbo].[ApprovalStatus] ([ApprovalStatusID])
GO
ALTER TABLE [dbo].[AdvanceApproveStatus] CHECK CONSTRAINT [FK_AdvanceApproveStatus_ApprovalStatus]
GO
ALTER TABLE [dbo].[AdvanceApproveStatus]  WITH CHECK ADD  CONSTRAINT [FK_AdvanceApproveStatus_Worker] FOREIGN KEY([ApproverOrRejecterID])
REFERENCES [dbo].[Worker] ([WorkerID])
GO
ALTER TABLE [dbo].[AdvanceApproveStatus] CHECK CONSTRAINT [FK_AdvanceApproveStatus_Worker]
GO
ALTER TABLE [dbo].[AdvanceApproveStatus]  WITH CHECK ADD  CONSTRAINT [FK_AdvanceApproveStatus_Worker1] FOREIGN KEY([NextApproverID])
REFERENCES [dbo].[Worker] ([WorkerID])
GO
ALTER TABLE [dbo].[AdvanceApproveStatus] CHECK CONSTRAINT [FK_AdvanceApproveStatus_Worker1]
GO
ALTER TABLE [dbo].[AdvanceReceipt]  WITH CHECK ADD  CONSTRAINT [FK_AdvanceReceipt_Advance] FOREIGN KEY([AdvanceID])
REFERENCES [dbo].[Advance] ([AdvanceID])
GO
ALTER TABLE [dbo].[AdvanceReceipt] CHECK CONSTRAINT [FK_AdvanceReceipt_Advance]
GO
ALTER TABLE [dbo].[AdvanceReceipt]  WITH CHECK ADD  CONSTRAINT [FK_AdvanceReceipt_PaybackReceipt] FOREIGN KEY([PaybackReceiptID])
REFERENCES [dbo].[PaybackReceipt] ([PaybackReceiptID])
GO
ALTER TABLE [dbo].[AdvanceReceipt] CHECK CONSTRAINT [FK_AdvanceReceipt_PaybackReceipt]
GO
ALTER TABLE [dbo].[AdvanceReceipt]  WITH CHECK ADD  CONSTRAINT [FK_AdvanceReceipt_PaymentReceipt] FOREIGN KEY([PaymantReceiptID])
REFERENCES [dbo].[PaymentReceipt] ([PaymentReceiptID])
GO
ALTER TABLE [dbo].[AdvanceReceipt] CHECK CONSTRAINT [FK_AdvanceReceipt_PaymentReceipt]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_Worker] FOREIGN KEY([MessageTakerID])
REFERENCES [dbo].[Worker] ([WorkerID])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_Worker]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_Worker1] FOREIGN KEY([MessageSenderID])
REFERENCES [dbo].[Worker] ([WorkerID])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_Worker1]
GO
ALTER TABLE [dbo].[ProjectWorker]  WITH CHECK ADD  CONSTRAINT [FK_ProjectWorker_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectWorker] CHECK CONSTRAINT [FK_ProjectWorker_Project]
GO
ALTER TABLE [dbo].[ProjectWorker]  WITH CHECK ADD  CONSTRAINT [FK_ProjectWorker_Worker] FOREIGN KEY([WorkerID])
REFERENCES [dbo].[Worker] ([WorkerID])
GO
ALTER TABLE [dbo].[ProjectWorker] CHECK CONSTRAINT [FK_ProjectWorker_Worker]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_Advance] FOREIGN KEY([AdvanceID])
REFERENCES [dbo].[Advance] ([AdvanceID])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_Advance]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_Worker] FOREIGN KEY([WorkerID])
REFERENCES [dbo].[Worker] ([WorkerID])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_Worker]
GO
ALTER TABLE [dbo].[RoleAuthorization]  WITH CHECK ADD  CONSTRAINT [FK_RoleAuthorization_Authorization] FOREIGN KEY([AuthorizationID])
REFERENCES [dbo].[Authorization] ([AuthorizationID])
GO
ALTER TABLE [dbo].[RoleAuthorization] CHECK CONSTRAINT [FK_RoleAuthorization_Authorization]
GO
ALTER TABLE [dbo].[RoleAuthorization]  WITH CHECK ADD  CONSTRAINT [FK_RoleAuthorization_PageAuthorization] FOREIGN KEY([PageAuthorizationID])
REFERENCES [dbo].[PageAuthorization] ([PageAuthorizationID])
GO
ALTER TABLE [dbo].[RoleAuthorization] CHECK CONSTRAINT [FK_RoleAuthorization_PageAuthorization]
GO
ALTER TABLE [dbo].[RoleAuthorization]  WITH CHECK ADD  CONSTRAINT [FK_RoleAuthorization_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[RoleAuthorization] CHECK CONSTRAINT [FK_RoleAuthorization_Role]
GO
ALTER TABLE [dbo].[RuleWorker]  WITH CHECK ADD  CONSTRAINT [FK_RuleWorker_Rule] FOREIGN KEY([RuleID])
REFERENCES [dbo].[Rule] ([RuleID])
GO
ALTER TABLE [dbo].[RuleWorker] CHECK CONSTRAINT [FK_RuleWorker_Rule]
GO
ALTER TABLE [dbo].[RuleWorker]  WITH CHECK ADD  CONSTRAINT [FK_RuleWorker_Title] FOREIGN KEY([TitleID])
REFERENCES [dbo].[Title] ([TitleID])
GO
ALTER TABLE [dbo].[RuleWorker] CHECK CONSTRAINT [FK_RuleWorker_Title]
GO
ALTER TABLE [dbo].[Title]  WITH CHECK ADD  CONSTRAINT [FK_Title_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[Title] CHECK CONSTRAINT [FK_Title_Role]
GO
ALTER TABLE [dbo].[TitleAmountApprovalRule]  WITH CHECK ADD  CONSTRAINT [FK_TitleAmountApprovalRule_Amount] FOREIGN KEY([AmountID])
REFERENCES [dbo].[Amount] ([AmountID])
GO
ALTER TABLE [dbo].[TitleAmountApprovalRule] CHECK CONSTRAINT [FK_TitleAmountApprovalRule_Amount]
GO
ALTER TABLE [dbo].[TitleAmountApprovalRule]  WITH CHECK ADD  CONSTRAINT [FK_TitleAmountApprovalRule_Title] FOREIGN KEY([TitleID])
REFERENCES [dbo].[Title] ([TitleID])
GO
ALTER TABLE [dbo].[TitleAmountApprovalRule] CHECK CONSTRAINT [FK_TitleAmountApprovalRule_Title]
GO
ALTER TABLE [dbo].[Worker]  WITH CHECK ADD  CONSTRAINT [FK_Worker_Title] FOREIGN KEY([TitleID])
REFERENCES [dbo].[Title] ([TitleID])
GO
ALTER TABLE [dbo].[Worker] CHECK CONSTRAINT [FK_Worker_Title]
GO
ALTER TABLE [dbo].[Worker]  WITH CHECK ADD  CONSTRAINT [FK_Worker_Unit] FOREIGN KEY([UnitID])
REFERENCES [dbo].[Unit] ([UnitID])
GO
ALTER TABLE [dbo].[Worker] CHECK CONSTRAINT [FK_Worker_Unit]
GO
ALTER TABLE [dbo].[Worker]  WITH CHECK ADD  CONSTRAINT [FK_Worker_Worker] FOREIGN KEY([UpperWorkerID])
REFERENCES [dbo].[Worker] ([WorkerID])
GO
ALTER TABLE [dbo].[Worker] CHECK CONSTRAINT [FK_Worker_Worker]
GO
/****** Object:  StoredProcedure [dbo].[SP_GETADVANCEDETAILSBYADVANCEID]    Script Date: 19.12.2023 16:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GETADVANCEDETAILSBYADVANCEID]
    @ADVANCEID INT
AS
BEGIN
    SELECT TOP 1 A.AdvanceID, A.AdvanceAmount, A.RequestDate, A.DesiredDate, P.ProjectName, AAS.ApprovalName, APS.[Approved/DeclinedDate] AS ApprovedDeclinedDate,
    WW.WorkerName AS ApprovalRejectedName, T.TitleName AS ApprovalRejectedTitle, APS.ApprovedAmount, PAYM.DeterminedPaybackDate
    FROM Advance A
    LEFT JOIN Worker W ON W.WorkerID = A.WorkerID
    INNER JOIN Project P ON P.ProjectID = A.ProjectID
    INNER JOIN AdvanceApproveStatus APS ON APS.AdvanceID = A.AdvanceID
    INNER JOIN ApprovalStatus AAS ON AAS.ApprovalStatusID = APS.ApprovalStatusID
	INNER JOIN TitleAmountApprovalRule TAR ON TAR.ID = A.TitleAmountApprovalRuleID
    LEFT JOIN Worker ww ON WW.WorkerID = APS.ApproverOrRejecterID    
    LEFT JOIN Title T ON T.TitleID = WW.TitleID
    LEFT JOIN AdvanceReceipt AR ON AR.AdvanceID = A.AdvanceID
    LEFT JOIN PaybackReceipt PAYB ON PAYB.PaybackReceiptID = AR.PaybackReceiptID
    LEFT JOIN PaymentReceipt PAYM ON PAYM.PaymentReceiptID = AR.PaymantReceiptID
    WHERE A.AdvanceID = @ADVANCEID
    ORDER BY APS.ApproveStatusID DESC
END
GO
