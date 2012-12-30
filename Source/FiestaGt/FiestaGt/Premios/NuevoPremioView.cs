using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FiestaGT.Commons.Dto;
using FiestaGT.Commons.Exceptions;
using FiestaGT.Logic;
using FiestaGt.Commons;

namespace FiestaGt.Premios
{
    public partial class NuevoPremioView : Form
    {
        private static PremioLogic _premioLogic = new PremioLogic();

        private static PremiosView _premiosView;

        private static Validators _validators = new Validators();


        public NuevoPremioView(PremiosView premiosView)
        {
            InitializeComponent();

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

                dto.Nombre = this.textBoxNombre.Text;
                dto.ValorEnTokens = int.Parse(this.textBoxValorTokens.Text);
                dto.Activo = true;

                _premioLogic.CrearPremio(dto);

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
