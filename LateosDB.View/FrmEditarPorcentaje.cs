using LateosDB.BusinessLogic;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.EntitySql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LateosDB.View
{
    public partial class FrmEditarPorcentaje : Form
    {
        int id = 0;
        public FrmEditarPorcentaje()
        {
            InitializeComponent();
        }
        public FrmEditarPorcentaje(Descuento entity)
        {
            InitializeComponent();

            id = entity.IdDescuento;
            textBox1.Text = entity.Nombre;
            decimal.Parse(textBox2.Text);
            entity.Porcentaje = decimal.Parse(textBox2.Text);

            //entity.Porcentaje = decimal.Parse(textBox2.Text);


        }


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Descuento entity = new Descuento()
            {
               IdDescuento = id,
               Nombre = textBox1.Text.Trim(),
                Porcentaje = decimal.Parse(textBox2.Text)
           
            };
            if (id == 0)
            {
                if (DescuentoBL.Instance.Insert(entity))
                {
                    MessageBox.Show(this, "Registro se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (DescuentoBL.Instance.Update(entity))
                {
                    MessageBox.Show(this, "Registro se edito con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            this.Close();
        }
    }
}
