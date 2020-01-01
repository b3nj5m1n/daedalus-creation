using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daedalus_creation
{
    class gen_hunt_and_kill : generator
    {
        /// <summary>
        /// Initalize object, starting point is 0,0
        /// </summary>
        /// <param name="Grid">Grid instance</param>
        public gen_hunt_and_kill(Grid Grid)
            : this(Grid, Grid.node_by_vector(new Vector2(0, 0))) { }
        /// <summary>
        /// Initalize object
        /// </summary>
        /// <param name="Grid">Grid instance</param>
        /// <param name="starting_point">Node to start from</param>
        public gen_hunt_and_kill(Grid Grid, Node starting_point) : base(Grid, starting_point) { }

        /// <summary>
        /// Run one step of the algorithm
        /// </summary>
        /// <returns>False if the maze is complete</returns>
        public override bool step()
        {
            // Set visited property of node to true
            current_node.visited = true;
            List<Node> neigbours = grid.get_surroundings(current_node, true, true, false);
            if (neigbours == null)
            {
                return hunt();
            }
            else
            {
                return kill(neigbours);
            }
        }

        private bool hunt()
        {
            // Loop over rows
            for (int y = 0; y < grid.size[1]; y++)
            {
                // Loop over cells and look for unvisited ones
                for (int x = 0; x < grid.size[0]; x++)
                {
                    Node n = grid.node_by_vector(new Vector2(x, y));
                    // If we find an unvisited cell and it has at least one unvisited neighbour, set it as current node and connect it to one of the visited neighbours
                    if (n.visited == false)
                    {
                        if (grid.get_surroundings(n, true, true, false) != null)
                        {
                            current_node = n;
                            // Get visited neighbours
                            List<Node> visited_neighbours = grid.get_surroundings(current_node, true, false, false);
                            List<Node> unvisited_neighbours = grid.get_surroundings(current_node, true, true, false);
                            foreach (Node neighbour  in unvisited_neighbours)
                            {
                                if (neighbour.visited == false)
                                {
                                    visited_neighbours.Remove(neighbour);
                                }
                            }
                            grid.remove_wall(current_node, visited_neighbours[rnd.Next(visited_neighbours.Count)]);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool kill(List<Node> neigbours)
        {
            // Store old node temporarily to set it as parent of the new node
            Node old_node = current_node;
            // Set current node to random neighbour of the current node
            current_node = neigbours[rnd.Next(neigbours.Count)];
            // Set parent of the current node to the old node
            current_node.parent = old_node;
            // Visit the current node
            current_node.visited = true;
            // Remove the wall between the old and the current node
            grid.remove_wall(old_node, current_node);
            return true;
        }

    }
}
