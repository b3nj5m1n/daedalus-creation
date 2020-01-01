using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daedalus_creation
{
    class Renderer
    {
        Theme theme;
        Grid grid;
        Canvas_Form form;
        Graphics graphics;

        public Renderer(Grid Grid, Canvas_Form Form, Graphics Graphics)
        {
            grid = Grid;
            form = Form;
            theme = new Theme();
            graphics = Graphics;
        }

        /// <summary>
        /// Get appropriate size of a node on the x axis in order to be able to fill the whole canvas
        /// </summary>
        /// <returns></returns>
        public float get_node_size_x()
        {
            return ((float)form.ClientRectangle.Width / (float)grid.size[0]) - (((float)form.ClientRectangle.Width / (float)grid.size[0]) / (float)theme.wall_factor);
        }

        /// <summary>
        /// Get appropriate size of a node on the y axis in order to be able to fill the whole canvas
        /// </summary>
        /// <returns></returns>
        public float get_node_size_y()
        {
            return ((float)form.ClientRectangle.Height / (float)grid.size[1]) - (((float)form.ClientRectangle.Height / (float)grid.size[1]) / (float)theme.wall_factor);
        }

        /// <summary>
        /// Get appropriate size of a wall on the x axis in order to be able to fill the whole canvas
        /// </summary>
        /// <returns></returns>
        public float get_wall_size_x()
        {
            return (((float)form.ClientRectangle.Width / (float)grid.size[0]) / (float)theme.wall_factor);
        }

        /// <summary>
        /// Get appropriate size of a wall on the y axis in order to be able to fill the whole canvas
        /// </summary>
        /// <returns></returns>
        public float get_wall_size_y()
        {
            return (((float)form.ClientRectangle.Height / (float)grid.size[1]) / (float)theme.wall_factor);
        }

        /// <summary>
        /// Draw a single node using specific colors
        /// </summary>
        /// <param name="node">Node to draw</param>
        /// <param name="c_node">Color for the node</param>
        /// <param name="c_swall">Color for the south wall</param>
        /// <param name="c_ewall">Color for the east wall</param>
        /// <param name="c_bg"></param>
        public void draw_node(Node node, Color c_node, Color c_swall, Color c_ewall, Color c_bg)
        {
            // Calculate position of node
            float n_pos_x = node.coordinates.x * (get_node_size_x() + get_wall_size_x());
            float n_pos_y = node.coordinates.y * (get_node_size_y() + get_wall_size_y());
            // Draw node
            graphics.FillRectangle(new SolidBrush(c_node), n_pos_x, n_pos_y, get_node_size_x(), get_node_size_y());
            // Calculate position of east wall
            float ew_pos_x = (node.coordinates.x * (get_node_size_x() + get_wall_size_x())) + get_node_size_x();
            float ew_pos_y = node.coordinates.y * (get_node_size_y() + get_wall_size_y());
            // Draw east wall
            graphics.FillRectangle(new SolidBrush(c_ewall), ew_pos_x, ew_pos_y, get_wall_size_x(), get_node_size_y());
            // Calculate position of south wall
            float s_pos_x = node.coordinates.x * (get_node_size_x() + get_wall_size_x());
            float s_pos_y = (node.coordinates.y * (get_node_size_y() + get_wall_size_y())) + get_node_size_y();
            // Draw south wall
            graphics.FillRectangle(new SolidBrush(c_swall), s_pos_x, s_pos_y, get_node_size_x(), get_wall_size_y());
            // Calculate position of fill
            float fill_pos_x = s_pos_x + get_node_size_x();
            float fill_pos_y = ew_pos_y + get_node_size_y();
            // Draw fill
            graphics.FillRectangle(new SolidBrush(c_bg), fill_pos_x, fill_pos_y, get_wall_size_x(), get_wall_size_y());
        }

        /// <summary>
        /// Draw a single node using the default colors specified in the theme
        /// </summary>
        /// <param name="node">Node to draw</param>
        public void draw_node(Node node)
        {
            Color c_node = node.special ? theme.color_special : theme.color_default;
            Color c_swall = node.walls.south_active ? theme.color_wall : theme.color_default;
            c_swall = node.special ? theme.color_special : c_swall;
            Color c_ewall = node.walls.east_active ? theme.color_wall : theme.color_default;
            c_ewall = node.special ? theme.color_special : c_ewall;
            Color c_bg = node.special ? theme.color_special : theme.color_wall;
            draw_node(node, c_node, c_swall, c_ewall, c_bg);
        }

        /// <summary>
        /// Loop over every node in the grid and draw it to the screen
        /// </summary>
        public void draw_grid()
        {
            for (int x = 0; x < grid.size[0]; x++)
            {
                for (int y = 0; y < grid.size[1]; y++)
                {
                    draw_node(grid.node_by_vector(new Vector2(x, y)));
                }
            }
        }

        /// <summary>
        /// Remove the wall between two nodes
        /// </summary>
        /// <param name="n1">First Node</param>
        /// <param name="n2">Second Node</param>
        public void remove_wall(Node n1, Node n2)
        {
            Console.WriteLine("Removing wall between " + n1.coordinates.ToString() + " and " + n2.coordinates.ToString());
            Node R = grid.get_right(n1, true, false, false);
            Console.WriteLine(R.coordinates.ToString() + "," + n1.coordinates.ToString() + "," + n2.coordinates.ToString());
            // Test if node 2 is to the right of node 1
            if (R.coordinates.x == n2.coordinates.x && R.coordinates.y == n2.coordinates.y)
            {
                Console.WriteLine("...");
                // Disable east wall of node 1 to make a connection between the two
                n1.walls.east_active= false;
            }
            // Test if node 2 is to the left of node 1
            if (grid.get_left(n1, true, false, false) == n2)
            {
                // Disable east wall of node 2 to make a connection between the two
                n2.walls.east_active = false;
            }
            // Test if node 2 is to the top of node 1
            if (grid.get_up(n1, true, false, false) == n2)
            {
                // Disable south wall of node 2 to make a connection between the two
                n2.walls.south_active = false;
            }
            // Test if node 2 is to the bottom of node 1
            if (grid.get_down(n1, true, false, false) == n2)
            {
                // Disable south wall of node 1 to make a connection between the two
                n1.walls.south_active = false;
            }
        }

    }
}
