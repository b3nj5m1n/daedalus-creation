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

        Grid g;
        Renderer r;
        generator gen;
        private void test()
        {
            g = new Grid(new int[2] { 15, 15 });
            g.initalize();
            r = new Renderer(g, this, this.CreateGraphics());
            r.draw_grid();
            Thread.Sleep(0);
            //g.remove_wall(g.node_by_vector(new Vector2(5, 5)), g.node_by_vector(new Vector2(4, 5)));
            //gen = new gen_recursive_backtracking(g);
            generator gen = new gen_hunt_and_kill(g);
            //generator gen = new gen_aldous_broder(g);
            //generator gen = new gen_growing_tree(g, 1);
            //generator gen = new gen_binary_tree(g, 3);
            gen.run(5, r);
            //r.draw_grid();
            //r.draw_connection(g.node_by_vector(new Vector2(2,0)), g.node_by_vector(new Vector2(1,0)));

            

        }

        private void Canvas_Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                test();
            }
            if (e.KeyChar == Convert.ToChar(Keys.P))
            {
                test2();
            }
        }

        private void test2()
        {
            //List<Node> path = new List<Node>();
            //path.Add(g.node_by_vector(new Vector2(10, 10)));
            //while (path[path.Count - 1].parent != null)
            //{
            //    path.Add(path[path.Count - 1].parent);
            //}
            //r.draw_path(path);
            List<Node> path = new List<Node>();
            solver slv = new slv_astar(g, new Vector2(0,0), new Vector2(14, 14));
            path = slv.solve();
            r.draw_path(path);
        }
    }
}
