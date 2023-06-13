using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LateosDB.View
{
    public partial class Cero : Form
    {
        public Cero()
        {
            InitializeComponent();
        }

        private void Cero_Load(object sender, EventArgs e)
        {

        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void cerrarYSalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void rolToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
        }

        private void estadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {
    
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void categoriaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
          
        }

        private void descuentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
      
        }

        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void busquedasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        /*Formularios ya Funcionando y arreglados*/
        private void empresaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmEmpresa frm = new frmEmpresa();
            frm.ShowDialog();
        }

        private void usuarioToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmUsuario frm = new FrmUsuario();
            frm.ShowDialog();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmpleado frm = new FrmEmpleado();
            frm.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCliente frm = new FrmCliente();
            frm.ShowDialog();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDisponible frm = new FrmDisponible();
            frm.ShowDialog();
        }

        private void historialToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmHistorial frm = new FrmHistorial();
            frm.ShowDialog();
        }

        private void comprarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompraProducto frm = new FrmCompraProducto();
            frm.ShowDialog();
        }

        private void categoriaToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            BSCategoria frm = new BSCategoria();
            frm.ShowDialog();
        }

        private void estadoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmEstados frm = new frmEstados();
            frm.ShowDialog();
        }

        private void rolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRoles frm = new FrmRoles();
            frm.ShowDialog();
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInventario frm = new FrmInventario();
            frm.ShowDialog();
        }

        private void compraToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmComprar frm = new frmComprar();
            frm.ShowDialog();
        }
    }
}
