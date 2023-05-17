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
    public partial class FrmProducto : Form
    {
        private List<Producto> _listado;
        public FrmProducto()
        {
            InitializeComponent();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            UpdateComboEstado();
            UpdateComboCategoria();
          
        }
        private void UpdateComboEstado()
        {
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdEstado";
            comboBox1.DataSource = EstadoBL.Instance.SellecALL();
        }

        private void UpdateComboCategoria()
        {
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "IdCategoria";
            comboBox2.DataSource = CategoriaBL.Instance.SellecALL();
        }



        private void UpdateGrid()
        {
            _listado = ProductoBL.Instance.SellecALL();
            var query = from x in _listado
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

        private void button1_Click(object sender, EventArgs e)
        {
            Producto entity = new Producto()
            {
                Codigo = textBox1.Text.Trim(),
                Nombre = textBox2.Text.Trim(),
                Decripcion = textBox3.Text.Trim(),
                Precio = decimal.Parse(textBox4.Text),
                FechaCaducidad = dateTimePicker1.Value,
                IdEstado = (int)comboBox1.SelectedValue,
                IdCategoria = (int)comboBox2.SelectedValue,
                
            };

            if (ProductoBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }
        }
    }
}
