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
    public partial class frmEstados : Form
    {
        private List<Estado> _listado;
        public frmEstados()
        {
            InitializeComponent();
        }

        private void frmEstados_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void UpdateGrid()
        {
            _listado = EstadoBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            Id = x.IdEstado,
                            Nombres = x.Nombre
                            
                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            _listado = EstadoBL.Instance.SellecALL();

            var busqueda = from x in _listado
                           select new
                           {
                               Id = x.IdEstado,
                               Nombres = x.Nombre
                           };
            var query = busqueda.Where(x => x.Nombres.ToLower().Contains(textBox2.Text.ToLower())).ToList();
            dataGridView1.DataSource = query;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Estado entity = new Estado()
            {
                Nombre = textBox1.Text.Trim(),
            };

            if (EstadoBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
                textBox1.Text = "";
            }
        }
    }
}
