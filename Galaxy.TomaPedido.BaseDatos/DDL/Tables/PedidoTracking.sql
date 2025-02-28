CREATE TABLE [dbo].[PedidoTracking]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdPedido] INT NOT NULL, 
    [IdEstadoMae] INT NOT NULL, 
    [Comentario] VARCHAR(200) NULL,
    [Estado] BIT NOT NULL DEFAULT 1, 
    [FechaCreacion] DATETIME NOT NULL DEFAULT getdate(), 
    [UsuarioCreacion] VARCHAR(50) NOT NULL DEFAULT 'sql', 
    [FechaModificacion] DATETIME NULL, 
    [UsuarioModificacion] VARCHAR(50) NULL, 
    CONSTRAINT [FK_PedidoTracking_ToPedido] FOREIGN KEY ([IdPedido]) REFERENCES Pedido(Id),
    CONSTRAINT [FK_PedidoTracking_ToMaestroDetalleEstado] FOREIGN KEY ([IdEstadoMae]) REFERENCES MaestroDetalle(Id),
)
