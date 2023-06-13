using LateosDB.BusinessLogic;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Impresor;
using static LateosDB.View.FRmVentas;

namespace LateosDB.View
{
    public partial class FRmVentas : Form
    {
        List<Producto> _listado;
        List<VentasDetalleGRID> _ventas;
        private static int _idLT;
        public FRmVentas(int IdUsuario = 0)
        {
            InitializeComponent();
            _idLT = IdUsuario;
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            UpdateData();
            _ventas = new List<VentasDetalleGRID>();
            textBox1.Select();
            timer1.Start();
         
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
                if (_ventas.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Desea realizar la compra?", "confirmacion", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    Ventas _venta = new Ventas()
                    {
                        IdCliente = 2,
                        FechaVenta = DateTime.Now,
                        IdUsuario = 6,
                        TotalVenta = _ventas.Sum(x => x.SubTotal)

                    };
                    List<DetalleVentas> _detalles = new List<DetalleVentas>();
                    for (int i = 0; i < _ventas.Count; i++)
                    {
                        DetalleVentas _detalle = new DetalleVentas();
                        _detalle.IdProducto = _ventas[i].IdProducto;
                        _detalle.Subtotal = _ventas[i].SubTotal;
                        _detalle.Cantidad = _ventas[i].Cantidad;
                        _detalle.IdVenta = 0;
                        _detalles.Add(_detalle);

                    }



                    if (VentaBL.Instance.Insert(_venta, _detalles))
                    {
                        MessageBox.Show("Venta realizada con exito");
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
