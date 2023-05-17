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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LateosDB.View
{
    public partial class FrmRegistro : Form
    {
        private List<Registro> _listado;
        public FrmRegistro()
        {
            InitializeComponent();
        }

        private void FrmRegistro_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            UpdateComboCLiente();
            UpdateComboEmpleado();
            UpdateComboCompraProducto();
            UpdateComboUsuario();
            UpdateComboFactura();
            UpdateComboRols();
            //UpdateComboEmpresa();

        }

        private void UpdateComboCLiente()
        {
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdCliente";
            comboBox1.DataSource = ClienteBL.Instance.SellecALL();
        }

        private void UpdateComboEmpleado()
        {
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "IdEmpleado";
            comboBox2.DataSource = EmpleadoBL.Instance.SellecALL();
        }

        private void UpdateComboCompraProducto()
        {
            comboBox3.DisplayMember = "MarcaProducto";
            comboBox3.ValueMember = "IdCompraProducto";
            comboBox3.DataSource = CompraProductoBL.Instance.SellecALL();
        }



        private void UpdateComboUsuario()
        {
            comboBox4.DisplayMember = "Nombre";
            comboBox4.ValueMember = "IdUsuario";
            comboBox4.DataSource = UsuarioBL.Instance.SellecALL();
        }

        private void UpdateComboFactura()
        {
            comboBox5.DisplayMember = "MontoTotal";
            comboBox5.ValueMember = "IdFactura";
            comboBox5.DataSource = FacturaBL.Instance.SellecALL();
        }


        private void UpdateComboRols()
        {
            comboBox6.DisplayMember = "Roles";
            comboBox6.ValueMember = "IdRol";
            comboBox6.DataSource = RolBL.Instance.SellecALL();
        }
        //private void UpdateComboEmpresa()
        //{
        //    comboBox7.DisplayMember = "NombreLegal";
        //    comboBox7.ValueMember = "IdEmprresa";
        //    comboBox7.DataSource = EmpresasBL.Instance.SellecALL();
        //}




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

        private void button1_Click(object sender, EventArgs e)
        {
            Registro entity = new Registro()
            {              
                Nombre = textBox1.Text.Trim(),
                IdCliente = (int)comboBox1.SelectedValue,
                IdEmpleado = (int)comboBox2.SelectedValue,
                IdCompraProducto = (int)comboBox3.SelectedValue,
                IdUsuario = (int)comboBox4.SelectedValue,
                IdFactura = (int)comboBox5.SelectedValue,
                IdRol = (int)comboBox6.SelectedValue,
                //IdEmpresa = (int)comboBox7.SelectedValue
            };

            if (RegistroBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }
        }
    }
}
