using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class MapVisualizer
{
    private readonly Map _map;

    public MapVisualizer(Map map)
    {
        _map = map ?? throw new ArgumentNullException(nameof(map));
    }

    public void Draw()
    {
        int sizeX = _map.SizeX;
        int sizeY = _map.SizeY;

        // górna krawędź
        Console.Write(Box.TopLeft);
        for (int x = 0; x < sizeX - 1; x++)
        {
            Console.Write($"{Box.Horizontal}{Box.TopMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.TopRight}");

        // środkowe wiersze
        for (int y = sizeY - 1; y >= 0; y--)
        {
            for (int x = 0; x < sizeX; x++)
            {
                // lewa krawędź
                if (x == 0) Console.Write(Box.Vertical);

                // zawartość pola
                Console.Write(GetCellContent(new Point(x, y)));

                // prawa krawędź lub pion
                Console.Write(x == sizeX - 1 ? Box.Vertical : Box.Vertical);
            }
            Console.WriteLine();

            // dolna krawędź lub ostatnia linia
            if (y > 0)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < sizeX - 1; x++)
                {
                    Console.Write($"{Box.Horizontal}{Box.Cross}");
                }
                Console.WriteLine($"{Box.Horizontal}{Box.MidRight}");
            }
        }

        // dolna krawędź
        Console.Write(Box.BottomLeft);
        for (int x = 0; x < sizeX - 1; x++)
        {
            Console.Write($"{Box.Horizontal}{Box.BottomMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.BottomRight}");

        foreach (var y in Enumerable.Range(0, _map.SizeY))
        {
            foreach (var x in Enumerable.Range(0, _map.SizeX))
            {
                var creatures = _map.At(x, y);
                /*Console.WriteLine($"Pole ({x},{y}): {creatures?.Count ?? 0} stworów");*/
            }
        }
    }

    private char GetCellContent(Point point)
    {
        var creatures = _map.At(point);

        if (creatures == null || creatures.Count == 0) return ' ';

        if (creatures.Count == 1)
        {
            return creatures[0] switch
            {
                Orc => 'O',
                Elf => 'E',
                _ => '?',
            };
        }

        return 'X';
    }
}
