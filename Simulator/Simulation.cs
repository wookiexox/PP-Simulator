using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Index of the current turn in the move cycle.
    /// </summary>
    private int _currentTurnIndex = 0;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature => Creatures[_currentTurnIndex % Creatures.Count];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => Moves[_currentTurnIndex].ToString().ToLower();

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (creatures == null || creatures.Count == 0)
            throw new ArgumentException("Creatures list cannot be empty.");

        if (positions == null || positions.Count != creatures.Count)
            throw new ArgumentException("Number of creatures must match number of positions.");

        if (string.IsNullOrEmpty(moves))
            throw new ArgumentException("Moves cannot be empty.");

        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves.ToLower();

        for (int i = 0;  i < Creatures.Count; i++)
        {
            var creature = Creatures[i];
            var position = Positions[i];
            map.Add(creature, position);
            creature.AssignMap(map, position);
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() 
    {
        if (Finished)
            throw new InvalidOperationException("Simulation is already finished.");

        Direction[] directions = DirectionParser.Parse(CurrentMoveName).ToArray();
        if (directions.Length > 0)
        {
            var currentDirection = directions[0];
            CurrentCreature.Go(currentDirection);
        }

        _currentTurnIndex++;

        if (_currentTurnIndex >= Moves.Length)
            Finished = true;
    }
}
