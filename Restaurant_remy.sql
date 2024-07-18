CREATE DATABASE [Restaurant_Remy-Restaurant]
GO
USE [Restaurant_Remy-Restaurant]
GO
/****** Object:  Table [dbo].[AddressTypeTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddressTypeTable](
	[AddressTypeID] [int] IDENTITY(1,1) NOT NULL,
	[AddressType] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_AddressTypeTable] PRIMARY KEY CLUSTERED 
(
	[AddressTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiscountTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiscountTable](
	[DiscountID] [int] IDENTITY(1,1) NOT NULL,
	[DiscountCode] [varchar](50) NOT NULL,
	[DiscountPercentage] [float] NOT NULL,
	[IsUserStatus] [bit] NOT NULL,
 CONSTRAINT [PK_DiscountTable] PRIMARY KEY CLUSTERED 
(
	[DiscountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GenderTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenderTable](
	[GenderID] [int] IDENTITY(1,1) NOT NULL,
	[GenderTitle] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_GenderTable] PRIMARY KEY CLUSTERED 
(
	[GenderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDealDetailTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDealDetailTable](
	[OrderDealDetailID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[StockDealID] [int] NOT NULL,
	[Quality] [int] NOT NULL,
	[DealPrice] [float] NOT NULL,
 CONSTRAINT [PK_OrderDealDetailTable] PRIMARY KEY CLUSTERED 
(
	[OrderDealDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItemDetailTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItemDetailTable](
	[OrderItemDetailID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[StockItemID] [int] NOT NULL,
	[Quality] [int] NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[DiscountID] [int] NOT NULL,
	[DiscountAmount] [nchar](10) NOT NULL,
 CONSTRAINT [PK_OrderItemDetailTable] PRIMARY KEY CLUSTERED 
(
	[OrderItemDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[OrderStatusTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatusTable](
	[OrderStatusID] [int] IDENTITY(1,1) NOT NULL,
	[OrderStatus] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_OrderStatusTable] PRIMARY KEY CLUSTERED 
(
	[OrderStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderTable](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderBy_UserID] [int] NOT NULL,
	[OrderDateTime] [datetime] NOT NULL,
	[OrderTypeID] [int] NOT NULL,
	[DeliveryAddress_UserAddressID] [int] NOT NULL,
	[DeliveryReceivedBy_ContactNO] [varchar](20) NOT NULL,
	[OrderReceivedBy_FullName] [nvarchar](250) NOT NULL,
	[OrderStatusID] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ProcessBy_UserID] [int] NOT NULL,
 CONSTRAINT [PK_OrderTable] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderTypeTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderTypeTable](
	[OrderTypeID] [int] IDENTITY(1,1) NOT NULL,
	[OrderType] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_OrderTypeTable] PRIMARY KEY CLUSTERED 
(
	[OrderTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservationStatusTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservationStatusTable](
	[ReservationStatusID] [int] IDENTITY(1,1) NOT NULL,
	[ReservationStatus] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_ReservationStatusTable] PRIMARY KEY CLUSTERED 
(
	[ReservationStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockDealDetailTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockDealDetailTable](
	[StockDealDetailID] [int] IDENTITY(1,1) NOT NULL,
	[StockDealID] [int] NOT NULL,
	[StockItemID] [int] NOT NULL,
	[Discount] [float] NOT NULL,
	[VisibleStatusID] [int] NOT NULL,
	[CreatedBy_UserID] [int] NOT NULL,
 CONSTRAINT [PK_DealDetailTable] PRIMARY KEY CLUSTERED 
(
	[StockDealDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockDealTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockDealTable](
	[StockDealID] [int] IDENTITY(1,1) NOT NULL,
	[StockDealTitle] [nvarchar](500) NOT NULL,
	[DealPrice] [float] NOT NULL,
	[VisibleStatusID] [int] NOT NULL,
	[StockDealStartDate] [date] NOT NULL,
	[Discount] [float] NOT NULL,
	[StockDealEndDate] [date] NOT NULL,
	[StockDealRegisterDate] [date] NOT NULL,
 CONSTRAINT [PK_StockDealTable] PRIMARY KEY CLUSTERED 
(
	[StockDealID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockItemCategoryTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockItemCategoryTable](
	[StockItemCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[StockItemCategory] [nvarchar](350) NOT NULL,
	[CreatedBy_UserID] [int] NOT NULL,
	[VisibleStatusID] [int] NOT NULL,
 CONSTRAINT [PK_StockItemCategoryTable] PRIMARY KEY CLUSTERED 
(
	[StockItemCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[StockItemIngredientTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockItemIngredientTable](
	[StockItemIngredientID] [int] IDENTITY(1,1) NOT NULL,
	[StockItemID] [int] NOT NULL,
	[StockItemIngredientPhotoPath] [varchar](500) NOT NULL,
	[StockItemIngredientTitle] [nvarchar](500) NOT NULL,
	[CreatedBy_UserID] [int] NOT NULL,
 CONSTRAINT [PK_StockItemIngredientTable] PRIMARY KEY CLUSTERED 
(
	[StockItemIngredientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockItemTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockItemTable](
	[StockItemID] [int] IDENTITY(1,1) NOT NULL,
	[StockItemCategoryID] [int] NOT NULL,
	[ItemPhotoPath] [varchar](500) NOT NULL,
	[StockItemTitle] [nvarchar](350) NOT NULL,
	[ItemSize] [nvarchar](150) NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[RegisterDate] [date] NOT NULL,
	[VisibleStatusID] [int] NOT NULL,
	[CreatedBy_UserID] [int] NOT NULL,
	[OrderTypeID] [int] NOT NULL,
 CONSTRAINT [PK_StockItemTable] PRIMARY KEY CLUSTERED 
(
	[StockItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[StockMenuItemTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockMenuItemTable](
	[StockMenuItemID] [int] IDENTITY(1,1) NOT NULL,
	[StockMenuCategoryID] [int] NOT NULL,
	[StockItemID] [int] NOT NULL,
	[VisibleStatusID] [int] NOT NULL,
	[CreatedBy_UserID] [int] NOT NULL,
 CONSTRAINT [PK_StockMenuItemTable] PRIMARY KEY CLUSTERED 
(
	[StockMenuItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockMenuCategoryTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockMenuCategoryTable](
	[StockMenuCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[StockMenuCategory] [nvarchar](500) NOT NULL,
	[CreatedBy_UserID] [int] NOT NULL,
 CONSTRAINT [PK_StockMenuCategoryTable] PRIMARY KEY CLUSTERED 
(
	[StockMenuCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[TableReservationTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableReservationTable](
	[TableReservationID] [int] IDENTITY(1,1) NOT NULL,
	[Reservation_UserID] [int] NOT NULL,
	[FullName] [nvarchar](250) NOT NULL,
	[EmailAddress] [varchar](350) NOT NULL,
	[MobileNo] [varchar](20) NOT NULL,
	[ReservationRequestDate] [date] NOT NULL,
	[ReservationDateTime] [datetime] NOT NULL,
	[NoOfPersons] [int] NOT NULL,
	[ProcessBy_UserID] [int] NOT NULL,
	[ReservationStatusID] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TableReservationTable] PRIMARY KEY CLUSTERED 
(
	[TableReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAddressTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAddressTable](
	[UserAddressID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[AddressTypeID] [int] NOT NULL,
	[FullAddress] [nvarchar](max) NOT NULL,
	[VisibleStatusID] [int] NOT NULL,
	[CreatedBy_UserID] [int] NOT NULL,
 CONSTRAINT [PK_UserAddressTable] PRIMARY KEY CLUSTERED 
(
	[UserAddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDetailTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetailTable](
	[UserDetailID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[UserDetailProviderDate] [date] NOT NULL,
	[PhotoPath] [nvarchar](500) NOT NULL,
	[ExperenceLevel] [nvarchar](500) NOT NULL,
	[CNIC] [varchar](50) NOT NULL,
	[EducationLevel] [nvarchar](500) NOT NULL,
	[EducationLastDegreeScanPhoto] [varchar](500) NOT NULL,
	[LastExperenceScanPhotoPath] [varchar](500) NOT NULL,
	[CreatedBy_UserID] [int] NOT NULL,
	
 CONSTRAINT [PK_UserDetailTable] PRIMARY KEY CLUSTERED 
(
	[UserDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[UserStatusTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserStatusTable](
	[UserStatusID] [int] IDENTITY(1,1) NOT NULL,
	[UserStatus] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_UserStatusTable] PRIMARY KEY CLUSTERED 
(
	[UserStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTable](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeID] [int] NOT NULL,
	[UserName] [nvarchar](150) NOT NULL,
	[Password] [nvarchar](150) NOT NULL,
	[FirstName] [nvarchar](250) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[ContactNo] [nvarchar](20) NOT NULL,
	[EmailAddress] [varchar](350) NOT NULL,
	[RegisterationDate] [date] NOT NULL,
	[UserStatusID] [int] NOT NULL,
	[UserStatusChangeDate] [date] NOT NULL,
	[GenderID] [int] NOT NULL,
 CONSTRAINT [PK_UserTable] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTypeTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTypeTable](
	[UserTypeID] [int] IDENTITY(1,1) NOT NULL,
	[UserType] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_UserTypeTable] PRIMARY KEY CLUSTERED 
(
	[UserTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VisibleStatusTable]    Script Date: 6/29/2024 8:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisibleStatusTable](
	[VisibleStatusID] [int] IDENTITY(1,1) NOT NULL,
	[VisibleStatus] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_VisibleStatusTable] PRIMARY KEY CLUSTERED 
(
	[VisibleStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[BookingStatusTable](
	[BookingStatusID] [INT] IDENTITY(1,1) NOT NULL,
	[BookingStatus] [NVARCHAR](150) NOT NULL,
	CONSTRAINT [PK_BookingStatusTable] PRIMARY KEY CLUSTERED
	(
		[BookingStatusID]ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
)ON [PRIMARY]
GO
CREATE TABLE [DBO].[BookingTblTable] (
  [BookingTableID] [INT] IDENTITY(1,1) NOT NULL,
  [BookingUserID] [INT] NOT NULL,
  [FullName] [VARCHAR](255) NOT NULL,
  [EmailAddress] [VARCHAR](255) NOT NULL,
  [MobileNo] [VARCHAR](20) NOT NULL,
  [BookingDate] [DATE],
  [ReservationDateTime] [DATETIME],
  [NoOfPersons] [INT] NOT NULL,
  [ProcessBy_UserID] [INT] NOT NULL,
  [BookingStatusID] [INT] NOT NULL,
  [Description] [TEXT] NOT NULL,
  CONSTRAINT [PK_BookingTblTable] PRIMARY KEY CLUSTERED
  (
	[BookingTableID]ASC
  )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
)ON [PRIMARY]
GO
CREATE TABLE [dbo].[OrderReviewTables] (
  [OrderID] [int] IDENTITY(1,1) NOT NULL,
  [ReviewBy_UserID] [int] NOT NULL,
  [Rating] [int] NOT NULL,
  [ReviewDetails] [varchar](max) NOT NULL,
 CONSTRAINT [PK_OrderReviewTables] PRIMARY KEY CLUSTERED
 (
	[OrderID] ASC
 )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
)ON [PRIMARY]
go

drop table [dbo].[StockDeal]

CREATE TABLE [dbo].[StockItemReviewTable](
	[ItemReviewID] [int] IDENTITY(1,1) NOT NULL,
	[StockItemID] [int] NOT NULL,
	[ReviewBy_UserID] [int] NOT NULL,
	[ReviewDateTime] DateTime NOT NULL, 
	[Rating] [int] NOT NULL,
	[ReviewDetails] [nvarchar](max) NOT NULL
	)

	CREATE TABLE [dbo].[CartTable](
	[CartID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UserID] [int] NOT NULL)
	CREATE TABLE [dbo].[CartItemDetailTable](
	[CartItemID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CartID] [int] NOT NULL,
	[StockItemID] [int] NOT NULL,
	[Qty] [int] NOT NULL)
	CREATE TABLE [dbo].[CartDealTable](
	[CartDealID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CartID] [int] NOT NULL,
	[StockDealID] [int] NOT NULL,
	[Qty] [int] NOT NULL) 

	CREATE TABLE [dbo].[StockDeal] (
	  [StockDealID] [INT] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	  [StockDealTitle] [NVARCHAR](450) NOT NULL,
	  [DealPrice] [FLOAT] NOT NULL,
	  [VisibleStatusID] [INT] NOT NULL,
	  [StockDealStartDate] [DATE] NOT NULL,
	  [Discount] [FLOAT] NOT NULL,
	  [StockDealEndDate] [DATE] NOT NULL,
	  StockDealRegisterDate DATE
);

--update truong du lieu
--them du lieu
SET IDENTITY_INSERT [dbo].[AddressTypeTable] ON 

INSERT [dbo].[AddressTypeTable] ([AddressTypeID], [AddressType]) VALUES (1, N'Personal Address')
INSERT [dbo].[AddressTypeTable] ([AddressTypeID], [AddressType]) VALUES (2, N'Home Address')
INSERT [dbo].[AddressTypeTable] ([AddressTypeID], [AddressType]) VALUES (3, N'Work Address')
INSERT [dbo].[AddressTypeTable] ([AddressTypeID], [AddressType]) VALUES (4, N'Other Address')
SET IDENTITY_INSERT [dbo].[AddressTypeTable] OFF
GO
SET IDENTITY_INSERT [dbo].[GenderTable] ON 

INSERT [dbo].[GenderTable] ([GenderID], [GenderTitle]) VALUES (1, N'Male')
INSERT [dbo].[GenderTable] ([GenderID], [GenderTitle]) VALUES (2, N'Female')
INSERT [dbo].[GenderTable] ([GenderID], [GenderTitle]) VALUES (3, N'Other')
SET IDENTITY_INSERT [dbo].[GenderTable] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderStatusTable] ON 

INSERT [dbo].[OrderStatusTable] ([OrderStatusID], [OrderStatus]) VALUES (1, N'Pending')
INSERT [dbo].[OrderStatusTable] ([OrderStatusID], [OrderStatus]) VALUES (2, N'Accepted')
INSERT [dbo].[OrderStatusTable] ([OrderStatusID], [OrderStatus]) VALUES (3, N'On the Way')
INSERT [dbo].[OrderStatusTable] ([OrderStatusID], [OrderStatus]) VALUES (4, N'Rejected')
INSERT [dbo].[OrderStatusTable] ([OrderStatusID], [OrderStatus]) VALUES (5, N'Canceled')
SET IDENTITY_INSERT [dbo].[OrderStatusTable] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderTypeTable] ON 

INSERT [dbo].[OrderTypeTable] ([OrderTypeID], [OrderType]) VALUES (1, N'Pick Up')
INSERT [dbo].[OrderTypeTable] ([OrderTypeID], [OrderType]) VALUES (2, N'Delivery')
SET IDENTITY_INSERT [dbo].[OrderTypeTable] OFF
GO
SET IDENTITY_INSERT [dbo].[ReservationStatusTable] ON 

INSERT [dbo].[ReservationStatusTable] ([ReservationStatusID], [ReservationStatus]) VALUES (1, N'Pending')
INSERT [dbo].[ReservationStatusTable] ([ReservationStatusID], [ReservationStatus]) VALUES (2, N'Accept')
INSERT [dbo].[ReservationStatusTable] ([ReservationStatusID], [ReservationStatus]) VALUES (3, N'Reject')
INSERT [dbo].[ReservationStatusTable] ([ReservationStatusID], [ReservationStatus]) VALUES (4, N'No space')
INSERT [dbo].[ReservationStatusTable] ([ReservationStatusID], [ReservationStatus]) VALUES (5, N'All Reserved')
SET IDENTITY_INSERT [dbo].[ReservationStatusTable] OFF
GO
SET IDENTITY_INSERT [dbo].[UserStatusTable] ON 

INSERT [dbo].[UserStatusTable] ([UserStatusID], [UserStatus]) VALUES (1, N'Pending')
INSERT [dbo].[UserStatusTable] ([UserStatusID], [UserStatus]) VALUES (2, N'Active')
INSERT [dbo].[UserStatusTable] ([UserStatusID], [UserStatus]) VALUES (3, N'De-Active')
INSERT [dbo].[UserStatusTable] ([UserStatusID], [UserStatus]) VALUES (4, N'Suspended')
INSERT [dbo].[UserStatusTable] ([UserStatusID], [UserStatus]) VALUES (5, N'Termenated')
SET IDENTITY_INSERT [dbo].[UserStatusTable] OFF
GO
SET IDENTITY_INSERT [dbo].[UserTypeTable] ON 

INSERT [dbo].[UserTypeTable] ([UserTypeID], [UserType]) VALUES (1, N'Admin')
INSERT [dbo].[UserTypeTable] ([UserTypeID], [UserType]) VALUES (2, N'Operator')
INSERT [dbo].[UserTypeTable] ([UserTypeID], [UserType]) VALUES (3, N'Customer')
SET IDENTITY_INSERT [dbo].[UserTypeTable] OFF
GO
SET IDENTITY_INSERT [dbo].[VisibleStatusTable] ON 

INSERT [dbo].[VisibleStatusTable] ([VisibleStatusID], [VisibleStatus]) VALUES (1, N'Visible')
INSERT [dbo].[VisibleStatusTable] ([VisibleStatusID], [VisibleStatus]) VALUES (2, N'Non-Visible')
SET IDENTITY_INSERT [dbo].[VisibleStatusTable] OFF
GO

SET IDENTITY_INSERT [dbo].[UserTable] ON
INSERT [dbo].[UserTable] ([UserID],[UserTypeID],
[UserName], [Password], 
[FirstName], [LastName],
[ContactNo], [EmailAddress], 
[RegisterationDate], [UserStatusID],
[UserStatusChangeDate], [GenderID]) VALUES(1,1,'Goat','12345',N'Rum',N'Vu','0916320545','minh@gmail.com','2024-07-02',1,'2024-09-02',1)
INSERT [dbo].[UserTable] ([UserID],[UserTypeID],
[UserName], [Password], 
[FirstName], [LastName],
[ContactNo], [EmailAddress], 
[RegisterationDate], [UserStatusID],
[UserStatusChangeDate], [GenderID]) VALUES(2,2,'mquis','123456',N'goat',N'garden','0916322221','goat@gmail.com','2024-05-04',1,'2024-09-08',1)
INSERT [dbo].[UserTable] ([UserID],[UserTypeID],
[UserName], [Password], 
[FirstName], [LastName],
[ContactNo], [EmailAddress], 
[RegisterationDate], [UserStatusID],
[UserStatusChangeDate], [GenderID]) VALUES(3,3,'mcustomer','123456',N'Khach',N'Hang','09163245521','customer@gmail.com','2024-10-24',1,'2024-04-18',1)
SET IDENTITY_INSERT [dbo].[UserTable] OFF
GO
SET IDENTITY_INSERT [dbo].[StockItemCategoryTable] ON
INSERT [dbo].[StockItemCategoryTable]([StockItemCategoryID],
	[StockItemCategory],
	[CreatedBy_UserID],
	[VisibleStatusID]) values (1,'Drink',1,1)

go
SET IDENTITY_INSERT [dbo].[BookingStatusTable] ON 
GO
INSERT [dbo].[BookingStatusTable] ([BookingStatusID], [BookingStatus]) VALUES (1, N'Processing')
GO
INSERT [dbo].[BookingStatusTable] ([BookingStatusID], [BookingStatus]) VALUES (2, N'Approved')
GO
INSERT [dbo].[BookingStatusTable] ([BookingStatusID], [BookingStatus]) VALUES (3, N'Reject')
GO
INSERT [dbo].[BookingStatusTable] ([BookingStatusID], [BookingStatus]) VALUES (4, N'Canceled')
GO
SET IDENTITY_INSERT [dbo].[BookingStatusTable] OFF
GO

--THEM MOI QUAN HE GIUA CAC BANG
ALTER TABLE [dbo].[DiscountTable] ADD  CONSTRAINT [DF_DiscountTable_IsUserStatus]  DEFAULT ((0)) FOR [IsUserStatus]
GO
ALTER TABLE [dbo].[OrderDealDetailTable]  WITH CHECK ADD  CONSTRAINT [FK_OrderDealDetailTable_OrderTable] FOREIGN KEY([OrderID])
REFERENCES [dbo].[OrderTable] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDealDetailTable] CHECK CONSTRAINT [FK_OrderDealDetailTable_OrderTable]
GO
ALTER TABLE [dbo].[OrderDealDetailTable]  WITH CHECK ADD  CONSTRAINT [FK_OrderDealDetailTable_StockDealTable] FOREIGN KEY([StockDealID])
REFERENCES [dbo].[StockDealTable] ([StockDealID])
GO
ALTER TABLE [dbo].[OrderDealDetailTable] CHECK CONSTRAINT [FK_OrderDealDetailTable_StockDealTable]
GO
ALTER TABLE [dbo].[OrderItemDetailTable]  WITH CHECK ADD  CONSTRAINT [FK_OrderItemDetailTable_DiscountTable] FOREIGN KEY([DiscountID])
REFERENCES [dbo].[DiscountTable] ([DiscountID])
GO
ALTER TABLE [dbo].[OrderItemDetailTable] CHECK CONSTRAINT [FK_OrderItemDetailTable_DiscountTable]
GO
ALTER TABLE [dbo].[OrderItemDetailTable]  WITH CHECK ADD  CONSTRAINT [FK_OrderItemDetailTable_OrderTable] FOREIGN KEY([OrderID])
REFERENCES [dbo].[OrderTable] ([OrderID])
GO
ALTER TABLE [dbo].[OrderItemDetailTable] CHECK CONSTRAINT [FK_OrderItemDetailTable_OrderTable]
GO
ALTER TABLE [dbo].[OrderItemDetailTable]  WITH CHECK ADD  CONSTRAINT [FK_OrderItemDetailTable_StockItemTable] FOREIGN KEY([StockItemID])
REFERENCES [dbo].[StockItemTable] ([StockItemID])
GO
ALTER TABLE [dbo].[OrderItemDetailTable] CHECK CONSTRAINT [FK_OrderItemDetailTable_StockItemTable]
GO
ALTER TABLE [dbo].[OrderTable]  WITH CHECK ADD  CONSTRAINT [FK_OrderTable_OrderStatusTable] FOREIGN KEY([OrderStatusID])
REFERENCES [dbo].[OrderStatusTable] ([OrderStatusID])
GO
ALTER TABLE [dbo].[OrderTable] CHECK CONSTRAINT [FK_OrderTable_OrderStatusTable]
GO
ALTER TABLE [dbo].[OrderTable]  WITH CHECK ADD  CONSTRAINT [FK_OrderTable_OrderTypeTable] FOREIGN KEY([OrderTypeID])
REFERENCES [dbo].[OrderTypeTable] ([OrderTypeID])
GO
ALTER TABLE [dbo].[OrderTable] CHECK CONSTRAINT [FK_OrderTable_OrderTypeTable]
GO
ALTER TABLE [dbo].[OrderTable]  WITH CHECK ADD  CONSTRAINT [FK_OrderTable_UserAddressTable] FOREIGN KEY([DeliveryAddress_UserAddressID])
REFERENCES [dbo].[UserAddressTable] ([UserAddressID])
GO
ALTER TABLE [dbo].[OrderTable] CHECK CONSTRAINT [FK_OrderTable_UserAddressTable]
GO
ALTER TABLE [dbo].[OrderTable]  WITH CHECK ADD  CONSTRAINT [FK_OrderTable_UserTable] FOREIGN KEY([OrderBy_UserID])
REFERENCES [dbo].[UserTable] ([UserID])
GO
ALTER TABLE [dbo].[OrderTable] CHECK CONSTRAINT [FK_OrderTable_UserTable]
GO
ALTER TABLE [dbo].[StockDealDetailTable]  WITH CHECK ADD  CONSTRAINT [FK_DealDetailTable_StockDealTable] FOREIGN KEY([StockDealID])
REFERENCES [dbo].[StockDealTable] ([StockDealID])
GO
ALTER TABLE [dbo].[StockDealDetailTable] CHECK CONSTRAINT [FK_DealDetailTable_StockDealTable]
GO
ALTER TABLE [dbo].[StockDealDetailTable]  WITH CHECK ADD  CONSTRAINT [FK_DealDetailTable_VisibleStatusTable] FOREIGN KEY([VisibleStatusID])
REFERENCES [dbo].[VisibleStatusTable] ([VisibleStatusID])
GO
ALTER TABLE [dbo].[StockDealDetailTable] CHECK CONSTRAINT [FK_DealDetailTable_VisibleStatusTable]
GO
ALTER TABLE [dbo].[StockDealDetailTable]  WITH CHECK ADD  CONSTRAINT [FK_StockDealDetailTable_StockItemTable] FOREIGN KEY([StockItemID])
REFERENCES [dbo].[StockItemTable] ([StockItemID])
GO
ALTER TABLE [dbo].[StockDealDetailTable] CHECK CONSTRAINT [FK_StockDealDetailTable_StockItemTable]
GO
ALTER TABLE [dbo].[StockDealTable]  WITH CHECK ADD  CONSTRAINT [FK_StockDealTable_VisibleStatusTable] FOREIGN KEY([VisibleStatusID])
REFERENCES [dbo].[VisibleStatusTable] ([VisibleStatusID])
GO
ALTER TABLE [dbo].[StockDealTable] CHECK CONSTRAINT [FK_StockDealTable_VisibleStatusTable]
GO
ALTER TABLE [dbo].[StockItemCategoryTable]  WITH CHECK ADD  CONSTRAINT [FK_StockItemCategoryTable_VisibleStatusTable] FOREIGN KEY([VisibleStatusID])
REFERENCES [dbo].[VisibleStatusTable] ([VisibleStatusID])
GO
ALTER TABLE [dbo].[StockItemCategoryTable] CHECK CONSTRAINT [FK_StockItemCategoryTable_VisibleStatusTable]
GO
ALTER TABLE [dbo].[StockItemIngredientTable]  WITH CHECK ADD  CONSTRAINT [FK_StockItemIngredientTable_StockItemTable] FOREIGN KEY([StockItemID])
REFERENCES [dbo].[StockItemTable] ([StockItemID])
GO
ALTER TABLE [dbo].[StockItemIngredientTable] CHECK CONSTRAINT [FK_StockItemIngredientTable_StockItemTable]
GO
ALTER TABLE [dbo].[StockItemTable]  WITH CHECK ADD  CONSTRAINT [FK_StockItemTable_OrderTypeTable] FOREIGN KEY([OrderTypeID])
REFERENCES [dbo].[OrderTypeTable] ([OrderTypeID])
GO
ALTER TABLE [dbo].[StockItemTable] CHECK CONSTRAINT [FK_StockItemTable_OrderTypeTable]
GO
ALTER TABLE [dbo].[StockItemTable]  WITH CHECK ADD  CONSTRAINT [FK_StockItemTable_StockItemCategoryTable] FOREIGN KEY([StockItemCategoryID])
REFERENCES [dbo].[StockItemCategoryTable] ([StockItemCategoryID])
GO
ALTER TABLE [dbo].[StockItemTable] CHECK CONSTRAINT [FK_StockItemTable_StockItemCategoryTable]
GO
ALTER TABLE [dbo].[StockItemTable]  WITH CHECK ADD  CONSTRAINT [FK_StockItemTable_VisibleStatusTable] FOREIGN KEY([VisibleStatusID])
REFERENCES [dbo].[VisibleStatusTable] ([VisibleStatusID])
GO
ALTER TABLE [dbo].[StockItemTable] CHECK CONSTRAINT [FK_StockItemTable_VisibleStatusTable]
GO
ALTER TABLE [dbo].[StockMenuItemTable]  WITH CHECK ADD  CONSTRAINT [FK_StockMenuItemTable_StockItemTable] FOREIGN KEY([StockItemID])
REFERENCES [dbo].[StockItemTable] ([StockItemID])
GO
ALTER TABLE [dbo].[StockMenuItemTable] CHECK CONSTRAINT [FK_StockMenuItemTable_StockItemTable]
GO
ALTER TABLE [dbo].[StockMenuItemTable]  WITH CHECK ADD  CONSTRAINT [FK_StockMenuItemTable_StockMenuCategoryTable] FOREIGN KEY([StockMenuCategoryID])
REFERENCES [dbo].[StockMenuCategoryTable] ([StockMenuCategoryID])
GO
ALTER TABLE [dbo].[StockMenuItemTable] CHECK CONSTRAINT [FK_StockMenuItemTable_StockMenuCategoryTable]
GO
ALTER TABLE [dbo].[StockMenuItemTable]  WITH CHECK ADD  CONSTRAINT [FK_StockMenuItemTable_VisibleStatusTable] FOREIGN KEY([VisibleStatusID])
REFERENCES [dbo].[VisibleStatusTable] ([VisibleStatusID])
GO
ALTER TABLE [dbo].[StockMenuItemTable] CHECK CONSTRAINT [FK_StockMenuItemTable_VisibleStatusTable]
GO
ALTER TABLE [dbo].[TableReservationTable]  WITH CHECK ADD  CONSTRAINT [FK_TableReservationTable_ProcessUserTable] FOREIGN KEY([ProcessBy_UserID])
REFERENCES [dbo].[UserTable] ([UserID])
GO
ALTER TABLE [dbo].[TableReservationTable] CHECK CONSTRAINT [FK_TableReservationTable_ProcessUserTable]
GO
ALTER TABLE [dbo].[TableReservationTable]  WITH CHECK ADD  CONSTRAINT [FK_TableReservationTable_ReservationStatusTable] FOREIGN KEY([ReservationStatusID])
REFERENCES [dbo].[ReservationStatusTable] ([ReservationStatusID])
GO
ALTER TABLE [dbo].[TableReservationTable] CHECK CONSTRAINT [FK_TableReservationTable_ReservationStatusTable]
GO
ALTER TABLE [dbo].[TableReservationTable]  WITH CHECK ADD  CONSTRAINT [FK_TableReservationTable_UserTable] FOREIGN KEY([Reservation_UserID])
REFERENCES [dbo].[UserTable] ([UserID])
GO
ALTER TABLE [dbo].[TableReservationTable] CHECK CONSTRAINT [FK_TableReservationTable_UserTable]
GO
ALTER TABLE [dbo].[UserAddressTable]  WITH CHECK ADD  CONSTRAINT [FK_UserAddressTable_AddressTypeTable] FOREIGN KEY([AddressTypeID])
REFERENCES [dbo].[AddressTypeTable] ([AddressTypeID])
GO
ALTER TABLE [dbo].[UserAddressTable] CHECK CONSTRAINT [FK_UserAddressTable_AddressTypeTable]
GO
ALTER TABLE [dbo].[UserAddressTable]  WITH CHECK ADD  CONSTRAINT [FK_UserAddressTable_UserTable] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTable] ([UserID])
GO
ALTER TABLE [dbo].[UserAddressTable] CHECK CONSTRAINT [FK_UserAddressTable_UserTable]
GO
ALTER TABLE [dbo].[UserAddressTable]  WITH CHECK ADD  CONSTRAINT [FK_UserAddressTable_VisibleStatusTable] FOREIGN KEY([VisibleStatusID])
REFERENCES [dbo].[VisibleStatusTable] ([VisibleStatusID])
GO
ALTER TABLE [dbo].[UserAddressTable] CHECK CONSTRAINT [FK_UserAddressTable_VisibleStatusTable]
GO
ALTER TABLE [dbo].[UserDetailTable]  WITH CHECK ADD  CONSTRAINT [FK_UserDetailTable_UserTable] FOREIGN KEY([UserDetailID])
REFERENCES [dbo].[UserTable] ([UserID])
GO
ALTER TABLE [dbo].[UserDetailTable] CHECK CONSTRAINT [FK_UserDetailTable_UserTable]
GO
ALTER TABLE [dbo].[UserTable]  WITH CHECK ADD  CONSTRAINT [FK_UserTable_GenderTable] FOREIGN KEY([GenderID])
REFERENCES [dbo].[GenderTable] ([GenderID])
GO
ALTER TABLE [dbo].[UserTable] CHECK CONSTRAINT [FK_UserTable_GenderTable]
GO
ALTER TABLE [dbo].[UserTable]  WITH CHECK ADD  CONSTRAINT [FK_UserTable_UserStatusTable] FOREIGN KEY([UserStatusID])
REFERENCES [dbo].[UserStatusTable] ([UserStatusID])
GO
ALTER TABLE [dbo].[UserTable] CHECK CONSTRAINT [FK_UserTable_UserStatusTable]
GO
ALTER TABLE [dbo].[UserTable]  WITH CHECK ADD  CONSTRAINT [FK_UserTable_UserTypeTable] FOREIGN KEY([UserTypeID])
REFERENCES [dbo].[UserTypeTable] ([UserTypeID])
GO
ALTER TABLE [dbo].[UserTable] CHECK CONSTRAINT [FK_UserTable_UserTypeTable]
GO

ALTER TABLE [dbo].[OrderReviewTables]  WITH CHECK ADD  CONSTRAINT [FK_OrderReviewTables_OrderTables] FOREIGN KEY([OrderID])
REFERENCES [dbo].[OrderTables] ([OrderID])
GO
ALTER TABLE [dbo].[OrderReviewTables] CHECK CONSTRAINT [FK_OrderReviewTables_OrderTables]
GO
ALTER TABLE [dbo].[OrderReviewTables]  WITH CHECK ADD  CONSTRAINT [FK_OrderReviewTables_UserTables] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTables] ([UserID])
GO
ALTER TABLE [dbo].[OrderReviewTables] CHECK CONSTRAINT [FK_OrderReviewTables_UserTables]
GO
