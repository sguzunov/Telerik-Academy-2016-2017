namespace PointCircleRectangle
{
    /* Write a program that reads a pair of coordinates x and y and uses an expression to checks for given point (x, y) if it is within the circle K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2).     */

    using System;
    using System.Globalization;
    using System.Threading;
    class Program
    {
        static float centerX = 1f;
        static float centerY = 1f;
        static float radius = 1.5f;
        static float rectangleTopY = 1f;
        static float rectangleLeftX = -1f;
        static float rectangleWidth = 6f;
        static float rectangleHeight = 2f;

        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            float x = float.Parse(Console.ReadLine());
            float y = float.Parse(Console.ReadLine());

            float xDistanceToCenter = Math.Abs(x - centerX);
            float yDistanceToCenter = Math.Abs(y - centerY);
            float distanceToCenter = (float)Math.Sqrt((xDistanceToCenter * xDistanceToCenter) + (yDistanceToCenter * yDistanceToCenter));
            bool isInsideCircle = distanceToCenter <= radius; //

            float rectangleBottomY = rectangleTopY + rectangleHeight;
            float rectangleRightX = rectangleLeftX + rectangleWidth;
            bool isInsideRectangle = (rectangleLeftX <= x || x <= rectangleRightX) && (rectangleBottomY <= y || y <= rectangleTopY);

            string result = string.Empty;
            if (isInsideCircle)
            {
                result += "inside circle ";
            }
            else
            {
                result += "outside circle ";
            }

            if (isInsideRectangle)
            {
                result += "inside rectangle";
            }
            else
            {
                result += "outside rectangle";
            }

            Console.WriteLine(result);
        }
    }
}
