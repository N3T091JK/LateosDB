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
    public partial class FrmComprar : Form
    {
        private List<Factura> _listado1;
        private List<DetalleFactura> _listado2;       
        public FrmComprar()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmComprar_Load(object sender, EventArgs e)
        {
            UpdateComboCliente();
            UpdateComboUsuario();
            UpdateComboDetalleFactura();
            UpdateGridDetallesFacturas();
            UpdateGrid();
            UpdateComboProducto();
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
            comboBox4.DisplayMember = "subTotal";
            comboBox4.ValueMember = "IdDetalleFactura";
            comboBox4.DataSource = DetalleFacturaBL.Instance.SellecALL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FacturaImprimir();
          

        }



        private void UpdateComboProducto()
        {
            comboBox3.DisplayMember = "Nombre";
            comboBox3.ValueMember = "IdProducto";
            comboBox3.DataSource = ProductoBL.Instance.SellecALL();
        }






        private void FacturaImprimir()
        {
                Factura entity = new Factura()
            {
                MontoPago = decimal.Parse(textBox2.Text),
                MontoTotal = decimal.Parse(MontoTotalText.Text),
                Descuento = decimal.Parse(DescuentoText.Text),
                Observacion = textBox5.Text.Trim(),
                Codigo = textBox6.Text.Trim(),
                FechaRegistro = dateTimePicker1.Value,
                IdCliente = (int)comboBox1.SelectedValue,
                IdUsuario = (int)comboBox2.SelectedValue,
                IdDetalleFactura = (int)comboBox4.SelectedValue
            };

            if (FacturaBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateComboCliente();
                UpdateComboUsuario();
                UpdateComboDetalleFactura();
                UpdateGridDetallesFacturas();
                UpdateGrid();
                UpdateComboProducto();
                textBox1.Text = "";
                textBox2.Text = "";
                MontoTotalText.Text = "";
                DescuentoText.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";    
            }


        }
        private void DetallesFacturaImprimir()
        {

                DetalleFactura entity = new DetalleFactura()
            {

                subTotal = decimal.Parse(textBox7.Text),
                Cantidad = Convert.ToInt32(numericUpDown2.Value),
                IdProducto = (int)comboBox3.SelectedValue,

            };

            if (DetalleFacturaBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateComboCliente();
                UpdateComboUsuario();
                UpdateComboDetalleFactura();
                UpdateGridDetallesFacturas();
                UpdateGrid();
                UpdateComboProducto();
                textBox1.Text = "";
                textBox2.Text = "";
                MontoTotalText.Text = "";
                DescuentoText.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DetallesFacturaImprimir();
        }


        private void UpdateGridDetallesFacturas()
        {
            _listado2 = DetalleFacturaBL.Instance.SellecALL();
            var query = from x in _listado2
                        select new
                        {
                            Id = x.IdDetalleFactura,
                            cantidad = x.Cantidad,
                            subTotales = x.subTotal,
                            Productos = x.Productos.Nombre

                        };
            dataGridView2.DataSource = query.ToList();
        }
        private void UpdateGrid()
        {
            _listado1 = FacturaBL.Instance.SellecALL();
            var query = from x in _listado1
                        select new
                        {
                            Id = x.IdFactura,
                            codigos = x.Codigo,
                            Monto = x.MontoPago,
                            MotoTotales = x.MontoTotal,
                            Descuentos = x.Descuento,
                            Oservaciones = x.Observacion,
                            Fecha = x.FechaRegistro,
                            Cliente = x.Clientes.Nombre,
                            Usuario = x.Usuarios.Nombre,
                            DetalleFactura = x.DetalleFactura.subTotal
                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
        
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
     
        }

        private void DescuentoText_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void MontoTotalText_KeyPress(object sender, KeyPressEventArgs e)
        {
        
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _listado1 = FacturaBL.Instance.SellecALL();
            var busqueda = from x in _listado1
                        select new
                        {
                            Id = x.IdFactura,
                            codigos = x.Codigo,
                            Monto = x.MontoPago,
                            MotoTotales = x.MontoTotal,
                            Descuentos = x.Descuento,
                            Oservaciones = x.Observacion,
                            Fecha = x.FechaRegistro,
                            Cliente = x.Clientes.Nombre,
                            Usuario = x.Usuarios.Nombre,
                            DetalleFactura = x.DetalleFactura.subTotal
                        };
            var query = busqueda.Where(x => x.codigos.ToLower().Contains(textBox1.Text.ToLower())).ToList();
            dataGridView1.DataSource = query;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
