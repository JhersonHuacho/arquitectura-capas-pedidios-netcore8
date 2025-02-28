CREATE TABLE [dbo].[Pedido]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdCliente] INT NOT NULL, 
    [IdColaborador] INT NOT NULL, 
    [TotalBruto] DECIMAL(18, 2) NULL, 
    [TotalNeto] DECIMAL(18, 2) NULL, 
    [Adelanto] DECIMAL(18, 2) NULL,
    [Estado] BIT NOT NULL DEFAULT 1, 
    [FechaCreacion] DATETIME NOT NULL DEFAULT getdate(), 
    [UsuarioCreacion] VARCHAR(50) NOT NULL DEFAULT 'sql', 
    [FechaModificacion] DATETIME NULL, 
    [UsuarioModificacion] VARCHAR(50) NULL, 
    CONSTRAINT [FK_Pedido_ToCliente] FOREIGN KEY ([IdCliente]) REFERENCES CLiente(Id),
)
