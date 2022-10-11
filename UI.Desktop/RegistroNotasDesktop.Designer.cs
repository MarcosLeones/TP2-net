namespace UI.Desktop
{
    partial class RegistroNotasDesktop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbCursos = new System.Windows.Forms.ComboBox();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.alumnoNotaBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.alumnoNotaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.alumnoNotaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.alumnoNotaBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dgvAlumnosNotas = new System.Windows.Forms.DataGridView();
            this.iDAlumnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.legajoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDPlanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDCursoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.condicionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDInscripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alumnoNotaBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alumnoNotaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alumnoNotaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alumnoNotaBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnosNotas)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.cbCursos, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSiguiente, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnGuardar, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgvAlumnosNotas, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cbCursos
            // 
            this.cbCursos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCursos.FormattingEnabled = true;
            this.cbCursos.Location = new System.Drawing.Point(83, 10);
            this.cbCursos.Name = "cbCursos";
            this.cbCursos.Size = new System.Drawing.Size(314, 24);
            this.cbCursos.TabIndex = 0;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSiguiente.Location = new System.Drawing.Point(403, 11);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(75, 23);
            this.btnSiguiente.TabIndex = 1;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(3, 424);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(74, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(723, 424);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(74, 23);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Curso:";
            // 
            // alumnoNotaBindingSource3
            // 
            this.alumnoNotaBindingSource3.DataSource = typeof(Util.AlumnoNota);
            // 
            // alumnoNotaBindingSource
            // 
            this.alumnoNotaBindingSource.DataSource = typeof(Util.AlumnoNota);
            // 
            // alumnoNotaBindingSource1
            // 
            this.alumnoNotaBindingSource1.DataSource = typeof(Util.AlumnoNota);
            // 
            // alumnoNotaBindingSource2
            // 
            this.alumnoNotaBindingSource2.DataSource = typeof(Util.AlumnoNota);
            // 
            // dgvAlumnosNotas
            // 
            this.dgvAlumnosNotas.AllowUserToAddRows = false;
            this.dgvAlumnosNotas.AllowUserToDeleteRows = false;
            this.dgvAlumnosNotas.AllowUserToOrderColumns = true;
            this.dgvAlumnosNotas.AutoGenerateColumns = false;
            this.dgvAlumnosNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnosNotas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDAlumnoDataGridViewTextBoxColumn,
            this.legajoDataGridViewTextBoxColumn,
            this.apellidoDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.iDPlanDataGridViewTextBoxColumn,
            this.iDCursoDataGridViewTextBoxColumn,
            this.notaDataGridViewTextBoxColumn,
            this.condicionDataGridViewTextBoxColumn,
            this.IDInscripcion});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvAlumnosNotas, 2);
            this.dgvAlumnosNotas.DataSource = this.alumnoNotaBindingSource3;
            this.dgvAlumnosNotas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlumnosNotas.Enabled = false;
            this.dgvAlumnosNotas.Location = new System.Drawing.Point(83, 48);
            this.dgvAlumnosNotas.MultiSelect = false;
            this.dgvAlumnosNotas.Name = "dgvAlumnosNotas";
            this.dgvAlumnosNotas.RowHeadersWidth = 51;
            this.dgvAlumnosNotas.RowTemplate.Height = 24;
            this.dgvAlumnosNotas.Size = new System.Drawing.Size(634, 354);
            this.dgvAlumnosNotas.TabIndex = 4;
            // 
            // iDAlumnoDataGridViewTextBoxColumn
            // 
            this.iDAlumnoDataGridViewTextBoxColumn.DataPropertyName = "IDAlumno";
            this.iDAlumnoDataGridViewTextBoxColumn.HeaderText = "IDAlumno";
            this.iDAlumnoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDAlumnoDataGridViewTextBoxColumn.Name = "iDAlumnoDataGridViewTextBoxColumn";
            this.iDAlumnoDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDAlumnoDataGridViewTextBoxColumn.Visible = false;
            this.iDAlumnoDataGridViewTextBoxColumn.Width = 125;
            // 
            // legajoDataGridViewTextBoxColumn
            // 
            this.legajoDataGridViewTextBoxColumn.DataPropertyName = "Legajo";
            this.legajoDataGridViewTextBoxColumn.HeaderText = "Legajo";
            this.legajoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.legajoDataGridViewTextBoxColumn.Name = "legajoDataGridViewTextBoxColumn";
            this.legajoDataGridViewTextBoxColumn.ReadOnly = true;
            this.legajoDataGridViewTextBoxColumn.Width = 125;
            // 
            // apellidoDataGridViewTextBoxColumn
            // 
            this.apellidoDataGridViewTextBoxColumn.DataPropertyName = "Apellido";
            this.apellidoDataGridViewTextBoxColumn.HeaderText = "Apellido";
            this.apellidoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.apellidoDataGridViewTextBoxColumn.Name = "apellidoDataGridViewTextBoxColumn";
            this.apellidoDataGridViewTextBoxColumn.Width = 125;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            this.emailDataGridViewTextBoxColumn.Visible = false;
            this.emailDataGridViewTextBoxColumn.Width = 125;
            // 
            // iDPlanDataGridViewTextBoxColumn
            // 
            this.iDPlanDataGridViewTextBoxColumn.DataPropertyName = "IDPlan";
            this.iDPlanDataGridViewTextBoxColumn.HeaderText = "IDPlan";
            this.iDPlanDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDPlanDataGridViewTextBoxColumn.Name = "iDPlanDataGridViewTextBoxColumn";
            this.iDPlanDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDPlanDataGridViewTextBoxColumn.Visible = false;
            this.iDPlanDataGridViewTextBoxColumn.Width = 125;
            // 
            // iDCursoDataGridViewTextBoxColumn
            // 
            this.iDCursoDataGridViewTextBoxColumn.DataPropertyName = "IDCurso";
            this.iDCursoDataGridViewTextBoxColumn.HeaderText = "IDCurso";
            this.iDCursoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDCursoDataGridViewTextBoxColumn.Name = "iDCursoDataGridViewTextBoxColumn";
            this.iDCursoDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDCursoDataGridViewTextBoxColumn.Visible = false;
            this.iDCursoDataGridViewTextBoxColumn.Width = 125;
            // 
            // notaDataGridViewTextBoxColumn
            // 
            this.notaDataGridViewTextBoxColumn.DataPropertyName = "Nota";
            this.notaDataGridViewTextBoxColumn.HeaderText = "Nota";
            this.notaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.notaDataGridViewTextBoxColumn.Name = "notaDataGridViewTextBoxColumn";
            this.notaDataGridViewTextBoxColumn.Width = 125;
            // 
            // condicionDataGridViewTextBoxColumn
            // 
            this.condicionDataGridViewTextBoxColumn.DataPropertyName = "Condicion";
            this.condicionDataGridViewTextBoxColumn.HeaderText = "Condición";
            this.condicionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.condicionDataGridViewTextBoxColumn.Name = "condicionDataGridViewTextBoxColumn";
            this.condicionDataGridViewTextBoxColumn.Width = 125;
            // 
            // IDInscripcion
            // 
            this.IDInscripcion.DataPropertyName = "IDInscripcion";
            this.IDInscripcion.HeaderText = "IDInscripcion";
            this.IDInscripcion.MinimumWidth = 6;
            this.IDInscripcion.Name = "IDInscripcion";
            this.IDInscripcion.ReadOnly = true;
            this.IDInscripcion.Visible = false;
            this.IDInscripcion.Width = 125;
            // 
            // RegistroNotasDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RegistroNotasDesktop";
            this.Text = "RegistroNotas";
            this.Load += new System.EventHandler(this.RegistroNotasDesktop_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alumnoNotaBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alumnoNotaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alumnoNotaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alumnoNotaBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnosNotas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbCursos;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource alumnoNotaBindingSource;
        private System.Windows.Forms.BindingSource alumnoNotaBindingSource2;
        private System.Windows.Forms.BindingSource alumnoNotaBindingSource1;
        private System.Windows.Forms.BindingSource alumnoNotaBindingSource3;
        private System.Windows.Forms.DataGridView dgvAlumnosNotas;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDAlumnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn legajoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDPlanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCursoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn condicionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDInscripcion;
    }
}