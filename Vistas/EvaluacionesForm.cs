using System;
using System.Windows.Forms;
using Gestor_Académico__J.C.Controladores;
using Gestor_Académico__J.C.Modelos;

namespace Gestor_Académico__J.C.Vistas
{
    public partial class EvaluacionesForm : Form
    {
        private readonly EvaluacionControlador controlador = new EvaluacionControlador();
        private int idSeleccionado = -1;

        public EvaluacionesForm()
        {
            InitializeComponent();
            CargarEvaluaciones();

            btnAgregar.Click += BtnAgregar_Click;
            btnActualizar.Click += BtnActualizar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            dgvEvaluaciones.CellClick += DgvEvaluaciones_CellClick;
        }

        private void CargarEvaluaciones()
        {
            dgvEvaluaciones.DataSource = controlador.ObtenerEvaluaciones();
            dgvEvaluaciones.ClearSelection();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre de la evaluación");
                return;
            }

            var eval = new Evaluacion
            {
                NombreEvaluacion = txtNombre.Text.Trim()
            };

            if (controlador.Agregar(eval))
            {
                MessageBox.Show("Evaluación agregada correctamente");
                CargarEvaluaciones();
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al agregar la evaluación");
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado <= 0 || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Seleccione una evaluación válida para actualizar.");
                return;
            }

            var eval = new Evaluacion
            {
                IdEvaluacion = idSeleccionado,
                NombreEvaluacion = txtNombre.Text.Trim()
            };

            if (controlador.Actualizar(eval))
            {
                MessageBox.Show("Evaluación actualizada correctamente");
                CargarEvaluaciones();
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al actualizar la evaluación");
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione una evaluación para eliminar.");
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro de eliminar esta evaluación?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                if (controlador.Eliminar(idSeleccionado))
                {
                    MessageBox.Show("Evaluación eliminada correctamente");
                    CargarEvaluaciones();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la evaluación");
                }
            }
        }

        private void DgvEvaluaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvEvaluaciones.Rows[e.RowIndex];
                idSeleccionado = Convert.ToInt32(fila.Cells["IdEvaluacion"].Value);
                txtNombre.Text = fila.Cells["NombreEvaluacion"].Value.ToString();
            }
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            idSeleccionado = -1;
        }

        private void EvaluacionesForm_Load(object sender, EventArgs e)
        {
            // Si quieres hacer algo al cargar el form, aquí.
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
