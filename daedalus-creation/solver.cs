using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace daedalus_creation
{
    abstract class solver
    {
        public Grid grid;
        public Node Start;
        public Node Destination;
        public Timer timer;
        public Renderer renderer;
        public Random rnd = new Random();
        private Node old_node;
        public Node current_node;

        public solver(Grid Grid, Vector2 Starting_point, Vector2 End_point)
        {
            grid = Grid;
            Start = grid.node_by_vector(Starting_point);
            Destination = grid.node_by_vector(End_point);
            old_node = current_node;
        }

        /// <summary>
        /// Just run the algorithm without visualisation
        /// </summary>
        public List<Node> run()
        {
            while (step() == true)
            {

            }
            return get_path();
        }

        /// <summary>
        /// Run the algorithm with visualisation
        /// </summary>
        /// <param name="delay">Delay in milliseconds</param>
        public bool run(int delay, Renderer Renderer)
        {
            renderer = Renderer;
            // If the delay is not 0 milliseconds use the timer and its event
            if (delay != 0)
            {
                timer = new Timer(delay);
                timer.Elapsed += OnTimedEvent;
                timer.Start();
                return true;
            }
            // If the delay is 0 just draw after every step
            else
            {
                while (step() != false)
                {
                    foreach (Node neighbour in grid.get_surroundings(current_node, true, false, true))
                    {
                        renderer.draw_node(neighbour, Color.LightPink);
                    }
                    renderer.draw_node(current_node, Color.LightSeaGreen);
                }
                return true;
            }

        }
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            timer.Stop();
            if (step() == true)
            {
                foreach (Node neighbour in grid.get_surroundings(current_node, true, false, true))
                {
                    renderer.draw_node(neighbour, Color.LightPink);
                }
                renderer.draw_node(current_node, Color.LightSeaGreen);
                timer.Start();
            }
        }

        public virtual bool step()
        {
            return false;
        }

        public virtual List<Node> get_path()
        {
            return null;
        }


    }
}
