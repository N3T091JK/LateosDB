using Impresor;
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
using static LateosDB.View.FRmVentas;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LateosDB.View
{
    public partial class FrmCompraProducto : Form
    {
        List<Producto> _listado;
        List<DetalleVentas> _Mostrar2;
        List<VentasDetalleGRID> _ventas;
        private static int _idLT;
        public FrmCompraProducto(int IdUsuario = 0)
        {
            InitializeComponent();
            _idLT = IdUsuario;
        }
        private void UpdateData()
        {
            _listado = ProductoBL.Instance.SellecALL();

        }
        int con = 0;
        public class VentasDetalleGRID
        {
            public int IdProducto { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public int Cantidad { get; set; }
            public decimal SubTotal { get; set; }
        }
        private void FrmCompraProducto_Load(object sender, EventArgs e)
        {
            UpdateComboCLiente();
            UpdateComboUsuario();
            UpdateGridDetalleVentas();
            UpdateData();
            _ventas = new List<VentasDetalleGRID>();
            textBox1.Select();
            timer1.Start();
        }
       
        private void UpdateGridDetalleVentas()
        {
            _Mostrar2 = DetallesVentasBL.Instance.SellecALL();
            var query = from x in _Mostrar2
                        select new
                        {
                            Id = x.IdDetalleVenta,
                            Cantidades = x.Cantidad,
                            SUbTotal = x.Subtotal,
                            Producto = x.Producto.Nombre,
                            Fecha = x.Ventas.FechaVenta,
                            Cliente = x.Ventas.IdCliente,
                            Totales = x.Ventas.TotalVenta
                        };
            dataGridView3.DataSource = query.ToList();
        }


        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        //----------------------------------------
        private void UpdateComboCLiente()
        {
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "IdCliente";
            comboBox2.DataSource = ClienteBL.Instance.SellecALL();
        }
        private void UpdateComboUsuario()
        {
            comboBox1.DisplayMember = "Correo";
            comboBox1.ValueMember = "IdUsuario";
            comboBox1.DataSource = UsuarioBL.Instance.SelectAll();
        }


        private void UpdateGrid()
        {
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            if (_ventas.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Desea realizar la compra?", "confirmacion", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    Ventas _venta = new Ventas()
                    {
                        IdCliente = (int)comboBox2.SelectedValue,
                        FechaVenta = DateTime.Now,
                        IdUsuario = (int)comboBox1.SelectedValue,
                        TotalVenta = _ventas.Sum(x => x.SubTotal)

                    };
                    Ticket _ticket = new Ticket();
                    List<DetalleVentas> _detalles = new List<DetalleVentas>();
                    for (int i = 0; i < _ventas.Count; i++)
                    {
                        DetalleVentas _detalle = new DetalleVentas();
                        _detalle.IdProducto = _ventas[i].IdProducto;
                        _detalle.Subtotal = _ventas[i].SubTotal;
                        _detalle.Cantidad = _ventas[i].Cantidad;
                        _detalle.IdVenta = 0;
                        _detalles.Add(_detalle);

                        _ticket.AddItem(_ventas[i].Cantidad.ToString(), _ventas[i].Nombre,
                            _ventas[i].Precio.ToString(), _ventas[i].SubTotal.ToString("C2"));
                    }



                    if (VentaBL.Instance.Insert(_venta, _detalles))
                    {
                        MessageBox.Show("Venta realizada con exito");
                    }
                    _ticket.AddHeaderLine("El Monte de Jehova");
                    _ticket.AddSubHeaderLine("Venta de Lateos de todo tipo");                   
                    _ticket.AddSubHeaderLine("CAJA 1: " + DateTime.Now);
                    _ticket.AddTotal("TOTAL: ", _venta.TotalVenta.ToString("C2"));

                    _ticket.AddFooterLine("Gracias por su compra");
                   
                    _ticket.AddFooterLine("Programacion III");

                    _ticket.PrintTicket();
                    

                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                string codigo = textBox1.Text;
                var query = _listado.FirstOrDefault(x => x.CodigoBarra.Equals(codigo));
                if (query != null)
                {
                    var ingreso = _ventas.FirstOrDefault(x => x.IdProducto.Equals(query.IdProducto));
                    if (ingreso != null)
                    {
                        for (int i = 0; i < _ventas.Count; i++)
                        {
                            if (_ventas[i].IdProducto == query.IdProducto)
                            {
                                _ventas[i].Cantidad = _ventas[i].Cantidad + 1;
                                _ventas[i].SubTotal = _ventas[i].Cantidad * _ventas[i].Precio;
                            }
                        }
                    }
                    else
                    {
                        VentasDetalleGRID entity = new VentasDetalleGRID();
                        entity.IdProducto = query.IdProducto;
                        entity.Precio = query.Precio;
                        entity.Nombre = query.Nombre;
                        entity.Cantidad = 1;
                        entity.SubTotal = entity.Cantidad * entity.Precio;
                        _ventas.Add(entity);
                    }


                    dataGridView1.Refresh();
                    dataGridView1.DataSource = _ventas.ToList();
                }
                con++;
                textBox1.Text = "";
                textBoxTotal.Text = _ventas.Sum(x => x.SubTotal).ToString();
                textBox2.Text = _ventas.Sum(x => x.Cantidad).ToString();


            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
