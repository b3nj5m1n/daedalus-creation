using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;

namespace daedalus_creation
{
    /// <summary>
    /// Maze generate using the recursive backtracking algorithm
    /// </summary>
    class gen_recursive_backtracking
    {
        Random rnd = new Random();
        public Grid grid;
        Timer timer;
        Renderer renderer;
        // This implementation will use the parent node attribute of the node class instead of a stack
        public Node current_node;

        /// <summary>
        /// Initalize object, starting point is 0,0
        /// </summary>
        /// <param name="Grid">Grid instance</param>
        public gen_recursive_backtracking(Grid Grid)
            : this(Grid, Grid.node_by_vector(new Vector2(0, 0)))
        {
            
        }
        /// <summary>
        /// Initalize object
        /// </summary>
        /// <param name="Grid">Grid instance</param>
        /// <param name="starting_point">Node to start from</param>
        public gen_recursive_backtracking(Grid Grid, Node starting_point)
        {
            grid = Grid;
            current_node = starting_point;
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
            timer = new Timer(delay);
            timer.Elapsed += OnTimedEvent;
            timer.Start();
        }
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (step() == false)
            {
                timer.Stop();
            }
            else
            {
                foreach (Node neighbour in grid.get_surroundings(current_node, true, false, false))
                {
                    renderer.draw_node(neighbour);
                }
                renderer.draw_node(current_node, Color.LightSeaGreen);
            }
        }

        /// <summary>
        /// Run one step of the algorithm
        /// </summary>
        /// <returns>False if the maze is complete</returns>
        public bool step()
        {
            // Visited count to keep track of how many nodes we have visited
            int visited_count = 1;
            // Set visited property of node to true
            current_node.visited = true;
            // Varible to store the last coordinates
            Node old_coords = current_node;
            // Run until all nodes in the grid have been visited
            if (visited_count < grid.size[0] * grid.size[1])
            {
                List<Node> neigbours = grid.get_surroundings(current_node, true, true, false);
                if (neigbours == null)
                {
                    // There are no neighbours left and the current node is the starting point
                    if (current_node.parent == null)
                    {
                        return false;
                    }
                    // There are no neighbours, backtrack
                    current_node = current_node.parent;
                }
                else
                {
                    // Store old node temporarily to set it as parent of the new node
                    Node old_node = current_node;
                    // Set current node to random neighbour of the current node
                    current_node = neigbours[rnd.Next(neigbours.Count)];
                    // Set parent of the current node to the old node
                    current_node.parent = old_node;
                    // Visit the current node
                    current_node.visited = true;
                    // Increase visited count
                    visited_count++;
                    // Remove the wall between the old and the current node
                    grid.remove_wall(old_node, current_node);
                }
            }
            return true;
        }


    }
}
