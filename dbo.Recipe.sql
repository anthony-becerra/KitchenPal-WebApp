CREATE TABLE [dbo].[Recipe] (
    [ID]                INT            IDENTITY (1, 1) NOT NULL,
    [ApiRef]            NVARCHAR (MAX) NULL,
    [ApplicationUserId] NVARCHAR (450) NULL,
    [CustomRecipe]      BIT            NOT NULL DEFAULT 0 ,
    [Description]       NVARCHAR (MAX) NULL,
    [Name]              NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Recipe] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Recipe_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Recipe_ApplicationUserId]
    ON [dbo].[Recipe]([ApplicationUserId] ASC);

