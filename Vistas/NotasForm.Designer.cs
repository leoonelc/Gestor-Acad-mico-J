namespace Gestor_Académico__J.C
{
    partial class NotasForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblCalificacion;
        private System.Windows.Forms.Label lblEvaluacion;
        private System.Windows.Forms.Label lblEstudiante;
        private System.Windows.Forms.DataGridView dgvNotas;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtCalificacion;
        private System.Windows.Forms.ComboBox cmbEvaluaciones;
        private System.Windows.Forms.ComboBox cmbEstudiantes;

        private void InitializeComponent()
        {
            this.lblEstudiante = new System.Windows.Forms.Label();
            this.lblEvaluacion = new System.Windows.Forms.Label();
            this.lblCalificacion = new System.Windows.Forms.Label();
            this.cmbEstudiantes = new System.Windows.Forms.ComboBox();
            this.cmbEvaluaciones = new System.Windows.Forms.ComboBox();
            this.txtCalificacion = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvNotas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEstudiante
            // 
            this.lblEstudiante.AutoSize = true;
            this.lblEstudiante.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstudiante.Location = new System.Drawing.Point(24, 280);
            this.lblEstudiante.Name = "lblEstudiante";
            this.lblEstudiante.Size = new System.Drawing.Size(107, 25);
            this.lblEstudiante.TabIndex = 2;
            this.lblEstudiante.Text = "Estudiante:";
            // 
            // lblEvaluacion
            // 
            this.lblEvaluacion.AutoSize = true;
            this.lblEvaluacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEvaluacion.Location = new System.Drawing.Point(24, 320);
            this.lblEvaluacion.Name = "lblEvaluacion";
            this.lblEvaluacion.Size = new System.Drawing.Size(109, 25);
            this.lblEvaluacion.TabIndex = 1;
            this.lblEvaluacion.Text = "Evaluación:";
            // 
            // lblCalificacion
            // 
            this.lblCalificacion.AutoSize = true;
            this.lblCalificacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCalificacion.Location = new System.Drawing.Point(24, 360);
            this.lblCalificacion.Name = "lblCalificacion";
            this.lblCalificacion.Size = new System.Drawing.Size(115, 25);
            this.lblCalificacion.TabIndex = 0;
            this.lblCalificacion.Text = "Calificación:";
            // 
            // cmbEstudiantes
            // 
            this.cmbEstudiantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstudiantes.Location = new System.Drawing.Point(148, 280);
            this.cmbEstudiantes.Name = "cmbEstudiantes";
            this.cmbEstudiantes.Size = new System.Drawing.Size(644, 28);
            this.cmbEstudiantes.TabIndex = 9;
            // 
            // cmbEvaluaciones
            // 
            this.cmbEvaluaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEvaluaciones.Location = new System.Drawing.Point(148, 320);
            this.cmbEvaluaciones.Name = "cmbEvaluaciones";
            this.cmbEvaluaciones.Size = new System.Drawing.Size(644, 28);
            this.cmbEvaluaciones.TabIndex = 8;
            // 
            // txtCalificacion
            // 
            this.txtCalificacion.Location = new System.Drawing.Point(148, 360);
            this.txtCalificacion.Name = "txtCalificacion";
            this.txtCalificacion.Size = new System.Drawing.Size(644, 26);
            this.txtCalificacion.TabIndex = 7;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAgregar.Location = new System.Drawing.Point(814, 253);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(190, 34);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnActualizar.Location = new System.Drawing.Point(814, 349);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(190, 36);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEliminar.Location = new System.Drawing.Point(814, 297);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(190, 36);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // dgvNotas
            // 
            this.dgvNotas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNotas.ColumnHeadersHeight = 34;
            this.dgvNotas.Location = new System.Drawing.Point(29, 12);
            this.dgvNotas.MultiSelect = false;
            this.dgvNotas.Name = "dgvNotas";
            this.dgvNotas.ReadOnly = true;
            this.dgvNotas.RowHeadersWidth = 62;
            this.dgvNotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotas.Size = new System.Drawing.Size(975, 230);
            this.dgvNotas.TabIndex = 3;
            this.dgvNotas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvNotas_CellClick);
            this.dgvNotas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvNotas_CellContentClick);
            // 
            // NotasForm
            // 
            this.ClientSize = new System.Drawing.Size(1038, 420);
            this.Controls.Add(this.lblCalificacion);
            this.Controls.Add(this.lblEvaluacion);
            this.Controls.Add(this.lblEstudiante);
            this.Controls.Add(this.dgvNotas);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtCalificacion);
            this.Controls.Add(this.cmbEvaluaciones);
            this.Controls.Add(this.cmbEstudiantes);
            this.Name = "NotasForm";
            this.Text = "Gestor Académico - Gestión de Notas";
            this.Load += new System.EventHandler(this.NotasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
