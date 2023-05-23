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
    public partial class FrmFactura : Form
    {
        private List<Factura> _listado;
        public FrmFactura()
        {
            InitializeComponent();
        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            UpdateComboCliente();
            UpdateComboUsuario();
            UpdateComboDetalleFactura();
            UpdateGrid();

        }

        private void UpdateComboCliente()
        {
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdCliente";
            comboBox1.DataSource = ClienteBL.Instance.SellecALL();
        }
        private void UpdateComboUsuario()
        {
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "IdUsuario";
            comboBox2.DataSource = UsuarioBL.Instance.SellecALL();
        }
        private void UpdateComboDetalleFactura()
        {
            comboBox3.DisplayMember = "subTotal";
            comboBox3.ValueMember = "IdDetalleFactura";
            comboBox3.DataSource = DetalleFacturaBL.Instance.SellecALL();
        }

        private void UpdateGrid()
        {
            _listado = FacturaBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            Id = x.IdFactura,
                            codigos = x.Codigo,
                            Monto = x.MontoPago,
                            MotoTotales = x.MontoTotal,
                      
                            Oservaciones = x.Observacion,
                            Fecha = x.FechaRegistro,
                            Cliente = x.Clientes.Nombre,
                            Usuario = x.Usuarios.Nombre,
                           
                        };
            dataGridView1.DataSource = query.ToList();
        }





        private void button1_Click(object sender, EventArgs e)
        {
            Factura entity = new Factura()
            {
                MontoPago = decimal.Parse(textBox1.Text),
                MontoTotal = decimal.Parse(textBox2.Text),
       
                Observacion = textBox4.Text.Trim(),
                Codigo = textBox5.Text.Trim(),
                FechaRegistro = dateTimePicker1.Value,
                IdCliente = (int)comboBox1.SelectedValue,
                IdUsuario = (int)comboBox2.SelectedValue,

            };

            if (FacturaBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }
        }






    }
}
