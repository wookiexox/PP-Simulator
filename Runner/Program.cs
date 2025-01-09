using Simulator;
using Simulator.Maps;
using Point = Simulator.Point;
using Rectangle = Simulator.Rectangle;

namespace Runner;

internal class Program
{
    static void Main(string[] args)
    {
        static void Lab5a()
        {
            // test 1: poprawne tworzenie prostokątów z luźnych współrzędnych
            try
            {
                var rect1 = new Rectangle(2, 3, 5, 5);
                Console.WriteLine($"Prostokąt 1: {rect1}");
                var rect2 = new Rectangle(5, 5, 2, 3);
                Console.WriteLine($"Prostokąt 2: {rect2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }

            // test 2: tworzenie prostokąta z punktów
            try
            {
                var p1 = new Point(1, 1);
                var p2 = new Point(4, 3);
                var rect3 = new Rectangle(p1, p2);
                Console.WriteLine($"Prostokąt 3: {rect3}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }

            // test 3: próba utworzenia chudego prostokąta
            try
            {
                var rect4 = new Rectangle(2, 3, 2, 7);
                Console.WriteLine($"Prostokąt 4: {rect4}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // test 4: sprawdzanie czy zawiera punkty
            Console.WriteLine("=====================");
            var rect5 = new Rectangle(0, 0, 5, 5);
            var point0 = new Point(0, 0);
            var point1 = new Point(3, 4);
            var point3 = new Point(5, 5);
            var point2 = new Point(6, 6);
            Console.WriteLine($"Prostokąt 5: {rect5}");
            Console.WriteLine($"Punkt {point0}? {rect5.Contains(point0)}");
            Console.WriteLine($"Punkt {point1}? {rect5.Contains(point1)}");
            Console.WriteLine($"Punkt {point2}? {rect5.Contains(point2)}");
            Console.WriteLine($"Punkt {point3}? {rect5.Contains(point3)}");
        }

        Lab5a();

        static void Lab5b()
        {
            Console.WriteLine();
            Console.WriteLine("=====================");

            // mapa o rozmiarze 10
            try
            {
                var map = new SmallSquareMap(10);

                // sprawdzanie istnienia punktów
                var insidePoint = new Point(5, 5);
                var outsidePoint = new Point(15, 15);
                Console.WriteLine($"Punkt {insidePoint} istnieje? {map.Exist(insidePoint)}");
                Console.WriteLine($"Punkt {outsidePoint} istnieje? {map.Exist(outsidePoint)}");

                // ruch góra-dół
                var startPoint = new Point(7, 7);
                Console.WriteLine($"Start: {startPoint}");
                Console.WriteLine($"Ruch w dół: {map.Next(startPoint, Direction.Down)}");
                Console.WriteLine($"Ruch w lewo: {map.Next(startPoint, Direction.Left)}");

                // ruch na ukos
                Console.WriteLine($"Ruch prawy-górny: {map.NextDiagonal(startPoint, Direction.Up)}");
                var startPoint1 = new Point(9, 9);
                Console.WriteLine($"Start: {startPoint1}");
                Console.WriteLine($"Ruch prawy-górny: {map.NextDiagonal(startPoint1, Direction.Up)}");

                // tworzenie zbyt dużej mapy
                try
                {
                    var invalidMap = new SmallSquareMap(25);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Błąd: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }
        }

        Lab5b();
    }
}
