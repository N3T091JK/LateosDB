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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LateosDB.View
{
    public partial class FrmRoles : Form
    {
        private List<Rol> _listado;
        public FrmRoles()
        {
            InitializeComponent();
        }

        private void FrmRoles_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            UpdateCombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        private void UpdateGrid()
        {
            _listado = RolBL.Instance.SellecALL();
            var query2 = from x in _listado
                        select new
                        {
                            id = x.IdRol,
                            Nombres = x.Roles,
                            Estados = x.Estado.Nombre

                        };
            dataGridView1.DataSource = query2.ToList();
        }

        private void UpdateCombo()
        {
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdEstado";
            comboBox1.DataSource = EstadoBL.Instance.SellecALL();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            _listado = RolBL.Instance.SellecALL();

            var busqueda = from x in _listado
                           select new
                           {
                               id = x.IdRol,
                               Nombres = x.Roles,
                               Estados = x.Estado.Nombre
                           };
            var query = busqueda.Where(x => x.Nombres.ToLower().Contains(textBox2.Text.ToLower())).ToList();
            dataGridView1.DataSource = query;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Rol entity = new Rol()
            {
                Roles = textBox1.Text.Trim(),
                IdEstado = (int)comboBox1.SelectedValue
            };

            if (RolBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
                textBox1.Text = "";
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
