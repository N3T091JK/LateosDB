using LateosDB.BusinessLogic;
using LateosDB.DataAccess;
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
    public partial class FrmDisponible : Form
    {
        private List<Producto> _listado1;
        private List<CompraProducto> _listado2;

        Validardatos val = new Validardatos();
        public FrmDisponible()
        {
            InitializeComponent();
        }

        private void FrmDisponible_Load(object sender, EventArgs e)
        {
            UpdateComboEstado();
            UpdateComboCategoria();
            UpdateGrid();

        }
        private void UpdateComboEstado()
        {
            comboBox3.DisplayMember = "Nombre";
            comboBox3.ValueMember = "IdEstado";
            comboBox3.DataSource = EstadoBL.Instance.SellecALL();
        }

        private void UpdateComboCategoria()
        {
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdCategoria";
            comboBox1.DataSource = CategoriaBL.Instance.SellecALL();
        }



        private void UpdateGrid()
        {
            _listado1 = ProductoBL.Instance.SellecALL();
            var query = from x in _listado1
                        select new
                        {
                            Id = x.IdProducto,
                            Codigos = x.Codigo,
                            Nombres = x.Nombre,
                            Descripciones = x.Decripcion,
                            Precios = x.Precio,
                            Fecha = x.FechaCaducidad,
                            Estado = x.Estado.Nombre,
                            Categoria = x.Category.Nombre,

                        };
            dataGridView1.DataSource = query.ToList();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Producto entity = new Producto()
            {
                Codigo = textBox1.Text.Trim(),
                Nombre = textBox2.Text.Trim(),
                Decripcion = textBox3.Text.Trim(),
                Precio = decimal.Parse(textBox4.Text),
                FechaCaducidad = dateTimePicker1.Value,
                IdEstado = (int)comboBox3.SelectedValue,
                IdCategoria = (int)comboBox1.SelectedValue,

            };
            CompraProducto Variable = new CompraProducto()
            {

                MarcaProducto = textBox6.Text.Trim(),
                Cantidad = Convert.ToInt32(numericUpDown1.Value),
                FechaRegistro = dateTimePicker2.Value

            };

            if (ProductoBL.Instance.Insert(entity))
            {
                if (CompraProductoBL.Instance.Insert(Variable))
                {
                    MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateComboEstado();
                    UpdateComboCategoria();
                    UpdateGrid();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox6.Text = "";
                    textBox5.Text = "";
                }
            }
        }
    
        //---------------categoria-----------------

       
       

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            _listado1 = ProductoBL.Instance.SellecALL();
            var busqueda = from x in _listado1
                        select new
                        {
                            Id = x.IdProducto,
                            Codigos = x.Codigo,
                            Nombres = x.Nombre,
                            Descripciones = x.Decripcion,
                            Precios = x.Precio,
                            Fecha = x.FechaCaducidad,
                            Estado = x.Estado.Nombre,
                            Categoria = x.Category.Nombre,

                        };
            var query = busqueda.Where(x => x.Nombres.ToLower().Contains(textBox5.Text.ToLower())).ToList();
            dataGridView1.DataSource = query;
 
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloLetras(e);
        }
    }
}
