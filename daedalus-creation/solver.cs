using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daedalus_creation
{
    abstract class solver
    {
        public Grid grid;
        public Vector2 starting_point;
        public Vector2 end_point;

        public solver(Grid Grid, Vector2 Starting_point, Vector2 End_point)
        {
            grid = Grid;
            starting_point = Starting_point;
            end_point = End_point;
        }

<<<<<<< HEAD
<<<<<<< HEAD
        /// <summary>
        /// Just run the algorithm without visualisation
        /// </summary>
        public bool run()
        {
            //while (step() == true)
            //{

            //}
            //return true;
            step();
            return true;
        }

        /// <summary>
        /// Run the algorithm with visualisation
        /// </summary>
        /// <param name="delay">Delay in milliseconds</param>
        public bool run(int delay, Renderer Renderer)
        {
            renderer = Renderer;
            step();
            return true;
            //// If the delay is not 0 milliseconds use the timer and its event
            //if (delay != 0)
            //{
            //    timer = new Timer(delay);
            //    timer.Elapsed += OnTimedEvent;
            //    timer.Start();
            //    return true;
            //}
            //// If the delay is 0 just draw after every step
            //else
            //{

            //}
            //return false;
        }
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
       
        }

        public virtual bool step()
        {
            return false;
        }

        public virtual List<Node> get_path()
=======
        public virtual List<Node> solve()
>>>>>>> parent of 0055e3b... Started work on solving visualisation; ASTAR NOT WORKING PROPERLY
=======
        public virtual List<Node> solve()
>>>>>>> parent of 0055e3b... Started work on solving visualisation; ASTAR NOT WORKING PROPERLY
        {
            return null;
        }


    }
}
