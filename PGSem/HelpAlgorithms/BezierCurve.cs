using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MathNet.Numerics.Interpolation;

public static class BezierCurve
{
    public static List<(double x, double y)> FindCenterLine(byte[,] image)
    {
        int height = image.GetLength(0);
        int width = image.GetLength(1);
        List<(double x, double y)> centerLine = new List<(double x, double y)>();

        for (int y = 0; y < height; y++)
        {
            int sumX = 0, count = 0;
            for (int x = 0; x < width; x++)
            {
                if (image[y, x] == 255) // Biela oblasť
                {
                    sumX += x;
                    count++;
                }
            }

            if (count > 0)
            {
                double avgX = sumX / (double)count;
                centerLine.Add((avgX, y));
            }
        }
        return centerLine;
    }

    public static CubicSpline FitBezierCurve(List<(double x, double y)> centerLine)
    {
        var validPoints = centerLine.Where(p => p.x >= 0).ToList();
        if (validPoints.Count < 4)
        {
            throw new Exception("Not enought points to create bezier curve");
        }

        double[] xValues = validPoints.Select(p => p.y).ToArray();
        double[] yValues = validPoints.Select(p => p.x).ToArray();

        return CubicSpline.InterpolateNatural(xValues, yValues);
    }

    public static List<(double x, double y)> SampleBezierCurve(CubicSpline curve, int height, int step = 20)
    {
        List<(double x, double y)> bezierPoints = new List<(double x, double y)>();

        for (int y = 0; y < height; y += step)
        {
            double x = curve.Interpolate(y);
            bezierPoints.Add((x, y));
        }

        return bezierPoints;
    }

    public static Bitmap DrawBezierOnBitmap(List<(double x, double y)> bezierCurve, int width, int height)
    {
        Bitmap bitmap = new Bitmap(width, height);

        using (Graphics g = Graphics.FromImage(bitmap))
        {
            g.Clear(Color.White);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (bezierCurve.Count > 1)
            {
                PointF[] points = bezierCurve.Select(p => new PointF((float)p.x, (float)p.y)).ToArray();
                using (Pen bezierPen = new Pen(Color.Red, 2))
                {
                    g.DrawCurve(bezierPen, points);
                }
            }
        }
        return bitmap;
    }
}
