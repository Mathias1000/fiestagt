namespace FiestaGt.Jugadores
{
    partial class NuevoJugadorView
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCantAsistencias = new System.Windows.Forms.TextBox();
            this.labelCantAsistenciasHist = new System.Windows.Forms.Label();
            this.textBoxCantAsistenciasHist = new System.Windows.Forms.TextBox();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(190, 31);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(188, 20);
            this.textBoxNombre.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cantidad de Asistencias:";
            // 
            // textBoxCantAsistencias
            // 
            this.textBoxCantAsistencias.Location = new System.Drawing.Point(190, 73);
            this.textBoxCantAsistencias.Name = "textBoxCantAsistencias";
            this.textBoxCantAsistencias.Size = new System.Drawing.Size(112, 20);
            this.textBoxCantAsistencias.TabIndex = 3;
            // 
            // labelCantAsistenciasHist
            // 
            this.labelCantAsistenciasHist.AutoSize = true;
            this.labelCantAsistenciasHist.Location = new System.Drawing.Point(12, 118);
            this.labelCantAsistenciasHist.Name = "labelCantAsistenciasHist";
            this.labelCantAsistenciasHist.Size = new System.Drawing.Size(172, 13);
            this.labelCantAsistenciasHist.TabIndex = 4;
            this.labelCantAsistenciasHist.Text = "Cantidad de Asistencias Históricas:";
            // 
            // textBoxCantAsistenciasHist
            // 
            this.textBoxCantAsistenciasHist.Location = new System.Drawing.Point(190, 115);
            this.textBoxCantAsistenciasHist.Name = "textBoxCantAsistenciasHist";
            this.textBoxCantAsistenciasHist.Size = new System.Drawing.Size(112, 20);
            this.textBoxCantAsistenciasHist.TabIndex = 5;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(107, 178);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 6;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(207, 178);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 7;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // NuevoJugadorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 213);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.textBoxCantAsistenciasHist);
            this.Controls.Add(this.labelCantAsistenciasHist);
            this.Controls.Add(this.textBoxCantAsistencias);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NuevoJugadorView";
            this.Text = "Nuevo Jugador";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCantAsistencias;
        private System.Windows.Forms.Label labelCantAsistenciasHist;
        private System.Windows.Forms.TextBox textBoxCantAsistenciasHist;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}