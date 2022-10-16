namespace UI.Desktop
{
    partial class CursoDesktop
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
            this.tlpCursos = new System.Windows.Forms.TableLayoutPanel();
            this.cursoLabel = new System.Windows.Forms.Label();
            this.comsionLabel = new System.Windows.Forms.Label();
            this.materiaLabel = new System.Windows.Forms.Label();
            this.anioLabel = new System.Windows.Forms.Label();
            this.cupoLabel = new System.Windows.Forms.Label();
            this.txtIDcurso = new System.Windows.Forms.TextBox();
            this.txtAnioCalendario = new System.Windows.Forms.TextBox();
            this.txtCupo = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cbComisiones = new System.Windows.Forms.ComboBox();
            this.cbMaterias = new System.Windows.Forms.ComboBox();
            this.tlpCursos.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpCursos
            // 
            this.tlpCursos.ColumnCount = 5;
            this.tlpCursos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpCursos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpCursos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpCursos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpCursos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpCursos.Controls.Add(this.cursoLabel, 0, 0);
            this.tlpCursos.Controls.Add(this.comsionLabel, 0, 1);
            this.tlpCursos.Controls.Add(this.materiaLabel, 2, 1);
            this.tlpCursos.Controls.Add(this.anioLabel, 0, 2);
            this.tlpCursos.Controls.Add(this.cupoLabel, 2, 2);
            this.tlpCursos.Controls.Add(this.txtIDcurso, 1, 0);
            this.tlpCursos.Controls.Add(this.txtAnioCalendario, 1, 2);
            this.tlpCursos.Controls.Add(this.txtCupo, 3, 2);
            this.tlpCursos.Controls.Add(this.btnAceptar, 2, 3);
            this.tlpCursos.Controls.Add(this.btnCancelar, 3, 3);
            this.tlpCursos.Controls.Add(this.cbComisiones, 1, 1);
            this.tlpCursos.Controls.Add(this.cbMaterias, 3, 1);
            this.tlpCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCursos.Location = new System.Drawing.Point(0, 0);
            this.tlpCursos.Margin = new System.Windows.Forms.Padding(4);
            this.tlpCursos.Name = "tlpCursos";
            this.tlpCursos.RowCount = 4;
            this.tlpCursos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpCursos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpCursos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpCursos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpCursos.Size = new System.Drawing.Size(1067, 528);
            this.tlpCursos.TabIndex = 0;
            // 
            // cursoLabel
            // 
            this.cursoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cursoLabel.AutoSize = true;
            this.cursoLabel.Location = new System.Drawing.Point(136, 71);
            this.cursoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cursoLabel.Name = "cursoLabel";
            this.cursoLabel.Size = new System.Drawing.Size(20, 16);
            this.cursoLabel.TabIndex = 0;
            this.cursoLabel.Text = "ID";
            // 
            // comsionLabel
            // 
            this.comsionLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comsionLabel.AutoSize = true;
            this.comsionLabel.Location = new System.Drawing.Point(93, 229);
            this.comsionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.comsionLabel.Name = "comsionLabel";
            this.comsionLabel.Size = new System.Drawing.Size(63, 16);
            this.comsionLabel.TabIndex = 1;
            this.comsionLabel.Text = "Comision";
            // 
            // materiaLabel
            // 
            this.materiaLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.materiaLabel.AutoSize = true;
            this.materiaLabel.Location = new System.Drawing.Point(584, 229);
            this.materiaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materiaLabel.Name = "materiaLabel";
            this.materiaLabel.Size = new System.Drawing.Size(52, 16);
            this.materiaLabel.TabIndex = 2;
            this.materiaLabel.Text = "Materia";
            // 
            // anioLabel
            // 
            this.anioLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.anioLabel.AutoSize = true;
            this.anioLabel.Location = new System.Drawing.Point(125, 387);
            this.anioLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.anioLabel.Name = "anioLabel";
            this.anioLabel.Size = new System.Drawing.Size(31, 16);
            this.anioLabel.TabIndex = 3;
            this.anioLabel.Text = "Año";
            // 
            // cupoLabel
            // 
            this.cupoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cupoLabel.AutoSize = true;
            this.cupoLabel.Location = new System.Drawing.Point(597, 387);
            this.cupoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cupoLabel.Name = "cupoLabel";
            this.cupoLabel.Size = new System.Drawing.Size(39, 16);
            this.cupoLabel.TabIndex = 4;
            this.cupoLabel.Text = "Cupo";
            // 
            // txtIDcurso
            // 
            this.txtIDcurso.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtIDcurso.Location = new System.Drawing.Point(164, 68);
            this.txtIDcurso.Margin = new System.Windows.Forms.Padding(4);
            this.txtIDcurso.Name = "txtIDcurso";
            this.txtIDcurso.ReadOnly = true;
            this.txtIDcurso.Size = new System.Drawing.Size(311, 22);
            this.txtIDcurso.TabIndex = 5;
            // 
            // txtAnioCalendario
            // 
            this.txtAnioCalendario.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAnioCalendario.Location = new System.Drawing.Point(164, 384);
            this.txtAnioCalendario.Margin = new System.Windows.Forms.Padding(4);
            this.txtAnioCalendario.Name = "txtAnioCalendario";
            this.txtAnioCalendario.Size = new System.Drawing.Size(311, 22);
            this.txtAnioCalendario.TabIndex = 8;
            // 
            // txtCupo
            // 
            this.txtCupo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCupo.Location = new System.Drawing.Point(644, 384);
            this.txtCupo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCupo.Name = "txtCupo";
            this.txtCupo.Size = new System.Drawing.Size(311, 22);
            this.txtCupo.TabIndex = 9;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(484, 478);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 28);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(644, 478);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 28);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cbComisiones
            // 
            this.cbComisiones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbComisiones.FormattingEnabled = true;
            this.cbComisiones.Location = new System.Drawing.Point(163, 225);
            this.cbComisiones.Name = "cbComisiones";
            this.cbComisiones.Size = new System.Drawing.Size(314, 24);
            this.cbComisiones.TabIndex = 12;
            // 
            // cbMaterias
            // 
            this.cbMaterias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMaterias.Location = new System.Drawing.Point(643, 225);
            this.cbMaterias.Name = "cbMaterias";
            this.cbMaterias.Size = new System.Drawing.Size(314, 24);
            this.cbMaterias.TabIndex = 0;
            // 
            // CursoDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 528);
            this.Controls.Add(this.tlpCursos);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CursoDesktop";
            this.Text = "Formulario Curso";
            this.Load += new System.EventHandler(this.CursoDesktop_Load);
            this.tlpCursos.ResumeLayout(false);
            this.tlpCursos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCursos;
        private System.Windows.Forms.Label cursoLabel;
        private System.Windows.Forms.Label comsionLabel;
        private System.Windows.Forms.Label materiaLabel;
        private System.Windows.Forms.Label anioLabel;
        private System.Windows.Forms.Label cupoLabel;
        private System.Windows.Forms.TextBox txtIDcurso;
        private System.Windows.Forms.TextBox txtAnioCalendario;
        private System.Windows.Forms.TextBox txtCupo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cbComisiones;
        private System.Windows.Forms.ComboBox cbMaterias;
    }
}