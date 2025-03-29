CREATE TABLE [dbo].[Cliente]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RazonSocial] VARCHAR(100) NOT NULL, 
    [NumeroDocumento] CHAR(12) NOT NULL, 
    [Contacto] VARCHAR(100) NULL, 
    [Direccion] VARCHAR(100) NULL, 
    [CorreoElectronico] VARCHAR(100) NULL, 
    [Celular] CHAR(9) NULL,
    [IdRubroMae] INT NOT NULL,
    [Estado] BIT NOT NULL DEFAULT 1, 
    [FechaCreacion] DATETIME NOT NULL DEFAULT getdate(), 
    [UsuarioCreacion] VARCHAR(50) NOT NULL DEFAULT 'sql', 
    [FechaModificacion] DATETIME NULL, 
    [UsuarioModificacion] VARCHAR(50) NULL, 
    CONSTRAINT [FK_Cliente_ToMaestroDetalle] FOREIGN KEY ([IdRubroMae]) REFERENCES MaestroDetalle(Id)
)
