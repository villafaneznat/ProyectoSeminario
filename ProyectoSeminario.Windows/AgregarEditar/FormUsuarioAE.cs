using ProyectoSeminario.Entidades;
using ProyectoSeminario.Servicios.Interfaces;
using ProyectoSeminario.Servicios.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSeminario.Windows.AgregarEditar
{
    public partial class FormUsuarioAE : Form
    {
        private readonly IServicioUsuarios _servicioUsuarios;

        private Usuario user;

        private bool esEdicion = false;

        public FormUsuarioAE()
        {
            InitializeComponent();
        }

        public FormUsuarioAE(IServicioUsuarios servicio) : this()
        {
            _servicioUsuarios = servicio;
        }

        public FormUsuarioAE(IServicioUsuarios servicio, Usuario u, bool edicion) : this(servicio)
        {
            user = u;
            esEdicion = edicion;
        }

        private void GuardarBtn_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (user == null)
                {
                    user = new Usuario();
                }
                //profesional.Nombre = txtNombreProfesional.Text;
                //profesional.Apellido = txtApellidoProfesional.Text;
                //profesional.DNI = int.Parse(txtDNIProfesional.Text);
                //profesional.NroMatricula = int.Parse(txtMatriculaProfesional.Text);
                //profesional.Profesiones = ObtenerProfesiones();
                //profesional.Firma = ObtenerFirma();
                try
                {

                    if (!_servicioUsuarios.Existe(user))
                    {
                        _servicioUsuarios.Guardar(user);

                        if (!esEdicion)
                        {
                            MessageBox.Show("Registro agregado",
                        "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult dr = MessageBox.Show("¿Desea agregar otro registro?",
                                "Pregunta",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2);
                            if (dr == DialogResult.No)
                            {
                                DialogResult = DialogResult.OK;

                            }
                            user = null;
                            //InicializarControles();

                        }
                        else
                        {
                            MessageBox.Show("Registro editado", "Mensaje",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Registro duplicado",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        user = null;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
