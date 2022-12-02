﻿CREATE TABLE [dbo].[BackUpAddressTable]
(
	[AccountId]  NCHAR (16) NULL,
    [Ward]  NCHAR (2) NULL,
    [Section]  NCHAR (2) NULL,
    [Block]  NCHAR (5) NULL,
    [Lot]  NCHAR (4) NULL,
    [LandUseCode] NCHAR NULL,
    [YearBuilt] SMALLINT NULL,
    [IsGroundRent] BIT NULL,
    [IsRedeemed] BIT NULL,
    [DetailsNotLegible] BIT NULL,
    [PaymentAmount] SMALLMONEY NULL,
    [PaymentFrequency] NCHAR(50) NULL,
    [PaymentDateAnnual] SMALLDATETIME NULL,
    [PaymentDateSemiAnnual1] SMALLDATETIME NULL,
    [PaymentDateSemiAnnual2] SMALLDATETIME NULL,
    [PaymentDateQuarterly1] SMALLDATETIME NULL,
    [PaymentDateQuarterly2] SMALLDATETIME NULL,
    [PaymentDateQuarterly3] SMALLDATETIME NULL,
    [PaymentDateQuarterly4] SMALLDATETIME NULL
)
