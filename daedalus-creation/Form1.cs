using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            Thread.Sleep(0);
            //g.remove_wall(g.node_by_vector(new Vector2(5, 5)), g.node_by_vector(new Vector2(4, 5)));
            // generator gen = new gen_recursive_backtracking(g);
            //generator gen = new gen_hunt_and_kill(g);
            //generator gen = new gen_aldous_broder(g);
            //generator gen = new gen_growing_tree(g, 1);
            generator gen = new gen_binary_tree(g, 3);
            gen.run(50, r);
            // r.draw_grid();
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
