using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace daedalus_creation
{
    abstract class generator
    {
        public Random rnd = new Random();
        public Grid grid;
        public Timer timer;
        public Renderer renderer;
        private Node old_node;
        public Node current_node;

        /// <summary>
        /// Initalize object, starting point is 0,0
        /// </summary>
        /// <param name="Grid">Grid instance</param>
        public generator(Grid Grid)
            : this(Grid, Grid.node_by_vector(new Vector2(0, 0)))
        {

        }
        /// <summary>
        /// Initalize object
        /// </summary>
        /// <param name="Grid">Grid instance</param>
        /// <param name="starting_point">Node to start from</param>
        public generator(Grid Grid, Node starting_point)
        {
            grid = Grid;
            current_node = starting_point;
            old_node = current_node;
            grid.reset();
        }

        /// <summary>
        /// Just run the algorithm without visualisation
        /// </summary>
        public void run()
        {
            while (step() == true)
            {

            }
        }

        /// <summary>
        /// Run the algorithm with visualisation
        /// </summary>
        /// <param name="delay">Delay in milliseconds</param>
        public void run(int delay, Renderer Renderer)
        {
            renderer = Renderer;
            // If the delay is not 0 milliseconds use the timer and its event
            if (delay != 0)
            {
                timer = new Timer(delay);
                timer.Elapsed += OnTimedEvent;
                timer.Start();
            }
            // If the delay is 0 just draw after every step
            else
            {
                while (step() != false)
                {
                    renderer.draw_node(old_node);
                    foreach (Node neighbour in grid.get_surroundings(current_node, true, false, false))
                    {
                        renderer.draw_node(neighbour);
                    }
                    renderer.draw_node(current_node, Color.LightSeaGreen);
                    old_node = current_node;
                }
            }

        }
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (step() == false)
            {
                timer.Stop();
            }
            else
            {
                renderer.draw_node(old_node);
                foreach (Node neighbour in grid.get_surroundings(current_node, true, false, false))
                {
                    renderer.draw_node(neighbour);
                }
                renderer.draw_node(current_node, Color.LightSeaGreen);
                old_node = current_node;
            }
        }

        /// <summary>
        /// Run one step of the algorithm
        /// </summary>
        /// <returns>False if the maze is complete</returns>
        public virtual bool step()
        {
            return false;
        }
    }
}
