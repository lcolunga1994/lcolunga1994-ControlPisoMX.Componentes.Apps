CREATE TABLE [corestesting].[Settings] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Name]  VARCHAR (MAX) NOT NULL,
    [Value] VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED ([Id] ASC)
);

