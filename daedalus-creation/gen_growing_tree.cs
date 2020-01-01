using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daedalus_creation
{
    class gen_growing_tree : generator
    {
        List<Node> nodes = new List<Node>();
        int config = 0;

        /// <summary>
        /// Initalize object, starting point is 0,0
        /// </summary>
        /// <param name="Grid">Grid instance</param>
        public gen_growing_tree(Grid Grid, int Config)
            : this(Grid, Config, Grid.node_by_vector(new Vector2(0, 0))) { }
        /// <summary>
        /// Initalize object
        /// </summary>
        /// <param name="Grid">Grid instance</param>
        /// <param name="Config">0 = Always chooose the newest node (Mimics recurive backtracker), 1 = Choose at random (Mimic Prim's algorithm)</param>
        /// <param name="starting_point">Node to start from</param>
        public gen_growing_tree(Grid Grid, int Config, Node starting_point) : base(Grid, starting_point) 
        {
            nodes.Add(starting_point);
            config = Config;
        }
        
        /// <summary>
        /// Run one step of the algorithm
        /// </summary>
        /// <returns>False if the maze is complete</returns>
        public override bool step()
        {
            // The maze is complete
            if (nodes.Count == 0)
            {
                return false;
            }
            current_node = get_node();
            List<Node> neighbours = grid.get_surroundings(current_node, true, true, false);
            // There are no unvisited neighbours, remove the node from nodes
            if (neighbours == null)
            {
                nodes.Remove(current_node);
                return true;
            }
            else
            {
                Node old_node = current_node;
                current_node = neighbours[rnd.Next(neighbours.Count)];
                grid.remove_wall(old_node, current_node);
                nodes.Add(current_node);
                current_node.visited = true;
                return true;
            }

        }

        /// <summary>
        /// Returns a new node for the algorithm, depending on how you choose this node, the behaviour of this algorithm drasticly changes
        /// </summary>
        /// <returns></returns>
        private Node get_node()
        {
            if (config == 1)
            {
                return nodes[rnd.Next(nodes.Count)];
            }
            else
            {
                return nodes[nodes.Count-1];
            }
        }

    }
}
