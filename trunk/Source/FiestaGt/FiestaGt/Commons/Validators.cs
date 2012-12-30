using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiestaGt.Commons
{
    public class Validators
    {
        public void SoloNumeros(KeyPressEventArgs e)
        {
            String Aceptados = "0123456789" + Convert.ToChar(8);

            if (Aceptados.Contains("" + e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
