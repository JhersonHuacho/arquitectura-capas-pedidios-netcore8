/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

DECLARE  @IdMaestroMarcas INT = 0;

INSERT INTO Maestro (Codigo, Nombre, Descripcion)
VALUES ('MAE_MARCAS', 'MARCAS', 'CATALOGO DE MARCAS DE LOS PRODUCTOS')

SET @IdMaestroMarcas = (SELECT @@IDENTITY)

INSERT INTO MaestroDetalle (IdMaestro, Codigo, Valor)
VALUES
    (@IdMaestroMarcas, 'M_PRIMOR', 'PRIMOR'),
    (@IdMaestroMarcas, 'M_GLORIA', 'GLORIA'),
    (@IdMaestroMarcas, 'M_MOLITALIA', 'MOLITALIA'),
    (@IdMaestroMarcas, 'M_CIELO', 'CIELO')


DECLARE @IdMaestroCategorias INT = 0;

INSERT INTO Maestro (Codigo, Nombre, Descripcion)
VALUES ('MAE_CATEGORIAS', 'CATEGORIAS', 'CATALOGO DE CATEGORIAS DE LOS PRODUCTOS')

SET @IdMaestroCategorias = (SELECT @@IDENTITY)

INSERT INTO MaestroDetalle (IdMaestro, Codigo, Valor)
VALUES
    (@IdMaestroCategorias, 'C_LIMPIEZA', 'LIMPIEZA'),
    (@IdMaestroCategorias, 'C_ALIMENTOS', 'ALIMENTOS'),
    (@IdMaestroCategorias, 'C_ASEO', 'ASEO PERSONAL'),
    (@IdMaestroCategorias, 'C_BEBIDAS', 'GASEOSAS')


DECLARE @IdMaestroRubros INT = 0;

INSERT INTO Maestro (Codigo, Nombre, Descripcion)
VALUES ('MAE_RUBROS', 'RUBROS', 'CATALOGO DE RUBROS DE LOS CLIENTE')

SET @IdMaestroRubros = (SELECT @@IDENTITY)

INSERT INTO MaestroDetalle (IdMaestro, Codigo, Valor)
VALUES
    (@IdMaestroRubros, 'R_GIMNASIO', 'GIMNASIO'),
    (@IdMaestroRubros, 'R_BODEGA', 'BODEGA'),
    (@IdMaestroRubros, 'R_FARMACIA', 'FARMACIA'),
    (@IdMaestroRubros, 'R_KIOSKO', 'KIOSKO')

DECLARE @ID_ESTADO_PEDIDO INT
INSERT INTO Maestro (Codigo, Nombre, Descripcion, FechaCreacion, UsuarioCreacion)
VALUES ('MAE_ESTPDD','ESTADO PEDIDO','ESTADOS DEL PEDIDO', GETDATE(), 'Admin')

SET @ID_ESTADO_PEDIDO = (SELECT @@IDENTITY)

INSERT INTO MaestroDetalle (Codigo, IdMaestro, Valor, FechaCreacion, UsuarioCreacion)
VALUES
    ('PDD_REGISTRADO',@ID_ESTADO_PEDIDO,  'REGISTRADO', GETDATE() , 'Admin'),
    ('PDD_RECIBIDO',@ID_ESTADO_PEDIDO, 'RECIBIDO', GETDATE() , 'Admin'),
    ('PDD_DESPACHO',@ID_ESTADO_PEDIDO, 'EN DESPACHO', GETDATE() , 'Admin'),
    ('PDD_CAMINO',@ID_ESTADO_PEDIDO, 'EN CAMINO', GETDATE() , 'Admin'),
    ('PDD_ENTREGADO',@ID_ESTADO_PEDIDO, 'ENTREGADO', GETDATE() , 'Admin'),
    ('PDD_CANCELADO',@ID_ESTADO_PEDIDO, 'CANCELADO', GETDATE() , 'Admin'),
    ('PDD_RETRASADO',@ID_ESTADO_PEDIDO, 'RETRASADO', GETDATE() , 'Admin')