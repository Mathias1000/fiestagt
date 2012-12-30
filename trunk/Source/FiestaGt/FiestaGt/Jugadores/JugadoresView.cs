using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FiestaGT.Logic;
using FiestaGT.DataAccess.Entities;
using FiestaGT.Commons.Dto;
using FiestaGT.Commons.Exceptions;

namespace FiestaGt.Jugadores
{
    public partial class JugadoresView : Form
    {
        private static JugadorLogic _jugadorLogic = new JugadorLogic();

        public JugadoresView()
        {
            InitializeComponent();

            this.dataGridViewJugadores.DataSource = _jugadorLogic.ObtenerJugadores();
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            var nuevoJugadorView = new NuevoJugadorView(this);
            nuevoJugadorView.Show();

        }

        public void RefreshTablaJugadores()
        {
            this.dataGridViewJugadores.DataSource = _jugadorLogic.ObtenerJugadores();
        }

        private void buttoEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridViewJugadores.SelectedRows == null || this.dataGridViewJugadores.SelectedRows.Count == 0)
                {
                    throw new ValidationException("Debe seleccionar una fila");
                }

                var jugadorSelected = (Jugador)this.dataGridViewJugadores.SelectedRows[0].DataBoundItem;

                if (jugadorSelected == null)
                {
                    throw new ValidationException("Debe seleccionar una fila");
                }

                var editarJugadorView = new EditarJugadorView(this, jugadorSelected.Id);
                editarJugadorView.Show();
            }
            catch (ValidationException vex)
            {
                MessageBox.Show(vex.Message);
            }
            catch (Exception ex)
            {
                this.errorProvider.SetError(this.buttoEditar, "ERROR: No se pudo editar el jugador.\n" + ex.Message);
            }

        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            this.dataGridViewJugadores.DataSource = _jugadorLogic.BuscarJugadores(this.textBoxBuscar.Text);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.dataGridViewJugadores.DataSource = _jugadorLogic.ObtenerJugadores();
        }
    }
}
