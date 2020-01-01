using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daedalus_creation
{
    class gen_binary_tree : generator
    {
        int x = 0;
        int y = 0;
        int config = 0;


        /// <summary>
        /// Initalize object, starting point is 0,0
        /// </summary>
        /// <param name="Grid">Grid instance</param>
        public gen_binary_tree(Grid Grid, int Config)
            : this(Grid, Config, Grid.node_by_vector(new Vector2(0, 0))) { }
        /// <summary>
        /// Initalize object
        /// </summary>
        /// <param name="Grid">Grid instance</param>
        /// <param name="starting_point">Node to start from</param>
        public gen_binary_tree(Grid Grid, int Config, Node starting_point) : base(Grid, starting_point)
        {
            x = starting_point.coordinates.x;
            y = starting_point.coordinates.y;
            config = Config;
        }

        /// <summary>
        /// Run one step of the algorithm
        /// </summary>
        /// <returns>False if the maze is complete</returns>
        public override bool step()
        {
            if (y < grid.size[0])
            {
                if (x < grid.size[1])
                {
                    current_node = grid.node_by_vector(new Vector2(x, y));
                    List<Node> neighbours = get_neighbours();
                    if (neighbours != null)
                    {
                        if (neighbours[1] == null)
                        {
                            neighbours.Remove(neighbours[1]);
                        }
                        if (neighbours[0] == null)
                        {
                            neighbours.Remove(neighbours[0]);
                        }
                        if (neighbours.Count == 0)
                        {
                            x++;
                            return true;
                        }
                        grid.remove_wall(current_node, neighbours[rnd.Next(neighbours.Count)]);
                    }
                    x++;
                    return true;
                } 
                else
                {
                    y++;
                    x = 0;
                    return true;
                }
            } 
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Change config to bias northeast, northwest, southeast or southwest
        /// 0 = north east
        /// 1 = north west
        /// 2 = south east
        /// 3 = south west
        /// </summary>
        /// <returns></returns>
        public List<Node> get_neighbours()
        {
            Node N = grid.get_up(current_node, true, false, false);
            Node S = grid.get_down(current_node, true, false, false);
            Node E = grid.get_right(current_node, true, false, false);
            Node W = grid.get_left(current_node, true, false, false);
            List<Node> result = new List<Node>();
            if (config == 0 || config == 1)
            {
                result.Add(N);
            } 
            else
            {
                result.Add(S);
            }
            if (config == 0 || config == 2)
            {
                result.Add(E);
            }
            else
            {
                result.Add(W);
            }
            return result;
        }


    }
}
