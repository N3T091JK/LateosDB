﻿using LateosDB.BusinessLogic;
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
    public partial class FrmEmpleado : Form
    {
        private List<Empleado> _listado;
        public FrmEmpleado()
        {
            InitializeComponent();
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            UpdateCombo();
        }
        private void UpdateCombo()
        {
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdEstado";
            comboBox1.DataSource = EstadoBL.Instance.SellecALL();
        }
        private void UpdateGrid()
        {
            _listado = EmpleadoBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            Id = x.IdEmpleado,
                            Nombres = x.Nombre,
                            Apellid = x.Apellido,
                            Direccio = x.Direccion,
                            Fecha = x.FechaRegistro,
                            Estado = x.Estado.Nombre

                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {



            _listado = EmpleadoBL.Instance.SellecALL();

            var busqueda = from x in _listado
                           select new
                           {
                               Id = x.IdEmpleado,
                               Nombres = x.Nombre,
                               Apellid = x.Apellido,
                               Direccio = x.Direccion,
                               Fecha = x.FechaRegistro,
                               Estado = x.Estado.Nombre
                           };
            var query = busqueda.Where(x => x.Nombres.ToLower().Contains(textBox4.Text.ToLower())).ToList();
            dataGridView1.DataSource = query;
        }

        private void button3_Click(object sender, EventArgs e)
        {
                Empleado entity = new Empleado()
            {
                Nombre = textBox1.Text.Trim(),
               Apellido = textBox2.Text.Trim(),
                Direccion = textBox3.Text.Trim(),
                FechaRegistro = dateTimePicker1.Value,
                IdEstado = (int)comboBox1.SelectedValue
            };

            if (EmpleadoBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
              
                int id = (int)dataGridView1.CurrentRow.Cells[2].Value;
                string nombre = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string apellido = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                string Direccion = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                DateTime Fecha = dateTimePicker1.Value;
                int IdEstado = _listado.FirstOrDefault(x => x.IdEmpleado.Equals(id)).IdEstado;
                Empleado entity = new Empleado()
                {
                    IdEmpleado = id,
                    Nombre = nombre,
                    Apellido = apellido,
                    Direccion = Direccion,
                    FechaRegistro = Fecha,
                    IdEstado = IdEstado

                };
                FrmEditarEmpleado frm = new FrmEditarEmpleado(entity);
                frm.ShowDialog();
                UpdateGrid();
            }

            if (dataGridView1.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                DialogResult dr = MessageBox.Show("Desea eliminar el registro actual?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (EmpleadoBL.Instance.Delete(id))
                    {
                        MessageBox.Show("Se elimino con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                UpdateGrid();

            }
        }







    }
}
