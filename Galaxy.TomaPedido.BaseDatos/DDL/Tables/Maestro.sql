CREATE TABLE [dbo].[Maestro]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Codigo] VARCHAR(20) NOT NULL UNIQUE, 
    [Nombre] VARCHAR(50) NOT NULL, 
    [Descripcion] VARCHAR(50) NULL, 
    [Estado] BIT NOT NULL DEFAULT 1, 
    [FechaCreacion] DATETIME NOT NULL DEFAULT getdate(), 
    [UsuarioCreacion] VARCHAR(50) NOT NULL DEFAULT 'sql', 
    [FechaModificacion] DATETIME NULL, 
    [UsuarioModificacion] VARCHAR(50) NULL
)
