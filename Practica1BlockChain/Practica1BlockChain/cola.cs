﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1Estructuras
{
    public partial class cola : Form
    {
        public cola()
        {
            InitializeComponent();
        }

        private void cola_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            adMensajes a = new adMensajes();
            a.Show();

        }
    }
}
