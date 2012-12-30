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

namespace FiestaGt.Guilds
{
    public partial class GuildsView : Form
    {
        private static GuildLogic _guildLogic = new GuildLogic();

        public GuildsView()
        {
            InitializeComponent();

            this.dataGridViewGuilds.DataSource = _guildLogic.ObtenerGuilds();
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            this.dataGridViewGuilds.DataSource = _guildLogic.BuscarGuilds(this.textBoxBuscar.Text);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.dataGridViewGuilds.DataSource = _guildLogic.ObtenerGuilds();
        }

        public void RefreshTablaGuilds()
        {
            this.dataGridViewGuilds.DataSource = _guildLogic.ObtenerGuilds();
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            var nuevaGuildView = new NuevaGuildView(this);
            nuevaGuildView.Show();
        }

        private void buttoEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridViewGuilds.SelectedRows == null || this.dataGridViewGuilds.SelectedRows.Count == 0)
                {
                    throw new ValidationException("Debe seleccionar una fila");
                }

                var guildSelected = (Guild)this.dataGridViewGuilds.SelectedRows[0].DataBoundItem;

                if (guildSelected == null)
                {
                    throw new ValidationException("Debe seleccionar una fila");
                }

                var editarGuildView = new EditarGuildView(this, guildSelected.Id);
                editarGuildView.Show();
            }
            catch (ValidationException vex)
            {
                MessageBox.Show(vex.Message);
            }
            catch (Exception ex)
            {
                this.errorProvider.SetError(this.buttoEditar, "ERROR: No se pudo editar la guild.\n" + ex.Message);
            }

            
        }



    }
}
