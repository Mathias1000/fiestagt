using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FiestaGT.Commons.Exceptions;
using FiestaGT.Commons.Dto;
using FiestaGT.Logic;

namespace FiestaGt.Guilds
{
    public partial class NuevaGuildView : Form
    {
        private static GuildsView _guildsView;

        private static GuildLogic _guildLogic = new GuildLogic();

        public NuevaGuildView(GuildsView guildsView)
        {
            InitializeComponent();

            _guildsView = guildsView;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.textBoxNombre.Text))
                {
                    throw new ValidationException("Debe ingresar un nombre");
                }

                var dto = new GuildDto();
                dto.Nombre = this.textBoxNombre.Text;
                dto.Activo = true;

                _guildLogic.CrearGuild(dto);

                _guildsView.RefreshTablaGuilds();

                this.Close();
            }
            catch (ValidationException vex)
            {
                MessageBox.Show(vex.Message);
            }
            catch (Exception ex)
            {
                this.errorProvider.SetError(this.buttonGuardar, "ERROR: No se pudo guardar la guild.\n" + ex.Message);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
