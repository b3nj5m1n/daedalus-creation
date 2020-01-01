﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace daedalus_creation
{
    public partial class Canvas_Form : Form
    {
        public Canvas_Form()
        {
            InitializeComponent();
        }

        private void Graphics_Load(object sender, EventArgs e)
        {
            
        }

        private void test()
        {
            Grid g = new Grid(new int[2] { 15, 15 });
            g.initalize();
            Renderer r = new Renderer(g, this, this.CreateGraphics());
            r.draw_grid();
            Console.WriteLine(".");
        }

        private void Canvas_Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                test();
            }
        }
    }
}
