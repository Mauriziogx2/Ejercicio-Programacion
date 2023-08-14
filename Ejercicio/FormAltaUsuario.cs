using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Ejercicio
{
    public partial class FormAltaUsuario : Form
    {
        private Logica logica = new Logica();
        private Persistencia persistencia = new Persistencia();
        public FormAltaUsuario()
        {
            InitializeComponent();
            CargarDatosDesdeArchivo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            FormMenu formMenu = new FormMenu();
            formMenu.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string documento = txtDocumento.Text;


            if (!logica.ValidarCampos(new string[] { nombre, apellido, documento }))
            {
                MessageBox.Show("Completa los campos vacios", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                FormInformacionUsuario formInformacionUsuario = new FormInformacionUsuario(nombre, apellido, documento);
                formInformacionUsuario.ShowDialog();
                if (formInformacionUsuario.DatosCompletos)
                {
                    string[] datosCliente = formInformacionUsuario.ObtenerDatosCliente();
                    persistencia.AgregarDatosCliente(datosCliente);
                    ActualizarDataGridView();
                    GuardarDatosEnArchivo();
                }

            }
        }
        private void FormularioAltaUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            GuardarDatosEnArchivo();
        }
        private void ActualizarDataGridView()
        {
            var datosClientes = persistencia.ObtenerDatosClientes();

            foreach ( var datos in datosClientes)
            {
                dataGridView1.Rows.Add(datos);
            }
        }
        private void CargarDatosDesdeArchivo()
        {
            if (File.Exists("datos.txt"))
            {
                using (StreamReader reader = new StreamReader("datos.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] datos = line.Split('\t');
                        dataGridView1.Rows.Add(datos);
                    }
                }
            }
        }

        private void GuardarDatosEnArchivo()
        {
            using (StreamWriter writer = new StreamWriter("datos.txt"))
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string line = string.Join("\t", row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value.ToString()));
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}
