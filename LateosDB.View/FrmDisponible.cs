using BarcodeLib;
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
    public partial class FrmDisponible : Form
    {
        private List<Producto> _listado1;
        int id = 0;
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
            UpdateGridpeque();
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

        private void UpdateGridpeque()
        {
            _listado1 = ProductoBL.Instance.SellecALL();
            var query = from x in _listado1
                        select new
                        {
                            Nombres = x.Nombre,
                            Precios = x.Precio,
                            Fecha = x.FechaCaducidad

                        };
            dataGridView2.DataSource = query.ToList();
        }

        private void UpdateGrid()
        {
            _listado1 = ProductoBL.Instance.SellecALL();
            var query = from x in _listado1
                        select new
                        {
                            Id = x.IdProducto,
                            Codigos = x.Marca,
                            Nombres = x.Nombre,
                            Descripciones = x.Decripcion,
                            Precios = x.Precio,
                            Fecha = x.FechaCaducidad,
                            Estado = x.Estados.Nombre,
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
                Marca = textBox1.Text.Trim(),
                Nombre = textBox2.Text.Trim(),
                Decripcion = textBox3.Text.Trim(),
                Precio = decimal.Parse(textBox4.Text),
                FechaCaducidad = dateTimePicker1.Value,
                IdEstado = (int)comboBox3.SelectedValue,
                IdCategoria = (int)comboBox1.SelectedValue,

            };
            

            if (ProductoBL.Instance.Insert(entity))
            {
                
                    GenerarCodigo(entity.IdProducto);
                    entity.CodigoBarra = codigoB;
                    ProductoBL.Instance.Update(entity);
                    MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InventarioBL.Instance.Insert(new Inventario()
                    {
                        IdProduto = entity.IdProducto,
                        cantidad = 0
                    });
                    UpdateComboEstado();
                    UpdateComboCategoria();
                    UpdateGrid();
                UpdateGridpeque();
                GenerarCodigo(entity.IdProducto);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox6.Text = "";
                    textBox5.Text = "";
                }
            
        }
    
        //---------------categoria-----------------

       
       

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

       
        string codigoB = "";
        private void GenerarCodigo(int id)
        {
            codigoB = id.ToString().PadLeft(4, '0');

            Barcode bc = new Barcode();
            bc.BackColor = Color.White;
            bc.ForeColor = Color.Black;
            Image img = bc.Encode(TYPE.CODE39, codigoB, Color.Black, Color.White, (int)(pictureBox10.Width * 0.9), (int)(pictureBox10.Height * 0.9));
            pictureBox10.Image = img;
            pictureBox10.Image.Save(@"C:\Users\HOME\Desktop\LateosDB\Producto" + codigoB + ".png");
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloLetras(e);
        }
         private void textBox5_TextChanged(object sender, EventArgs e)
        {
            _listado1 = ProductoBL.Instance.SellecALL();
            var busqueda = from x in _listado1
                        select new
                        {
                            Id = x.IdProducto,
                            Codigos = x.Marca,
                            Nombres = x.Nombre,
                            Descripciones = x.Decripcion,
                            Precios = x.Precio,
                            Fecha = x.FechaCaducidad,
                            Estado = x.Estados.Nombre,
                            Categoria = x.Category.Nombre,

                        };
            var query = busqueda.Where(x => x.Nombres.ToLower().Contains(textBox5.Text.ToLower())).ToList();
            dataGridView1.DataSource = query;
 
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
//            if (dataGridView2.CurrentRow.Cells["Editar"].Selected)
//            {

//                int id = (int)dataGridView2.CurrentRow.Cells[2].Value;
//                string nombre = dataGridView2.CurrentRow.Cells[3].Value.ToString();
//                DateTime Fecha = dateTimePicker1.Value;
//                Cliente entity = new Cliente()
//                {
//                    IdCliente = id,
//                    Nombre = nombre,
//                    FechaRegistro = Fecha,

//                };
//                FrmEditarCliente frm = new FrmEditarCliente(entity);
//                frm.ShowDialog();
//                UpdateGrid();
//            }

//            if (e.ColumnIndex == 0) { 
//            if (dataGridView2.Rows[e.RowIndex].Cells["Eliminar"].Selected)
//            {
//                int id = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["Id"].Value.ToString());
//                DialogResult dr = MessageBox.Show("Desea eliminar el registro actual?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
//                if (dr == DialogResult.Yes)
//                {
//                    if (ProductoBL.Instance.Delete(id))
//                    {
//                        MessageBox.Show("Se elimino con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

//                    }
//                }
//                UpdateComboEstado();
//                UpdateComboCategoria();
//                UpdateGrid();
//                UpdateGridpeque();

//            }
//}
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            _listado1 = ProductoBL.Instance.SellecALL();
            var busqueda = from x in _listado1
                           select new
                           {
                               Nombres = x.Nombre,
                               Precios = x.Precio,
                               Fecha = x.FechaCaducidad
                           };
            var query = busqueda.Where(x => x.Nombres.ToLower().Contains(textBox6.Text.ToLower())).ToList();
            dataGridView2.DataSource = query;

        }
    }
}
