using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FiestaGT.Logic;
using FiestaGT.Commons.Exceptions;
using FiestaGT.DataAccess.Entities;

namespace FiestaGt.Premios
{
    public partial class PremiosView : Form
    {
        private static PremioLogic _premioLogic = new PremioLogic();


        public PremiosView()
        {
            InitializeComponent();

            this.dataGridViewPremios.DataSource = _premioLogic.ObtenerPremios();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            this.dataGridViewPremios.DataSource = _premioLogic.BuscarPremios(this.textBoxBuscar.Text);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.dataGridViewPremios.DataSource = _premioLogic.ObtenerPremios();
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            var nuevoPremioView = new NuevoPremioView(this);
            nuevoPremioView.Show();
        }

        private void buttoEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridViewPremios.SelectedRows == null || this.dataGridViewPremios.SelectedRows.Count == 0)
                {
                    throw new ValidationException("Debe seleccionar una fila");
                }

                var premioSelected = (Premio)this.dataGridViewPremios.SelectedRows[0].DataBoundItem;

                if (premioSelected == null)
                {
                    throw new ValidationException("Debe seleccionar una fila");
                }

                var editarPremioView = new EditarPremioView(this, premioSelected.Id);
                editarPremioView.Show();
            }
            catch (ValidationException vex)
            {
                MessageBox.Show(vex.Message);
            }
            catch (Exception ex)
            {
                this.errorProvider.SetError(this.buttoEditar, "ERROR: No se pudo editar el premio.\n" + ex.Message);
            }

        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void RefreshTablaPremios()
        {
            this.dataGridViewPremios.DataSource = _premioLogic.ObtenerPremios();
        }
    }
}
