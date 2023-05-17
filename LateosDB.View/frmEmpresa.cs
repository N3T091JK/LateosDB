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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LateosDB.View
{
    public partial class frmEmpresa : Form
    {
        private List<Empresa> _listado;
        public frmEmpresa()
        {
            InitializeComponent();
        }

        private void frmEmpresa_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            _listado = EmpresasBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            Id = x.IdEmpresa,
                            Nombre = x.NombreComercial,
                            NombreLega = x.NombreLegal,
                            Direccions = x.Direccion,
                            Telefonos = x.Telefono,
                            Emails = x.Email,
                            Rubros = x.Rubro
                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Empresa entity = new Empresa()
            {
                //Cambiar a string Telefono
                NombreComercial = textBox1.Text.Trim(),
                NombreLegal = textBox2.Text.Trim(),
                Direccion = textBox3.Text.Trim(),               
                Telefono = textBox4.Text.Trim(),
                Email = textBox5.Text.Trim(),
                Rubro = textBox6.Text.Trim(),
            };

            if (EmpresasBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
