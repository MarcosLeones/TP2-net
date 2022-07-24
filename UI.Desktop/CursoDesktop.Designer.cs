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
            this.txtComision = new System.Windows.Forms.TextBox();
            this.txtAnioCalendario = new System.Windows.Forms.TextBox();
            this.txtMateria = new System.Windows.Forms.TextBox();
            this.txtCupo = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
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
            this.tlpCursos.Controls.Add(this.txtComision, 1, 1);
            this.tlpCursos.Controls.Add(this.txtMateria, 3, 1);
            this.tlpCursos.Controls.Add(this.txtAnioCalendario, 1, 2);
            this.tlpCursos.Controls.Add(this.txtCupo, 3, 2);
            this.tlpCursos.Controls.Add(this.btnAceptar, 2, 3);
            this.tlpCursos.Controls.Add(this.btnCancelar, 3, 3);
            this.tlpCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCursos.Location = new System.Drawing.Point(0, 0);
            this.tlpCursos.Name = "tlpCursos";
            this.tlpCursos.RowCount = 4;
            this.tlpCursos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpCursos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpCursos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpCursos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpCursos.Size = new System.Drawing.Size(800, 429);
            this.tlpCursos.TabIndex = 0;
            // 
            // cursoLabel
            // 
            this.cursoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cursoLabel.AutoSize = true;
            this.cursoLabel.Location = new System.Drawing.Point(99, 57);
            this.cursoLabel.Name = "cursoLabel";
            this.cursoLabel.Size = new System.Drawing.Size(18, 13);
            this.cursoLabel.TabIndex = 0;
            this.cursoLabel.Text = "ID";
            // 
            // comsionLabel
            // 
            this.comsionLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comsionLabel.AutoSize = true;
            this.comsionLabel.Location = new System.Drawing.Point(68, 185);
            this.comsionLabel.Name = "comsionLabel";
            this.comsionLabel.Size = new System.Drawing.Size(49, 13);
            this.comsionLabel.TabIndex = 1;
            this.comsionLabel.Text = "Comision";
            // 
            // materiaLabel
            // 
            this.materiaLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.materiaLabel.AutoSize = true;
            this.materiaLabel.Location = new System.Drawing.Point(435, 185);
            this.materiaLabel.Name = "materiaLabel";
            this.materiaLabel.Size = new System.Drawing.Size(42, 13);
            this.materiaLabel.TabIndex = 2;
            this.materiaLabel.Text = "Materia";
            // 
            // anioLabel
            // 
            this.anioLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.anioLabel.AutoSize = true;
            this.anioLabel.Location = new System.Drawing.Point(91, 313);
            this.anioLabel.Name = "anioLabel";
            this.anioLabel.Size = new System.Drawing.Size(26, 13);
            this.anioLabel.TabIndex = 3;
            this.anioLabel.Text = "Año";
            // 
            // cupoLabel
            // 
            this.cupoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cupoLabel.AutoSize = true;
            this.cupoLabel.Location = new System.Drawing.Point(445, 313);
            this.cupoLabel.Name = "cupoLabel";
            this.cupoLabel.Size = new System.Drawing.Size(32, 13);
            this.cupoLabel.TabIndex = 4;
            this.cupoLabel.Text = "Cupo";
            // 
            // txtIDcurso
            // 
            this.txtIDcurso.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtIDcurso.Location = new System.Drawing.Point(123, 54);
            this.txtIDcurso.Name = "txtIDcurso";
            this.txtIDcurso.ReadOnly = true;
            this.txtIDcurso.Size = new System.Drawing.Size(234, 20);
            this.txtIDcurso.TabIndex = 5;
            // 
            // txtComision
            // 
            this.txtComision.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtComision.Location = new System.Drawing.Point(123, 182);
            this.txtComision.Name = "txtComision";
            this.txtComision.Size = new System.Drawing.Size(234, 20);
            this.txtComision.TabIndex = 6;
            // 
            // txtAnioCalendario
            // 
            this.txtAnioCalendario.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAnioCalendario.Location = new System.Drawing.Point(123, 310);
            this.txtAnioCalendario.Name = "txtAnioCalendario";
            this.txtAnioCalendario.Size = new System.Drawing.Size(234, 20);
            this.txtAnioCalendario.TabIndex = 8;
            // 
            // txtMateria
            // 
            this.txtMateria.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtMateria.Location = new System.Drawing.Point(483, 182);
            this.txtMateria.Name = "txtMateria";
            this.txtMateria.Size = new System.Drawing.Size(234, 20);
            this.txtMateria.TabIndex = 7;
            // 
            // txtCupo
            // 
            this.txtCupo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCupo.Location = new System.Drawing.Point(483, 310);
            this.txtCupo.Name = "txtCupo";
            this.txtCupo.Size = new System.Drawing.Size(234, 20);
            this.txtCupo.TabIndex = 9;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(363, 387);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(483, 387);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // CursoDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 429);
            this.Controls.Add(this.tlpCursos);
            this.Name = "CursoDesktop";
            this.Text = "CursosDesktop";
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
        private System.Windows.Forms.TextBox txtComision;
        private System.Windows.Forms.TextBox txtMateria;
        private System.Windows.Forms.TextBox txtAnioCalendario;
        private System.Windows.Forms.TextBox txtCupo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}