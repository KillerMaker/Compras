using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Compras.Formularios;

namespace Compras
{
    public partial class Form1 : Form
    {
        private FrmEmpleado frmEmpleado;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            frmEmpleado = new FrmEmpleado();
            Hide();
            frmEmpleado.Show();
        }
    }
}
