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
        /// Draw a single node
        /// </summary>
        /// <param name="node"></param>
        public void draw_node(Node node)
        {
            // Calculate position of node
            float n_pos_x = node.coordinates.x * (get_node_size_x() + get_wall_size_x());
            float n_pos_y = node.coordinates.y * (get_node_size_y() + get_wall_size_y());
            // Draw node
            graphics.FillRectangle(new SolidBrush(Color.White), n_pos_x, n_pos_y, get_node_size_x(), get_node_size_y());
            // Calculate position of east wall
            float ew_pos_x = (node.coordinates.x * (get_node_size_x() + get_wall_size_x())) + get_node_size_x();
            float ew_pos_y = node.coordinates.y * (get_node_size_y() + get_wall_size_y());
            // Draw east wall
            graphics.FillRectangle(new SolidBrush(Color.Red), ew_pos_x, ew_pos_y, get_wall_size_x(), get_node_size_y());
            // Calculate position of south wall
            float s_pos_x = node.coordinates.x * (get_node_size_x() + get_wall_size_x());
            float s_pos_y = (node.coordinates.y * (get_node_size_y() + get_wall_size_y())) + get_node_size_y();
            // Draw south wall
            graphics.FillRectangle(new SolidBrush(Color.Green), s_pos_x, s_pos_y, get_node_size_x(), get_wall_size_y());
            // Calculate position of fill

            // Draw fill

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
