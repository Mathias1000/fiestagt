using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FiestaGt.Jugadores;
using FiestaGt.Guilds;

namespace FiestaGt
{
    public partial class FiestaGtForm : Form
    {
        public FiestaGtForm()
        {
            InitializeComponent();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonJugadores_Click(object sender, EventArgs e)
        {
            var jugadoresView = new JugadoresView();
            jugadoresView.Show();
        }

        private void buttonGuilds_Click(object sender, EventArgs e)
        {
            var guildsView = new GuildsView();
            guildsView.Show();
        }
    }
}
