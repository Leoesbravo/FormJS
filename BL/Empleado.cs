using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result EmpleadoGetall()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.Examen4Entities context = new DL.Examen4Entities())
                {
                    var empleados = context.EmpleadoGetAll().ToList();
                    result.Objects = new List<object>();
                    if (empleados != null)
                    {
                        foreach (var obj in empleados)
                        {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.IdEmpleado = obj.IdEmpleado;
                            empleado.NumeroNomina = obj.NumeroNomina;
                            empleado.Nombre = obj.Nombre;
                            empleado.ApellidoMaterno = obj.ApellidoPaterno;
                            empleado.ApellidoPaterno = obj.ApellidoMaterno;

                            empleado.Estado = new ML.Estado();
                            empleado.Estado.IdEstado = obj.IdEstado;
                            empleado.Estado.Nombre = obj.NombreEstado;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ha ocurrido un error";
                    }
                }
            }
            catch(Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
            }
            return result;
        }
        public static ML.Result EmpleadoAdd(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.Examen4Entities context = new DL.Examen4Entities())
                {
                    var query = context.EmpleadoAdd(empleado.NumeroNomina, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Estado.IdEstado);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar el insert";
                    }
                    result.Correct = true;
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result EmpleadoDelete(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.Examen4Entities context = new DL.Examen4Entities())
                {
                    var query = context.EmpleadoDelete(IdEmpleado);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido eliminar el registro";
                    }
                    result.Correct = true;
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result EmpleadoUpdate(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.Examen4Entities context = new DL.Examen4Entities())
                {
                    var query = context.EmpleadoUpdate(empleado.IdEmpleado, empleado.NumeroNomina, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Estado.IdEstado);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar la actualización";
                    }
                    
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.Examen4Entities context = new DL.Examen4Entities())
                {
                    var query = context.EmpleadoGetById(IdEmpleado).FirstOrDefault();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        ML.Empleado empleado = new ML.Empleado();
                        empleado.IdEmpleado = query.IdEmpleado;
                        empleado.NumeroNomina = query.NumeroNomina;
                        empleado.Nombre = query.Nombre;
                        empleado.ApellidoPaterno = query.ApellidoPaterno;
                        empleado.ApellidoMaterno = query.ApellidoMaterno;

                        empleado.Estado = new ML.Estado();
                        empleado.Estado.IdEstado = query.IdEstado.Value;

                        result.Object = empleado;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo realizar la consulta";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
