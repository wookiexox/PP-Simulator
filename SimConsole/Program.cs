using System.Text;
using SimConsole;
using Simulator.Maps;
using Simulator;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallTorusMap map = new(8, 6);
        List<IMappable> creatures = [
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals() {Description = "Rabbits", Size = 5},
            new Birds() {Description = "Eagles", Size = 15, CanFly = true},
            new Birds() {Description = "Ostriches", Size = 75, CanFly = false}
        ];
        List<Point> points = [new(2, 2), new(3, 1), new(4, 2), new(5, 0), new(7, 3)];
        string moves = "dlllll";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        mapVisualizer.Draw();

        while (!simulation.Finished)
        {
            Console.ReadKey();

            Console.WriteLine(new string('=', 20));

            Console.WriteLine($"{simulation.CurrentCreature} - {simulation.CurrentMoveName}:");
            simulation.Turn();
            mapVisualizer.Draw();

        }
    }
}