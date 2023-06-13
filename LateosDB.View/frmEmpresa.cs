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
        int id = 0;  
        private List<Empresas> _listado;
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
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
                Empresas entity = new Empresas()
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //**********************EDITAR************************
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells[2].Value;
                string NombreComercial = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string NombreLegal = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                string Direccion = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                string Telefono = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                string Email = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                string Rubro = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                Empresas entity = new Empresas()
                {
                    IdEmpresa = id,
                    NombreComercial = NombreComercial,
                    NombreLegal = NombreLegal,
                    Direccion = Direccion,
                    Telefono = Telefono,
                    Email = Email,
                    Rubro = Rubro
                };
               
                FrmEditarEmpresa frm = new FrmEditarEmpresa(entity);
                frm.ShowDialog();
                UpdateGrid();
 }
                //**********************ELIMINAR************************
                if (dataGridView1.Rows[e.RowIndex].Cells["Eliminar"].Selected)
                {
                    int Id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                    DialogResult dr = MessageBox.Show("Desea eliminar el registro actual?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        if (EmpresasBL.Instance.Delete(Id))
                        
                        MessageBox.Show("Se elimino con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
               
                UpdateGrid();
            }



        }
    }
}
