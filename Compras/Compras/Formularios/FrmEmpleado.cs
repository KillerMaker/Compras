using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Compras.Modelos;

namespace Compras.Formularios
{
    public partial class FrmEmpleado : Form
    {
        private Empleado empleado;
        public FrmEmpleado()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            empleado = new Empleado
                (
                    null,
                    txtCedula.Text,
                    txtNombre.Text,
                   Convert.ToInt32(txtDepartamento.Text),
                   cmbEstado.Text
                );

            empleado.Insertar();
            Limpiar();
            dataGridView1.DataSource= visualizar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void Limpiar()
        {
            txtCedula.Clear();
            txtDepartamento.Clear();
            txtId.Clear();
            txtNombre.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           int id=int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
           Empleado.Eliminar(id);
           dataGridView1.DataSource = visualizar();
        }

        private DataTable visualizar()
        {

            DataTable table = new DataTable();

            table.Columns.Add("Id");
            table.Columns.Add("Cedula");
            table.Columns.Add("Nombre");
            table.Columns.Add("Departamento");
            table.Columns.Add("Estado");

            foreach (Empleado empleado in Empleado.Select())
            {
                table.Rows.Add(empleado.id, empleado.cedula, empleado.nombre, empleado.departamento, empleado.estado);
            }
            
            return table;

        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource= visualizar();
        }

        private void txtActualizar_Click(object sender, EventArgs e)
        {
            empleado = new Empleado(
                int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()),
                dataGridView1.SelectedRows[0].Cells[1].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells[2].Value.ToString(),
                int.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString()),
                dataGridView1.SelectedRows[0].Cells[4].Value.ToString()
                );

            txtCedula.Text = empleado.cedula;
            txtDepartamento.Text = empleado.departamento.ToString();
            txtId.Text = empleado.id.ToString();
            txtNombre.Text = empleado.nombre;
            cmbEstado.Text = empleado.estado;


        }

        private void btnActualizar2_Click(object sender, EventArgs e)
        {

            empleado = new Empleado
            (
                int.Parse(txtId.Text),
                txtCedula.Text,
                txtNombre.Text,
               int.Parse(txtDepartamento.Text),
                cmbEstado.Text
            );

            empleado.Actualizar();
            dataGridView1.DataSource = visualizar();
        }
    }
}
