USE [BookExchangePlatformDB]
GO

/****** Object:  Table [dbo].[ExchangeRequest]    Script Date: 16-11-2024 11:18:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ExchangeRequest](
	[ExchangeRequestId] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL,
	[RequestId] [nvarchar](450) NOT NULL,
	[OwnerId] [nvarchar](450) NOT NULL,
	[Terms] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NOT NULL,
	[DeliveryMethod] [nvarchar](max) NOT NULL,
	[Duration] [nvarchar](max) NULL,
	[RequestDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ExchangeRequest] PRIMARY KEY CLUSTERED 
(
	[ExchangeRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ExchangeRequest]  WITH CHECK ADD  CONSTRAINT [FK_ExchangeRequest_Book_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([BookId])
GO

ALTER TABLE [dbo].[ExchangeRequest] CHECK CONSTRAINT [FK_ExchangeRequest_Book_BookId]
GO

ALTER TABLE [dbo].[ExchangeRequest]  WITH CHECK ADD  CONSTRAINT [FK_ExchangeRequest_User_OwnerId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[ExchangeRequest] CHECK CONSTRAINT [FK_ExchangeRequest_User_OwnerId]
GO

ALTER TABLE [dbo].[ExchangeRequest]  WITH CHECK ADD  CONSTRAINT [FK_ExchangeRequest_User_RequestId] FOREIGN KEY([RequestId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[ExchangeRequest] CHECK CONSTRAINT [FK_ExchangeRequest_User_RequestId]
GO


