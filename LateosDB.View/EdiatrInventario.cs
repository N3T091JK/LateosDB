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
    public partial class EdiatrInventario : Form
    {
        int IdInventarioss = 0;
        public EdiatrInventario()
        {
            InitializeComponent();

        }
        private void UpdateCombo()
        {
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdProduto";
            comboBox1.DataSource = ProductoBL.Instance.SellecALL();
        }
        public EdiatrInventario(Inventario entity)
        {
            InitializeComponent();
            IdInventarioss = entity.IdInventario;
           textBox1.Text = entity.cantidad.ToString();

            UpdateCombo();
            comboBox1.SelectedValue = entity.IdProduto;
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Inventario entity = new Inventario()
            {
                IdInventario = IdInventarioss,
                cantidad = Convert.ToInt32(textBox1.Text),
                //cantidad = Convert.ToInt32(numericUpDown1.Value),
                IdProduto = (int)comboBox1.SelectedValue
            };
            if (IdInventarioss == 0)
            {
                if (InventarioBL.Instance.Insert(entity))
                {
                    MessageBox.Show(this, "Registro se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (InventarioBL.Instance.Update(entity))
                {
                    MessageBox.Show(this, "Registro se edito con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            this.Close();
        }
    }
}
