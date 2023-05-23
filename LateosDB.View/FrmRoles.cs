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

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //**********************MOSTRAR EL DATAGRID*******************************
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
        //----------------------------------------------------------------------

        //**********************BUSCAR**********************************
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
        //----------------------------------------------------------------------
       

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
            //**********************BOTON DE ENVIAR A OTRO FORMULARIO************************
        private void button3_Click(object sender, EventArgs e)
        {
            EditarRol frm = new EditarRol();
            frm.ShowDialog();
            UpdateGrid();
        }
        //----------------------------------------------------------------------

        //**********************PARA AGREGAR LOS BOTONES DE EDITAR Y ELIMINAR************************
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //**********************EDITAR************************
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells[2].Value;
                string nombre = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                int estadoId = _listado.FirstOrDefault(x => x.IdRol.Equals(id)).IdEstado;

                Rol entity = new Rol()
                {
                    IdRol = id,
                    Roles = nombre,
                    IdEstado = estadoId
                };

                EditarRol frm = new EditarRol(entity);
                frm.ShowDialog();
                UpdateGrid();


            }
            //**********************ELIMINAR************************
            if (dataGridView1.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                DialogResult dr = MessageBox.Show("Desea eliminar el registro actual?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (RolBL.Instance.Delete(id))
                    {
                        MessageBox.Show("Se elimino con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                }
                UpdateGrid();
            }


        }
            
    }
}
