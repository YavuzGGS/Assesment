using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter map dimensions (w,h):");
        string[] dimensions = Console.ReadLine().Split(',');

        int w = int.Parse(dimensions[0]);
        int h = int.Parse(dimensions[1]);

        if (!(h > 0 && w > 0))
        {
            Console.WriteLine("Invalid map dimensions. Map dimensions must be larger than 0");
            return;
        }

        Console.WriteLine("Enter movement coordinates:");
        string[] movements = Console.ReadLine().Split(',');

        int currentX = 0;
        int currentY = 0;
        List<int[]> coordinates = new List<int[]>();
        for (int i = 0; i < movements.Length; i += 2)
        {
            int x = int.Parse(movements[i]);
            int y = int.Parse(movements[i + 1]);
            currentX += x;
            currentY += y;
            while (currentX > w) {currentX -= w;}
            while (currentY > h) {currentY -= h;}
            while (currentX < 0) { currentX += w; }
            while (currentY < 0) { currentY += h; }
            x = currentX;
            y = currentY;
            coordinates.Add(new int[] { x, y });
        }

        Console.WriteLine("Select life form (1 for Human, 2 for Alien):");
        int lifeFormType = int.Parse(Console.ReadLine());

        if (lifeFormType == 1)
        {
            Human human = new Human(coordinates);
            human.ReportPath();
            human.ReportActualCoordinate();
        }
        else if (lifeFormType == 2)
        {
            Alien alien = new Alien(coordinates);
            alien.ReportPath();
            alien.ReportActualCoordinate();
        }
        else
        {
            Console.WriteLine("Invalid life form selection.");
        }
    }
}

class LifeForm
{
    protected List<int[]> coordinates;

    public LifeForm(List<int[]> coordinates)
    {
        this.coordinates = coordinates;
    }

    public virtual void ReportPath()
    {
        Console.WriteLine("Report Path:");
        foreach (var coordinate in coordinates)
        {
            Console.WriteLine($"[{coordinate[0]},{coordinate[1]}]");
        }
    }

    public virtual void ReportActualCoordinate()
    {
        int[] currentCoordinate = coordinates[coordinates.Count - 1];
        Console.WriteLine("Report Actual coordinate:");
        Console.WriteLine($"[{currentCoordinate[0]},{currentCoordinate[1]}]");
    }
}

class Human : LifeForm
{
    public Human(List<int[]> coordinates) : base(coordinates)
    {
    }

    public override void ReportActualCoordinate()
    {
        int[] currentCoordinate = coordinates[coordinates.Count - 1];
        Console.WriteLine("Report Actual coordinate:");
        Console.WriteLine($"[{currentCoordinate[0]},{currentCoordinate[1]}]");
    }
}

class Alien : LifeForm
{
    public Alien(List<int[]> coordinates) : base(coordinates)
    {
    }

    public override void ReportActualCoordinate()
    {
        int[] currentCoordinate = coordinates[coordinates.Count - 1];
        Console.WriteLine("Report Actual coordinate:");
        Console.WriteLine($"[{currentCoordinate[1]},{currentCoordinate[0]}]");
    }
}
