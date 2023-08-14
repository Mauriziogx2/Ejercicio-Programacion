using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio
{
    public partial class FormInformacionUsuario : Form
    {
        public bool DatosCompletos { get; set; }
        private string[] datosCliente = new string[7];
        private Logica logica = new Logica();
        private Persistencia persistencia = new Persistencia();
        

        public FormInformacionUsuario(string nombre, string apellido, string documento)
        {
            InitializeComponent();
            datosCliente[0] = nombre;
            datosCliente[1] = apellido;
            datosCliente[2] = documento;
        }

        public FormInformacionUsuario()
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            Hide();
            FormAltaUsuario formAltaUsuario = new FormAltaUsuario();  
            formAltaUsuario.ShowDialog();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        { 
            string telefono = txtTelefono.Text;
            string correo = txtCorreo.Text;
            string calle = txtCalle.Text;
            string puerta = txtPuerta.Text;

            if (logica.ValidarCampos(new string[] { telefono, correo, calle, puerta}))
            {
                
                MessageBox.Show("Valores ingresados correctamente");
                this.Hide();
                datosCliente[3] = telefono;
                datosCliente[4] = correo;
                datosCliente[5] = calle;
                datosCliente[6] = puerta;
                DatosCompletos = true;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Completa los campos vacios", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public string[] ObtenerDatosCliente()
        {
            return datosCliente;
        }
        

    }
    
}
