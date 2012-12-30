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

namespace FiestaGt.Guilds
{
    public partial class EditarGuildView : Form
    {

        private static GuildsView _guildsView;

        private static GuildLogic _guildLogic = new GuildLogic();

        private static int _guildId;

        public EditarGuildView(GuildsView guildView, int guildId)
        {
            InitializeComponent();

            _guildsView = guildView;
            _guildId = guildId;

            var guildEdit = _guildLogic.ObtenerGuildById(guildId);

            this.textBoxNombre.Text = guildEdit.Nombre;
            this.checkBoxActiva.Checked = guildEdit.Activo;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.textBoxNombre.Text))
                {
                    throw new ValidationException("Debe ingresar un nombre");
                }

                var guildDto = new GuildDto();

                guildDto.Nombre = this.textBoxNombre.Text;
                guildDto.Id = _guildId;
                guildDto.Activo = this.checkBoxActiva.Checked;

                _guildLogic.EditarGuild(guildDto);

                _guildsView.RefreshTablaGuilds();

                this.Close();
            }
            catch (ValidationException vex)
            {
                MessageBox.Show(vex.Message);
            }
            catch(Exception ex)
            {
                this.errorProvider.SetError(this.buttonGuardar, "ERROR: No se pudo guardar el jugador.\n" + ex.Message);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
