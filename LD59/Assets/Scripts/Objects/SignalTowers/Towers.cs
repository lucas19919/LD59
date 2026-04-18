using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public static class World 
{
    public static List<SignalTower> towers = new List<SignalTower>();

    public static void RemoveTower(SignalTower tower)
    {
        towers.Remove(tower);
    }

    public static void AddTower(SignalTower tower)
    {
        towers.Add(tower);
    }
}
