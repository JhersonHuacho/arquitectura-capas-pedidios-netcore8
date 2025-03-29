CREATE TABLE [dbo].[MaestroDetalle]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [IdMaestro] INT NOT NULL,
    [Codigo] VARCHAR(20) NULL UNIQUE, 
    [Valor] VARCHAR(50) NULL,
    [Estado] BIT NOT NULL DEFAULT 1, 
    [FechaCreacion] DATETIME NOT NULL DEFAULT getdate(), 
    [UsuarioCreacion] VARCHAR(50) NOT NULL DEFAULT 'sql', 
    [FechaModificacion] DATETIME NULL, 
    [UsuarioModificacion] VARCHAR(50) NULL
    CONSTRAINT [FK_MestroDetalle_ToMaestro] FOREIGN KEY ([IdMaestro]) REFERENCES Maestro(Id)
)
