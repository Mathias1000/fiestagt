using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FiestaGT.Logic;

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

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
