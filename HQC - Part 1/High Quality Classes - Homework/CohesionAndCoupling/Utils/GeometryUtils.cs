namespace CohesionAndCoupling.Utils
{
    using System;

    public class GeometryUtils
    {
        public static double CalculateDistance2D(double x1, double y1, double x2, double y2)
        {
            double firstSide = x2 - x1;
            double secondSide = y2 - y1;

            double distance = Math.Sqrt((firstSide * firstSide) + (secondSide * secondSide));

            return distance;
        }

        public static double CalculateDistance3D(double x1, double y1, double x2, double y2, double z1, double z2)
        {
            double firstSide = x2 - x1;
            double secondSide = y2 - y1;
            double thirdSide = z2 - z1;

            double distance = Math.Sqrt((firstSide * firstSide) + (secondSide * secondSide) + (thirdSide * thirdSide));

            return distance;
        }

        public static double CalculateVolume(double width, double height, double depth)
        {
            double volume = width * height * depth;

            return volume;
        }

        public static double CalculateDiagonalXYZ(double width, double height, double depth)
        {
            double diagonal = CalculateDistance3D(0, 0, width, height, height, depth);

            return diagonal;
        }

        public static double CalculateDiagonalXY(double width, double height)
        {
            double diagonal = CalculateDistance2D(0, 0, width, height);

            return diagonal;
        }

        public static double CalculateDiagonalXZ(double width, double depth)
        {
            double diagonal = CalculateDistance2D(0, 0, width, depth);

            return diagonal;
        }

        public static double CalculateDiagonalYZ(double height, double depth)
        {
            double diagonal = CalculateDistance2D(0, 0, height, depth);

            return diagonal;
        }
    }
}
