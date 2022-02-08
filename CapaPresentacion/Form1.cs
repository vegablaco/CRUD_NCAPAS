using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CN_Productos object_CN = new CN_Productos();
        private string idProducto = null;
        private bool edit = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowProducts();
        }

        private void ShowProducts()
        {
            CN_Productos objecto = new CN_Productos();
            dataGridView1.DataSource = objecto.ShowProducts();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if(edit == false)
            {
                try
                {
                    object_CN.InsertProducts(txtName.Text, txtDescription.Text, txtMark.Text, txtPrice.Text, txtStock.Text);
                    MessageBox.Show("Se insertaron los datos de manera correcta");
                    ShowProducts();
                    cleanTextBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudieron insertar los datos" + ex);
                }

            }

            //EDITAR
            if(edit == true)
            {
                try
                {
                    object_CN.EditProducts(idProducto, txtName.Text, txtDescription.Text, txtMark.Text, txtPrice.Text, txtStock.Text);
                    MessageBox.Show("Se actualizaron los datos de manera correcta");
                    ShowProducts();
                    cleanTextBox();
                    edit = false;

                } catch(Exception ex)
                {
                    MessageBox.Show("No se pudieron actaulizar los datos" + ex);
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                edit = true;
                txtName.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtDescription.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtMark.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                txtPrice.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();


            } else
            {
                MessageBox.Show("Seleccione una fila a editar");
            }
        }


        private void cleanTextBox()
        {
            txtName.Clear();
            txtDescription.Clear();
            txtMark.Clear();
            txtPrice.Clear();
            txtStock.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                object_CN.DeleteProducts(idProducto);
                ShowProducts();
            }
            else
            {
                MessageBox.Show("Seleccione una fila a eliminar");
            }
        }
    }
}
