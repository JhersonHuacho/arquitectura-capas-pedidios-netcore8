CREATE TABLE [dbo].[Producto]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nombre] VARCHAR(50) NOT NULL, 
    [Descripcion] VARCHAR(100) NOT NULL, 
    [IdMarcaMae] INT NOT NULL, 
    [IdCategoriaMae] INT NOT NULL, 
    [PrecioUnitario] DECIMAL(18, 2) NULL, 
    [Stock] INT NULL,
    [Estado] BIT NOT NULL DEFAULT 1, 
    [FechaCreacion] DATETIME NOT NULL DEFAULT getdate(), 
    [UsuarioCreacion] VARCHAR(50) NOT NULL DEFAULT 'sql', 
    [FechaModificacion] DATETIME NULL, 
    [UsuarioModificacion] VARCHAR(50) NULL, 
    CONSTRAINT [FK_Producto_ToMaestroDetalleMarca] FOREIGN KEY ([IdMarcaMae]) REFERENCES MaestroDetalle(Id), 
    CONSTRAINT [FK_Producto_ToMaestroDetalleCategoria] FOREIGN KEY ([IdCategoriaMae]) REFERENCES MaestroDetalle(Id), 
)
