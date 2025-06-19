using System;
using System.Windows.Forms;
using Gestor_Académico__J.C.Modelos;
using Gestor_Académico__J.C.Controladores; // Usa la clase correcta

namespace Gestor_Académico__J.C.Vistas
{
    public partial class EstudiantesForm : Form
    {
        private int idSeleccionado = 0; // ID del estudiante seleccionado
        private readonly EstudianteControlador controlador = new EstudianteControlador(); // ✅ Clase correcta

        public EstudiantesForm()
        {
            InitializeComponent();
            CargarEstudiantes();

            // Eventos
            btnAgregar.Click += BtnAgregar_Click;
            btnActualizar.Click += BtnActualizar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            dgvEstudiantes.CellClick += DgvEstudiantes_CellClick;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                var estudiante = new Estudiante
                {
                    Cedula = txtCedula.Text,
                    Nombre = txtNombre.Text,
                    Correo = txtCorreo.Text,
                    FechaNacimiento = dtpNacimiento.Value
                };

                // Llamamos al método del controlador para agregar estudiante
                bool agregado = controlador.ActAgregarEstudiante(estudiante); // Cambiado a ActAgregarEstudiante
                if (agregado)
                {
                    CargarEstudiantes();
                    LimpiarCampos();
                    MessageBox.Show("Estudiante agregado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el estudiante.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos antes de agregar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                var estudiante = new Estudiante
                {
                    IdEstudiante = idSeleccionado, // Usamos IdEstudiante
                    Cedula = txtCedula.Text,
                    Nombre = txtNombre.Text,
                    Correo = txtCorreo.Text,
                    FechaNacimiento = dtpNacimiento.Value
                };

                controlador.ActualizarEstudiante(estudiante);
                CargarEstudiantes();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos antes de actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado > 0)
            {
                var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar este estudiante?",
                                                    "Confirmar eliminación",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    controlador.EliminarEstudiante(idSeleccionado);
                    CargarEstudiantes();
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un estudiante para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DgvEstudiantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvEstudiantes.Rows[e.RowIndex];
                idSeleccionado = Convert.ToInt32(fila.Cells["IdEstudiante"].Value);
                txtCedula.Text = fila.Cells["Cedula"].Value.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
                dtpNacimiento.Value = Convert.ToDateTime(fila.Cells["FechaNacimiento"].Value);
            }
        }

        private bool ValidarCampos()
        {
            return !string.IsNullOrWhiteSpace(txtCedula.Text)
                && !string.IsNullOrWhiteSpace(txtNombre.Text)
                && !string.IsNullOrWhiteSpace(txtCorreo.Text);
        }

        private void CargarEstudiantes()
        {
            dgvEstudiantes.DataSource = controlador.ObtenerEstudiantes();
        }

        private void LimpiarCampos()
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtCorreo.Clear();
            dtpNacimiento.Value = DateTime.Today;
            idSeleccionado = 0;
        }

        private void EstudiantesForm_Load(object sender, EventArgs e)
        {
            // Este método puede quedarse vacío o eliminarse si no lo usas.
        }
    }
}
