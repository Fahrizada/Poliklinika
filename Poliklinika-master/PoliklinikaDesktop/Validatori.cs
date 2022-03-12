using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace PoliklinikaDesktop
{
    class Validatori
    {
        private readonly object _sender;
        private readonly CancelEventArgs _e;
        private readonly ErrorProvider _error;
        public Validatori(object sender, CancelEventArgs e, ErrorProvider error)
        {
            _sender = sender;
            _e = e;
            _error = error;
        }
        public void ValidacijaPraznogStringa(TextBox input)
        {
            if (string.IsNullOrWhiteSpace(input.Text))
            {
                _error.SetError(input, Properties.Resources.ValidacijaPolja);
                _e.Cancel = true;
            }
            else
            {
                _error.SetError(input, null);

            }
        }
        public void ValidacijaPraznogStringacmb(ComboBox input)
        {
            if (string.IsNullOrWhiteSpace(input.Text))
            {
                _error.SetError(input, Properties.Resources.ValidacijaPolja);
                _e.Cancel = true;
            }
            else
            {
                _error.SetError(input, null);

            }
        }
        
    }
}
