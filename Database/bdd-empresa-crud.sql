CREATE DATABASE EmpresaGT;
GO

USE EmpresaGT
GO

CREATE TABLE Empleado(
 EmpleadoID INT IDENTITY(1,1) NOT NULL,
 Nombre VARCHAR(100),
 NumeroDocumento VARCHAR(13),
 Sueldo INTEGER
 CONSTRAINT PK_EmpleadoID PRIMARY KEY(EmpleadoID)
);
GO

INSERT INTO Empleado VALUES('Juan Carlos Pin Plata',CASt('2222144491502' AS VARCHAR(13)),5000);
INSERT INTO Empleado VALUES('Ana leticia Pica Piedra',CASt('2323284441204' AS VARCHAR(13)),10000);
INSERT INTO Empleado VALUES('Juana la cubana',CASt('9999999999999' AS VARCHAR(13)),10000);
GO
--1
CREATE PROCEDURE sp_listar_empleados
AS
BEGIN
 SELECT 
    EmpleadoID,
    Nombre,
    NumeroDocumento,
    Sueldo
FROM dbo.Empleado
END;

--EXEC sp_listar_empleados
GO
--2
CREATE PROCEDURE sp_obtener_empleado(
@EmpleadoID INT)
AS
BEGIN
  SELECT 
    EmpleadoID,
    Nombre,
    NumeroDocumento,
    Sueldo
FROM dbo.Empleado
WHERE EmpleadoID = @EmpleadoID
END;

--EXEC sp_obtener_empleado 1
GO
--3
CREATE PROCEDURE sp_insertar_empleado(
  @Nombre VARCHAR(100),
  @NumeroDocumento VARCHAR(13),
  @Sueldo INT,
  @MsgError VARCHAR(100) OUTPUT
)
AS
BEGIN
  IF(EXISTS(SELECT 1 FROM Empleado WHERE NumeroDocumento = @NumeroDocumento))
     BEGIN
	   SET @MsgError ='Numero documento ya se encuentra registrado'
	   RETURN
	 END;

  INSERT INTO Empleado VALUES(@Nombre,@NumeroDocumento,@Sueldo);
  SET @MsgError= ''
END;
GO
--4
CREATE PROCEDURE sp_actualizar_empleado(
  @EmpleadoID INT,
  @Nombre VARCHAR(100),
  @NumeroDocumento VARCHAR(13),
  @Sueldo INT,
  @MsgError VARCHAR(100) OUTPUT
)
AS
BEGIN
  IF(EXISTS(SELECT 1 FROM Empleado WHERE NumeroDocumento = @NumeroDocumento AND EmpleadoID != @EmpleadoID))
     BEGIN
	   SET @MsgError ='Numero documento ya se encuentra registrado'
	   RETURN
	 END;

  UPDATE Empleado SET Nombre=@Nombre,NumeroDocumento=@NumeroDocumento,Sueldo=@Sueldo WHERE EmpleadoID=@EmpleadoID
  SET @MsgError= ''

END;
GO
--5
CREATE PROCEDURE sp_eliminar_empleado(
  @EmpleadoID INT
)
AS
BEGIN
  DELETE FROM Empleado WHERE EmpleadoID = @EmpleadoID
END;
GO