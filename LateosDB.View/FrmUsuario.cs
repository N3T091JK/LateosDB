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
    public partial class FrmUsuario : Form
    {
        private List<Usuario> _listado;
        public FrmUsuario()
        {
            InitializeComponent();
        }
        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            UpdateCombo();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void UpdateCombo()
        {
            comboBox1.DisplayMember = "Roles";
            comboBox1.ValueMember = "IdRol";
            comboBox1.DataSource = RolBL.Instance.SellecALL();
        }
        private void UpdateGrid()
        {
            _listado = UsuarioBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            Id = x.IdUsuario,
                            Nombres = x.Nombre,
                            correos = x.Correo,
                            Claves = x.Clave,
                            //Eliminar cantidad de entities
                            //cantidade = x.cantidades,
                            Rolt = x.Rols.Roles

                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            _listado = UsuarioBL.Instance.SellecALL();

            var busqueda = from x in _listado
                           select new
                           {
                               Id = x.IdUsuario,
                               Nombres = x.Nombre,
                               correos = x.Correo,
                               Claves = x.Clave,
                               //Eliminar cantidad de entities
                               //cantidade = x.cantidades,
                               Rolt = x.Rols.Roles
                           };
            var query = busqueda.Where(x => x.Nombres.ToLower().Contains(textBox4.Text.ToLower())).ToList();
            dataGridView1.DataSource = query;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Usuario entity = new Usuario()
            {
                Nombre = textBox1.Text.Trim(),
                Correo = textBox3.Text.Trim(),
                Clave = textBox2.Text.Trim(),
                IdRol = (int)comboBox1.SelectedValue
            };

            if (UsuarioBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }
    }
}
