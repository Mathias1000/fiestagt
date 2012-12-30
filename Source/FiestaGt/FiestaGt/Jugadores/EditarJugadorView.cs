using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FiestaGT.Logic;
using FiestaGT.Commons.Dto;
using FiestaGT.Commons.Exceptions;
using FiestaGt.Commons;

namespace FiestaGt.Jugadores
{
    public partial class EditarJugadorView : Form
    {
        private static JugadorLogic _jugadorLogic = new JugadorLogic();

        private static JugadoresView _jugadoresView;

        private static Validators _validators = new Validators();
        
        private static int _jugadorId;


        public EditarJugadorView(JugadoresView jugadoresView, int jugadorEditId)
        {
            InitializeComponent();

            var jugadorEdit = _jugadorLogic.ObtenerJugadorById(jugadorEditId);

            this.textBoxNombre.Text = jugadorEdit.Nombre;
            this.textBoxCantAsistencias.Text = jugadorEdit.CantidadAsistencias.ToString();
            this.textBoxCantAsistenciasHist.Text = jugadorEdit.CantidadAsistenciasHistoricas.ToString();
            this.checkBoxActivo.Checked = jugadorEdit.Activo;

            _jugadoresView = jugadoresView;
            _jugadorId = jugadorEditId;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var jugadorEditedDto = new JugadorDto();

                if (string.IsNullOrEmpty(this.textBoxNombre.Text))
                {
                    throw new ValidationException("Debe ingresar un nombre");
                }

                if (string.IsNullOrEmpty(this.textBoxCantAsistencias.Text))
                {
                    throw new ValidationException("Debe ingresar una cantidad de asistencias");
                }

                if (string.IsNullOrEmpty(this.textBoxCantAsistenciasHist.Text))
                {
                    throw new ValidationException("Debe ingresar una cantidad de asistencias históricas");
                }

                jugadorEditedDto.Id = _jugadorId;
                jugadorEditedDto.Nombre = this.textBoxNombre.Text;
                jugadorEditedDto.CantidadAsistencias = int.Parse(this.textBoxCantAsistencias.Text);
                jugadorEditedDto.CantidadAsistenciasHistoricas = int.Parse(this.textBoxCantAsistenciasHist.Text);
                jugadorEditedDto.Activo = this.checkBoxActivo.Checked;

                _jugadorLogic.EditarJugador(jugadorEditedDto);

                _jugadoresView.RefreshTablaJugadores();

                this.Close();
            }
            catch (ValidationException vex)
            {
                MessageBox.Show(vex.Message);
            }
            catch (Exception ex)
            {
                this.errorProvider.SetError(this.buttonGuardar, "ERROR: No se pudo guardar el jugador.\n" + ex.Message);
            }
        }

        private void textBoxCantAsistencias_KeyPress(object sender, KeyPressEventArgs e)
        {
            _validators.SoloNumeros(e);

        }

        private void textBoxCantAsistenciasHist_KeyPress(object sender, KeyPressEventArgs e)
        {
            _validators.SoloNumeros(e);
        }


    }
}
