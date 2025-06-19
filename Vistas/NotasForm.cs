using System;
using System.Windows.Forms;
using Gestor_Académico__J.C.Controladores;
using Gestor_Académico__J.C.Modelos;
using System.Collections.Generic;

namespace Gestor_Académico__J.C
{
    public partial class NotasForm : Form
    {
        private readonly NotaControlador controlador = new NotaControlador();
        private readonly EstudianteControlador estudianteControlador = new EstudianteControlador();
        private readonly EvaluacionControlador evaluacionControlador = new EvaluacionControlador();
        private int idSeleccionado = -1;

        public NotasForm()
        {
            InitializeComponent();
        }

        private void NotasForm_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            dgvNotas.DataSource = controlador.ObtenerNotas();

            cmbEstudiantes.DataSource = estudianteControlador.ObtenerEstudiantes();
            cmbEstudiantes.DisplayMember = "Nombre";
            cmbEstudiantes.ValueMember = "IdEstudiante";

            cmbEvaluaciones.DataSource = evaluacionControlador.ObtenerEvaluaciones();
            cmbEvaluaciones.DisplayMember = "NombreEvaluacion";
            cmbEvaluaciones.ValueMember = "IdEvaluacion";

            dgvNotas.ClearSelection();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbEstudiantes.SelectedIndex == -1 || cmbEvaluaciones.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un estudiante y una evaluación.");
                return;
            }

            if (!decimal.TryParse(txtCalificacion.Text, out decimal calif) || calif < 0 || calif > 100)
            {
                MessageBox.Show("Ingrese una calificación válida entre 0 y 100.");
                return;
            }

            Nota nota = new Nota
            {
                IdEstudiante = (int)cmbEstudiantes.SelectedValue,
                IdEvaluacion = (int)cmbEvaluaciones.SelectedValue,
                Calificacion = calif
            };

            if (controlador.AgregarNota(nota))
            {
                MessageBox.Show("Nota agregada correctamente.");
                CargarDatos();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al agregar la nota.");
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Seleccione una nota para actualizar.");
                return;
            }

            if (!decimal.TryParse(txtCalificacion.Text, out decimal calif) || calif < 0 || calif > 100)
            {
                MessageBox.Show("Ingrese una calificación válida entre 0 y 100.");
                return;
            }

            Nota nota = new Nota
            {
                IdNota = idSeleccionado,
                IdEstudiante = (int)cmbEstudiantes.SelectedValue,
                IdEvaluacion = (int)cmbEvaluaciones.SelectedValue,
                Calificacion = calif
            };

            if (controlador.ActualizarNota(nota))
            {
                MessageBox.Show("Nota actualizada correctamente.");
                CargarDatos();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al actualizar la nota.");
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Seleccione una nota para eliminar.");
                return;
            }

            var confirmar = MessageBox.Show("¿Está seguro que desea eliminar esta nota?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmar == DialogResult.Yes)
            {
                if (controlador.EliminarNota(idSeleccionado))
                {
                    MessageBox.Show("Nota eliminada correctamente.");
                    CargarDatos();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la nota.");
                }
            }
        }

        private void DgvNotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvNotas.Rows[e.RowIndex];
                idSeleccionado = Convert.ToInt32(fila.Cells["IdNota"].Value);
                cmbEstudiantes.SelectedValue = Convert.ToInt32(fila.Cells["IdEstudiante"].Value);
                cmbEvaluaciones.SelectedValue = Convert.ToInt32(fila.Cells["IdEvaluacion"].Value);
                txtCalificacion.Text = fila.Cells["Calificacion"].Value.ToString();
            }
        }

        private void LimpiarCampos()
        {
            cmbEstudiantes.SelectedIndex = -1;
            cmbEvaluaciones.SelectedIndex = -1;
            txtCalificacion.Clear();
            idSeleccionado = -1;
            dgvNotas.ClearSelection();
        }

        private void DgvNotas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
