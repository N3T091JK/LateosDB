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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LateosDB.View
{
    public partial class FrmLog : Form
    {
        private List<Log> _listado;
        public FrmLog()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmLog_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            _listado = LogBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            Id = x.logId,
                            Fechas = x.Fecha,
                            Usuarios = x.Usuario,
                            Tablas = x.Password,
                            Acciones = x.Accion,                         
                            Descripciones = x.Descripcion
                        };
            //dataGridView1.DataSource = query.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
                Log entity = new Log()
            {
                Fecha = dateTimePicker1.Value,
                Usuario = textBox1.Text.Trim(),
                Password = textBox2.Text.Trim(),
                Accion = textBox3.Text.Trim(),
                Descripcion = textBox4.Text.Trim(),

            };

            if (LogBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
