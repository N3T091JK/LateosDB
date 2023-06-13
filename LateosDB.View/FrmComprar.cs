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
    public partial class frmComprar : Form
    {

        public frmComprar()
        {
            InitializeComponent();
        }
        List<Producto> _listado;
        List<ComprarDGRIP> _ventas;
        private static int _idLT;
        List<Compra> _listadoC;
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        public class ComprarDGRIP
        {
            public int IdProducto { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public int Cantidad { get; set; }
            public decimal SubTotal { get; set; }
        }
        private void frmComprar_Load(object sender, EventArgs e)
        {
            UpdateData();
            _ventas = new List<ComprarDGRIP>();
            textBox1.Select();
            timer1.Start();
        }
        private void UpdateData()
        {
            _listado = ProductoBL.Instance.SellecALL();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_ventas.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Desea realizar la compra?", "confirmacion", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ComprarProducto _venta = new ComprarProducto()
                    {                   
                        Fecha = DateTime.Now,
                        TotalesRealizadas = _ventas.Sum(x => x.SubTotal)

                    };
                    List<Compra> _detalles = new List<Compra>();
                    for (int i = 0; i < _ventas.Count; i++)
                    {
                        Compra _detalle = new Compra();
                        _detalle.IdProducto = _ventas[i].IdProducto;
                        _detalle.Subtotal = _ventas[i].SubTotal;
                        _detalle.Cantidad = _ventas[i].Cantidad;
                        _detalle.IdCPComprar = 0;
                        _detalles.Add(_detalle);

                    }



                    if (ComprarProductoBL.Instance.Insert(_venta, _detalles))
                    {
                        MessageBox.Show("Venta realizada con exito");
                    }
                }
            }



        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        int con = 0;
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
                        ComprarDGRIP entity = new ComprarDGRIP();
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
                textTotalesComprar.Text = _ventas.Sum(x => x.SubTotal).ToString();
                textBox2.Text = _ventas.Sum(x => x.Cantidad).ToString();
            }

        }
    }
}
