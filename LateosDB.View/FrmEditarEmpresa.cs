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
    public partial class FrmEditarEmpresa : Form
    {
        int idEM = 0;
        public FrmEditarEmpresa()
        {
            InitializeComponent();
        }
        public FrmEditarEmpresa(Empresas entity)
        {
            InitializeComponent();
            idEM = entity.IdEmpresa;
            textBox1.Text = entity.NombreComercial;
            textBox2.Text = entity.NombreLegal;
            textBox3.Text = entity.Direccion;
            textBox4.Text = entity.Telefono;
            textBox5.Text = entity.Email;
            textBox6.Text = entity.Rubro;

        }
        private void FrmEditarEmpresa_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
             Empresas entity = new Empresas()
            {
                 IdEmpresa = idEM,
                NombreComercial = textBox1.Text.Trim(),
                NombreLegal = textBox2.Text.Trim(),
                Direccion = textBox3.Text.Trim(),
                Telefono = textBox4.Text.Trim(),
                Email = textBox5.Text.Trim(),
                Rubro = textBox6.Text.Trim()
            };
            if (idEM == 0)
            {
                if (EmpresasBL.Instance.Insert(entity))
                {
                    MessageBox.Show(this, "Registro se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (EmpresasBL.Instance.Update(entity))
                {
                    MessageBox.Show(this, "Registro se edito con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
              
        }
    }
}
