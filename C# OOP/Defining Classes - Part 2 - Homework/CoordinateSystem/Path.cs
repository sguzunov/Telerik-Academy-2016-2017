namespace CoordinateSystem
{
    using System;
    using System.Collections.Generic;

    public class Path
    {
        private List<Point3D> points;

        public Path()
        {
            this.points = new List<Point3D>();
        }

        public Path(List<Point3D> points) : this()
        {
            this.points = points;
        }

        public List<Point3D> Points
        {
            get
            {
                return this.points;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Points cannot be null!");
                }
            }
        }
    }
}
