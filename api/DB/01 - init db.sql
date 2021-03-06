/****** Object:  Table [dbo].[Postcards]    Script Date: 9/13/2021 23:59:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Postcards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SenderId] [int] NOT NULL,
	[RecipientId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[IsSent] [bit] NOT NULL,
	[IsReceived] [bit] NOT NULL,
 CONSTRAINT [PK_Postcards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/13/2021 23:59:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UniqueId] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_Users] UNIQUE NONCLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Postcards] ADD  CONSTRAINT [DF_Postcards_IsSent]  DEFAULT ((0)) FOR [IsSent]
GO
ALTER TABLE [dbo].[Postcards] ADD  CONSTRAINT [DF_Postcards_IsReceived]  DEFAULT ((0)) FOR [IsReceived]
GO
ALTER TABLE [dbo].[Postcards]  WITH CHECK ADD  CONSTRAINT [FK_Postcards_Recipients] FOREIGN KEY([RecipientId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Postcards] CHECK CONSTRAINT [FK_Postcards_Recipients]
GO
ALTER TABLE [dbo].[Postcards]  WITH CHECK ADD  CONSTRAINT [FK_Postcards_Senders] FOREIGN KEY([SenderId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Postcards] CHECK CONSTRAINT [FK_Postcards_Senders]
GO
