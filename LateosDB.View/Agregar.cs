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
    public partial class Agregar : Form
    {
        //private List<Estado> _listado;
        int id = 0;
        public Agregar()
        {
            InitializeComponent();
        }
        public Agregar(Categoria entity)
        {
            InitializeComponent();
            id = entity.IdCategoria;
            textBox2.Text = entity.Nombre;
            textBox3.Text = entity.CantidaCategoria.ToString();
            UpdateCombo();
            comboBox1.SelectedValue = entity.IdEstado;
        }

        private void UpdateCombo()
        {
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdEstado";
            comboBox1.DataSource = EstadoBL.Instance.SellecALL();
        }



        private void Agregar_Load(object sender, EventArgs e)
        {
            //UpdateCombo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Categoria entity = new Categoria()
            {
                IdCategoria = id,
                Nombre = textBox2.Text.Trim(),
                CantidaCategoria = decimal.Parse(textBox3.Text),
                IdEstado = (int)comboBox1.SelectedValue
            };
            if (id == 0)
            {
                if (CategoriaBL.Instance.Insert(entity))
                {
                    MessageBox.Show(this, "Registro se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (CategoriaBL.Instance.Update(entity))
                {
                    MessageBox.Show(this, "Registro se edito con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            this.Close();
        }
    }
}
