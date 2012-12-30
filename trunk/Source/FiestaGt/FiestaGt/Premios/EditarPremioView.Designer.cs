﻿namespace FiestaGt.Premios
{
    partial class EditarPremioView
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
            this.textBoxValorTokens = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxActivo = new System.Windows.Forms.CheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxValorTokens
            // 
            this.textBoxValorTokens.Location = new System.Drawing.Point(116, 55);
            this.textBoxValorTokens.Name = "textBoxValorTokens";
            this.textBoxValorTokens.Size = new System.Drawing.Size(100, 20);
            this.textBoxValorTokens.TabIndex = 11;
            this.textBoxValorTokens.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValorTokens_KeyPress);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(116, 17);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(138, 20);
            this.textBoxNombre.TabIndex = 10;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(160, 136);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 9;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(48, 136);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 8;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Valor en Tokens:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Activo:";
            // 
            // checkBoxActivo
            // 
            this.checkBoxActivo.AutoSize = true;
            this.checkBoxActivo.Location = new System.Drawing.Point(116, 93);
            this.checkBoxActivo.Name = "checkBoxActivo";
            this.checkBoxActivo.Size = new System.Drawing.Size(15, 14);
            this.checkBoxActivo.TabIndex = 13;
            this.checkBoxActivo.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // EditarPremioView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 177);
            this.Controls.Add(this.checkBoxActivo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxValorTokens);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EditarPremioView";
            this.Text = "Editar Premio";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxValorTokens;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxActivo;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}