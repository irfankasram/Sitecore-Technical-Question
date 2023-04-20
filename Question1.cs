public class Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public void Move(double dX, double dY)
    {
        X += dX;
        Y += dY;
    }

    public void Rotate(double angle)
    {
        double newX = X * Math.Cos(angle) - Y * Math.Sin(angle);
        double newY = X * Math.Sin(angle) + Y * Math.Cos(angle);
        X = newX;
        Y = newY;
    }
}

public class Line
{
    public Point Start { get; set; }
    public Point End { get; set; }

    public Line(Point start, Point end)
    {
        Start = start;
        End = end;
    }

    public double Length()
    {
        return Math.Sqrt(Math.Pow(End.X - Start.X, 2) + Math.Pow(End.Y - Start.Y, 2));
    }

    public void Move(double dX, double dY)
    {
        Start.Move(dX, dY);
        End.Move(dX, dY);
    }

    public void Rotate(double angle)
    {
        Start.Rotate(angle);
        End.Rotate(angle);
    }
}

public class Circle
{
    public Point Center { get; set; }
    public double Radius { get; set; }

    public Circle(Point center, double radius)
    {
        Center = center;
        Radius = radius;
    }

    public double Area()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }

    public double Circumference()
    {
        return 2 * Math.PI * Radius;
    }

    public void Move(double dX, double dY)
    {
        Center.Move(dX, dY);
    }

    public void Rotate(double angle)
    {
        Center.Rotate(angle);
    }
}

public class Aggregation
{
    private List<object> figures;

    public Aggregation()
    {
        figures = new List<object>();
    }

    public void AddFigure(object figure)
    {
        figures.Add(figure);
    }

    public void Move(double dX, double dY)
    {
        foreach (object figure in figures)
        {
            if (figure is Point point)
            {
                point.Move(dX, dY);
            }
            else if (figure is Line line)
            {
                line.Move(dX, dY);
            }
            else if (figure is Circle circle)
            {
                circle.Move(dX, dY);
            }
            else if (figure is Aggregation aggregation)
            {
                aggregation.Move(dX, dY);
            }
        }
    }

    public void Rotate(double angle)
    {
        foreach (object figure in _figures)
        {
            if (figure is Point point)
            {
                point.Rotate(angle);
            }
            else if (figure is Line line)
            {
                line.Rotate(angle);
            }
            else if (figure is Circle circle)
            {
                circle.Rotate(angle);
            }
            else if (figure is Aggregation aggregation)
            {
                aggregation.Rotate(angle);
            }
        }
    }
}