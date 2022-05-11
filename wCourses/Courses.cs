using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace wCourses
{ 
    public partial class frmHijo : Form
    {
        public frmHijo()
        {
            InitializeComponent();

            cmbRH.Items.Add("O-");
            cmbRH.Items.Add("O+");
            cmbRH.Items.Add("A-");
            cmbRH.Items.Add("A+");
            cmbRH.Items.Add("B-");
            cmbRH.Items.Add("B+");
            cmbRH.Items.Add("AB-");
            cmbRH.Items.Add("AB+");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var clsDate = new clsDate();

            clsDate.Nombre = txtNombre.Text;
            clsDate.Apellido = txtApellido.Text;
            clsDate.Direccion = txtDireccion.Text;
            clsDate.Ciudad = txtCuidad.Text;
            clsDate.Comuna = txtComuna.Text;
            clsDate.Telefono = txtTelefono.Text;
            clsDate.RH = cmbRH.Text;

            MessageBox.Show($"Servicio de información\r\r\r Datos Personales: \r\r Nombre: {clsDate.Nombre} \r Apellido: {clsDate.Apellido} \r Direccion: {clsDate.Direccion} \r Ciudad: {clsDate.Ciudad} \r Telefono: {clsDate.Telefono} \r Tipo de sangre: {clsDate.RH}\r\r\r");
        }


        private Stream stream;
        int contador = 0;
        String Linea;
        private void btnCargar_Click(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn columna1 = new DataGridViewTextBoxColumn();
            columna1.HeaderText = "Codigo curso";
            columna1.Width = 60;
            columna1.ReadOnly = true; 
            dtgCVS.Columns.Add(columna1);

            DataGridViewTextBoxColumn columna2 = new DataGridViewTextBoxColumn();
            columna2.HeaderText = "Nombre curso";
            columna2.Width = 160;
            columna2.ReadOnly = true;
            dtgCVS.Columns.Add(columna2);

            DataGridViewTextBoxColumn columna3 = new DataGridViewTextBoxColumn();
            columna3.HeaderText = "Categoria curso";
            columna3.Width = 130;
            columna3.ReadOnly = true;
            dtgCVS.Columns.Add(columna3);

            DataGridViewTextBoxColumn colmna4 = new DataGridViewTextBoxColumn();
            colmna4.HeaderText = "Tema";
            colmna4.Width = 225;
            colmna4.ReadOnly = true;
            dtgCVS.Columns.Add(colmna4);

            DataGridViewTextBoxColumn columna5 = new DataGridViewTextBoxColumn();
            columna5.HeaderText = "Observaciones";
            columna5.Width = 410;
            columna5.ReadOnly = true;
            dtgCVS.Columns.Add(columna5);

            char delimitador = ';';
            string[] valores;


            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "Archivos (*.CSV) | *.CSV";

            if ((openFileDialog.ShowDialog()) == DialogResult.OK)
                try
                {
                    if ((stream = openFileDialog.OpenFile()) != null)
                    {
                        System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog.FileName);

                        while ((Linea = file.ReadLine()) != null)
                        {
                            if (contador >= 1)
                            {
                                valores = Linea.Split(delimitador);

                                dtgCVS.Rows.Add(valores.ToArray());
                                contador++;
                            }
                            else
                            {
                                contador++;
                            }
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
