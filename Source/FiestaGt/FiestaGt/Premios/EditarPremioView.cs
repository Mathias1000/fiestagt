using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FiestaGT.Logic;
using FiestaGt.Commons;
using FiestaGT.Commons.Exceptions;
using FiestaGT.Commons.Dto;

namespace FiestaGt.Premios
{
    public partial class EditarPremioView : Form
    {
        private static PremioLogic _premioLogic = new PremioLogic();

        private static PremiosView _premiosView;

        private static Validators _validators = new Validators();

        private static int _premioId;

        public EditarPremioView(PremiosView premiosView, int premioId)
        {
            InitializeComponent();

            var premioEdit = _premioLogic.ObtenerPremioById(premioId);

            this.textBoxNombre.Text = premioEdit.Nombre;
            this.textBoxValorTokens.Text = premioEdit.ValorEnTokens.ToString();
            this.checkBoxActivo.Checked = premioEdit.Activo;

            _premioId = premioId;
            _premiosView = premiosView;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.textBoxNombre.Text))
                {
                    throw new ValidationException("Debe ingresar un nombre");
                }

                if (string.IsNullOrEmpty(this.textBoxValorTokens.Text))
                {
                    throw new ValidationException("Debe ingresar un valor en tokens");
                }

                var dto = new PremioDto();

                dto.Id = _premioId;
                dto.Nombre = this.textBoxNombre.Text;
                dto.ValorEnTokens = int.Parse(this.textBoxValorTokens.Text);
                dto.Activo = this.checkBoxActivo.Checked;

                _premioLogic.EditarPremio(dto);

                _premiosView.RefreshTablaPremios();

                this.Close();
            }
            catch (ValidationException vex)
            {
                MessageBox.Show(vex.Message);
            }
            catch (Exception ex)
            {
                this.errorProvider.SetError(this.buttonGuardar, "ERROR: No se pudo guardar el premio.\n" + ex.Message);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxValorTokens_KeyPress(object sender, KeyPressEventArgs e)
        {
            _validators.SoloNumeros(e);
        }
    }
}
