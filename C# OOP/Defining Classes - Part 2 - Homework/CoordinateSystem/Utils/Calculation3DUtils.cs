namespace CoordinateSystem.Utils
{
    using System;

    public static class Calculation3DUtils
    {
        public static double CalculateDistanceBetweenTwoPoints(Point3D firstPoint, Point3D secondPoint)
        {
            double xDifference = firstPoint.X - secondPoint.X;
            double yDifference = firstPoint.Y - secondPoint.Y;
            double zDifference = firstPoint.Z - secondPoint.Z;
            double distance = Math.Sqrt(xDifference * xDifference + yDifference * yDifference + zDifference * zDifference);
            return distance;
        }
    }
}
