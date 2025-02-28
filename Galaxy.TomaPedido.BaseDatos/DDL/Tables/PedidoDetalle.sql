CREATE TABLE [dbo].[PedidoDetalle]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdPedido] INT NOT NULL, 
    [IdProducto] INT NOT NULL, 
    [Cantidad] INT NOT NULL, 
    [PrecioUnitario] DECIMAL(18, 2) NOT NULL, 
    [TotalBruto] DECIMAL(18, 2) NOT NULL, 
    [TotalNeto] DECIMAL(18, 2) NULL,
    [Estado] BIT NOT NULL DEFAULT 1, 
    [FechaCreacion] DATETIME NOT NULL DEFAULT getdate(), 
    [UsuarioCreacion] VARCHAR(50) NOT NULL DEFAULT 'sql', 
    [FechaModificacion] DATETIME NULL, 
    [UsuarioModificacion] VARCHAR(50) NULL, 
    CONSTRAINT [FK_PedidoDetalle_ToPedido] FOREIGN KEY ([IdPedido]) REFERENCES Pedido(Id), 
    CONSTRAINT [FK_PedidoDetalle_ToProducto] FOREIGN KEY ([IdProducto]) REFERENCES Producto(Id),
)
