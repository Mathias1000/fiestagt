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

namespace FiestaGt.Jugadores
{
    public partial class NuevoJugadorView : Form
    {

        private static JugadorLogic _jugadorLogic = new JugadorLogic();

        private static JugadoresView _jugadoresView;

        public NuevoJugadorView(JugadoresView jugadoresView)
        {
            InitializeComponent();

            this.textBoxCantAsistencias.Text = "0";
            this.textBoxCantAsistenciasHist.Text = "0";

            _jugadoresView = jugadoresView;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var jugadorDto = new JugadorDto();

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

                jugadorDto.Nombre = this.textBoxNombre.Text;
                jugadorDto.CantidadAsistencias = int.Parse(this.textBoxCantAsistencias.Text);
                jugadorDto.CantidadAsistenciasHistoricas = int.Parse(this.textBoxCantAsistenciasHist.Text);
                jugadorDto.Activo = true;

                _jugadorLogic.CrearJugador(jugadorDto);

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

    }
}
