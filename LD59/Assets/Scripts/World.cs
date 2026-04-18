using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using TreeEditor;

public static class World 
{
    public static List<SignalTower> towers = new List<SignalTower>();
    public static List<Tree> trees = new List<Tree>();

    public static void RemoveTower(SignalTower tower)
    {
        towers.Remove(tower);
    }

    public static void AddTower(SignalTower tower)
    {
        towers.Add(tower);
    }

    public static void RemoveTree(Tree tree)
    {
        trees.Remove(tree);
    }

    public static void AddTree(Tree tree)
    {
        trees.Add(tree);
    }
}
