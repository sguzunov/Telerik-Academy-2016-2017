namespace CoordinateSystem
{
    public struct Point3D
    {
        private static readonly Point3D coordiateSystemCenter;

        static Point3D()
        {
            coordiateSystemCenter = new Point3D(0, 0, 0);
        }

        public Point3D(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point3D CoordinateSystemCenter
        {
            get
            {
                return coordiateSystemCenter;
            }
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

        public override string ToString()
        {
            return $"[Z={this.X}, Y={this.Y}, Z={this.Z}]";
        }
    }
}
