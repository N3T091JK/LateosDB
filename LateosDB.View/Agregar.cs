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
    public partial class Agregar : Form
    {
        //private List<Estado> _listado;
        
        public Agregar()
        {
            InitializeComponent();
        }

        //private void UpdateCombo()
        //{
        //    comboBox1.DisplayMember = "Nombre";
        //    comboBox1.ValueMember = "EstadoId";
        //    comboBox1.DataSource = EstadoBL.Instance.SellecALL();
        //}


        private void button1_Click(object sender, EventArgs e)
        {
            Estado entity = new Estado()
            {
                Nombre = textBox1.Text.Trim(),
                //IdEstado = (int)comboBox1.SelectedValue

            };

            if (EstadoBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void Agregar_Load(object sender, EventArgs e)
        {
            //UpdateCombo();
        }
    }
}
