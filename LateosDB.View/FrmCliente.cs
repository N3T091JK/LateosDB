﻿using LateosDB.BusinessLogic;
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
    public partial class FrmCliente : Form
    {
        private List<Cliente> _listado;
        public FrmCliente()
        {
            InitializeComponent();
        }
        private void UpdateCombo()
        {
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdEstado";
            comboBox1.DataSource = EstadoBL.Instance.SellecALL();
        }

        private void UpdateGrid()
        {
            _listado = ClienteBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            Id = x.IdCliente,
                            Nombres = x.Nombre,
                            Fecha = x.FechaRegistro,
                            Estado = x.Estado.Nombre

                        };
            dataGridView1.DataSource = query.ToList();
        }
        private void FrmCliente_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            UpdateCombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Cliente entity = new Cliente()
            {
                Nombre = textBox1.Text.Trim(),
                FechaRegistro = dateTimePicker1.Value,
                IdEstado = (int)comboBox1.SelectedValue
            };

            if (ClienteBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {

                int id = (int)dataGridView1.CurrentRow.Cells[2].Value;
                string nombre = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                DateTime Fecha = dateTimePicker1.Value;
                int IdEstado = _listado.FirstOrDefault(x => x.IdCliente.Equals(id)).IdEstado;
                Cliente entity = new Cliente()
                {
                    IdCliente = id,
                    Nombre = nombre,
                    FechaRegistro = Fecha,
                    IdEstado = IdEstado

                };
                FrmEditarCliente frm = new FrmEditarCliente(entity);
                frm.ShowDialog();
                UpdateGrid();
            }

            if (dataGridView1.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                DialogResult dr = MessageBox.Show("Desea eliminar el registro actual?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (ClienteBL.Instance.Delete(id))
                    {
                        MessageBox.Show("Se elimino con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                UpdateGrid();

            }






        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            _listado = ClienteBL.Instance.SellecALL();

            var busqueda = from x in _listado
                           select new
                           {
                               Id = x.IdCliente,
                               Nombre = x.Nombre,
                               Estado = x.Estado.Nombre
                           };
            var query = busqueda.Where(x => x.Nombre.ToLower().Contains(textBox2.Text.ToLower())).ToList();
            dataGridView1.DataSource = query;
        }
    }
}
