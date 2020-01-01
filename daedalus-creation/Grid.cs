using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daedalus_creation
{
    class Grid
    {
        Node[,] grid;
        int[] size;

        Grid(int[] Size)
        {
            size = Size;
        }

        /// <summary>
        /// Initialize the grid / reset it
        /// </summary>
        public void initalize()
        {

        }

        /// <summary>
        /// Remove the grid
        /// </summary>
        public void remove()
        {

        }

        /// <summary>
        /// Get the node upwards of the given one
        /// </summary>
        /// <param name="node">Which node to go off</param>
        /// <param name="exists">Only returns the node if it exists</param>
        /// <param name="unvisited">Only returns the node if it hasn't been visited</param>
        /// <param name="valid">Only returns the node if there are no walls in between of the two</param>
        /// <returns></returns>
        public Node get_up(Node node, bool exists, bool unvisited, bool valid)
        {
            return null;
        }

        /// <summary>
        /// Get the node downwards of the given one
        /// </summary>
        /// <param name="node">Which node to go off</param>
        /// <param name="exists">Only returns the node if it exists</param>
        /// <param name="unvisited">Only returns the node if it hasn't been visited</param>
        /// <param name="valid">Only returns the node if there are no walls in between of the two</param>
        /// <returns></returns>
        public Node get_down(Node node, bool exists, bool unvisited, bool valid)
        {
            return null;
        }

        /// <summary>
        /// Get the node to the right of the given one
        /// </summary>
        /// <param name="node">Which node to go off</param>
        /// <param name="exists">Only returns the node if it exists</param>
        /// <param name="unvisited">Only returns the node if it hasn't been visited</param>
        /// <param name="valid">Only returns the node if there are no walls in between of the two</param>
        /// <returns></returns>
        public Node get_right(Node node, bool exists, bool unvisited, bool valid)
        {
            return null;
        }

        /// <summary>
        /// Get the node to the left of the given one
        /// </summary>
        /// <param name="node">Which node to go off</param>
        /// <param name="exists">Only returns the node if it exists</param>
        /// <param name="unvisited">Only returns the node if it hasn't been visited</param>
        /// <param name="valid">Only returns the node if there are no walls in between of the two</param>
        /// <returns></returns>
        public Node get_left(Node node, bool exists, bool unvisited, bool valid)
        {
            return null;
        }

        /// <summary>
        /// Get all the surrounding nodes
        /// </summary>
        /// <param name="node">Which node to go off</param>
        /// <param name="exists">Only returns the node if it exists</param>
        /// <param name="unvisited">Only returns the node if it hasn't been visited</param>
        /// <param name="valid">Only returns the node if there are no walls in between of the two</param>
        /// <returns></returns>
        public List<Node> get_surroundings(Node node, bool exists, bool unvisited, bool valid)
        {
            return null;
        }

    }
}
