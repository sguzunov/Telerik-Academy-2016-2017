using System.Collections.Generic;

namespace LabyrinthNxN
{
    public class Position
    {
        public Position()
        {
            this.Neighbours = new List<Position>();
        }

        public int X { get; set; }

        public int Y { get; set; }

        public ICollection<Position> Neighbours;
    }
}
