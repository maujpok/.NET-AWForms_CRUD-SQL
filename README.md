# .NET AWForms - CRUD+SQL


Mi primera aplicación C# con SLQ Server!

Comparto el código de un pequeño proyecto de Windows Forms realizado en Visual Studio.

La aplicación permite realizar un CRUD completo sobre una tabla de empleados, conectada a una BBDD en la nube.

Se pueden ingresar nuevos empleados, consultar los datos de un empleado, actualizarlos y/o eliminar un empleado, todo por N° de documento. Con validación de datos en el formulario y MessageBox de confirmación de eliminación.

---------------------------------------------------------------------------------------------------

Para probar localmente la aplicación, deberás crear una base de datos local en SQL Server Management, obtener el connection string de la misma, y aplicarla en el constructor de la clase Conexion.
Luego, hacer una query para generar la tabla tb_empleados en la BBDD. La query es:

CREATE TABLE tb_empleados(
Documento NVARCHAR(15) PRIMARY KEY,
Nombre NVARCHAR(100) NOT NULL,
Apellido NVARCHAR(100) NOT NULL,
Edad INT NOT NULL,
Domicilio NVARCHAR(150) NULL,
Fecha_Nacimiento DATE
);

Luego de estos dos pasos, podrás correr la aplicación en Visual Studio.

Muchas gracias!! 
