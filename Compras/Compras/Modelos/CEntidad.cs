using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Compras.Modelos
{
    abstract class CEntidad
    {

        protected static SqlConnection conexion = new SqlConnection("Data Source = DESKTOP-7V51383\\SQLEXPRESS; Initial Catalog = Compras; Integrated Security = True");
    
        protected static SqlCommand comando;
        protected static SqlDataReader lector;

        public abstract void Insertar();
        public abstract void Actualizar();

        public CEntidad()
        {
            conexion = new SqlConnection("Data Source = DESKTOP-7V51383\\SQLEXPRESS; Initial Catalog = Compras; Integrated Security = True");
        }


    }
}
