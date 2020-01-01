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
        /// Draw a single node using a special color for the node itself and the default colors for the rest
        /// </summary>
        /// <param name="node">Node to draw</param>
        public void draw_node(Node node, Color c_node)
        {
            Color c_swall = node.walls.south_active ? theme.color_wall : theme.color_default;
            c_swall = node.special ? theme.color_special : c_swall;
            Color c_ewall = node.walls.east_active ? theme.color_wall : theme.color_default;
            c_ewall = node.special ? theme.color_special : c_ewall;
            Color c_bg = node.special ? theme.color_special : theme.color_wall;
            draw_node(node, c_node, c_swall, c_ewall, c_bg);
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

    }
}
