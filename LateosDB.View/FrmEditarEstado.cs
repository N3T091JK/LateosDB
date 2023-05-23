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
    public partial class FrmEditarEstado : Form
    {
        int id = 0;
        public FrmEditarEstado()
        {
            InitializeComponent();
        }
        public FrmEditarEstado(Estado entity)
        {
            InitializeComponent();
            id = entity.IdEstado;
            textBox1.Text = entity.Nombre;
        }
        private void FrmEditarEstado_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Estado entity = new Estado()
            {
                IdEstado = id,
                Nombre = textBox1.Text.Trim(),
               
            };
            if (id == 0)
            {
                if (EstadoBL.Instance.Insert(entity))
                {
                    MessageBox.Show(this, "Registro se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (EstadoBL.Instance.Update(entity))
                {
                    MessageBox.Show(this, "Registro se edito con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            this.Close();
        
    }
    }
}
