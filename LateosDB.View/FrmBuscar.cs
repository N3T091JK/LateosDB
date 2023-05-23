using LateosDB.BusinessLogic;
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
    public partial class FrmBuscar : Form
    {
        private List<Registro> _listado;
        public FrmBuscar()
        {
            InitializeComponent();
        }

        private void FrmBuscar_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }


        private void UpdateGrid()
        {
            _listado = RegistroBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            Id = x.IdRegistro,
                            Nombres = x.Nombre,
                            Clientes = x.Cliente.Nombre,
                            Empleados = x.Empleado.Nombre,
                            ComprarProducto = x.CompraProductos.MarcaProducto,
                            Usuario = x.Usuarios.Nombre,
                            Factura = x.Facturas.MontoTotal,
                            Role = x.Rols.Roles,
                            //Empresas = x.Empresa.NombreLegal


                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
