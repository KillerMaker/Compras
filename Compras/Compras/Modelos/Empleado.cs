using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compras.Modelos
{
    class Empleado:CEntidad
    {
        public readonly int? id;
        public readonly string cedula;
        public readonly string nombre;
        public readonly int departamento;
        public readonly string estado;

        public Empleado(int? id, string cedula, string nombre, int departamento, string estado):base()
        {
            this.id = id;
            this.cedula = cedula;
            this.nombre = nombre;
            this.departamento = departamento;
            this.estado = estado;
        }

        public static List<Empleado> Select(int? id = null)
        {
            List<Empleado> empleados = new List<Empleado>();
            Empleado empleado = null;
            try
            {
                conexion.Open();
                comando = new SqlCommand($"SELECT * FROM EMPLEADO", conexion);
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    empleado = new Empleado((int)lector[0], (string)lector[1], (string)lector[2],(int)lector[3],(string)lector[4]);
                    empleados.Add(empleado);
                }
                conexion.Close();
                return empleados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void Eliminar(int id)
        {
            try
            {
                conexion.Open();
                comando = new SqlCommand($"DELETE FROM EMPLEADO WHERE ID={id}", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void Actualizar()
        {
            try
            {
                conexion.Open();
                comando = new SqlCommand($@"UPDATE EMPLEADO SET 
                                                   CEDULA ='{cedula}',
                                                   NOMBRE='{nombre}',
                                                   DEPARTAMENTO={departamento},
                                                   ESTADO='{estado}' WHERE ID={id.Value}", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void Insertar()
        {
            try
            {
                conexion.Open();
                comando = new SqlCommand($"INSERT INTO EMPLEADO VALUES('{cedula}','{nombre}',{departamento},'{estado}')", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
