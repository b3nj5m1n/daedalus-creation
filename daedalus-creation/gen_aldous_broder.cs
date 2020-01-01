using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daedalus_creation
{
    // Disclaimer: this algorithm is shit
    class gen_aldous_broder : generator
    {
        // Visited count to keep track of how many nodes we have visited
        int visited_count = 1;

        /// <summary>
        /// Initalize object, starting point is 0,0
        /// </summary>
        /// <param name="Grid">Grid instance</param>
        public gen_aldous_broder(Grid Grid)
            : this(Grid, Grid.node_by_vector(new Vector2(0, 0))) { }
        /// <summary>
        /// Initalize object
        /// </summary>
        /// <param name="Grid">Grid instance</param>
        /// <param name="starting_point">Node to start from</param>
        public gen_aldous_broder(Grid Grid, Node starting_point) : base(Grid, starting_point) { }

        /// <summary>
        /// Run one step of the algorithm
        /// </summary>
        /// <returns>False if the maze is complete</returns>
        public override bool step()
        {
            // Set visited property of node to true
            current_node.visited = true;
            // Run until all nodes in the grid have been visited
            if (visited_count < grid.size[0] * grid.size[1])
            {
                List<Node> neigbours = grid.get_surroundings(current_node, true, false, false);
                // Store old node temporarily to set it as parent of the new node
                Node old_node = current_node;
                // Set current node to random neighbour of the current node
                current_node = neigbours[rnd.Next(neigbours.Count)];
                if (current_node.visited == false)
                {
                    // Visit the current node
                    current_node.visited = true;
                    // Increase visited count
                    visited_count++;
                    // Remove the wall between the old and the current node
                    grid.remove_wall(old_node, current_node);
                }
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
