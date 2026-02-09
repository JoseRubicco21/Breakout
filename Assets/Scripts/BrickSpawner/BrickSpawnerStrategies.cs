using UnityEngine;
using BrickSystem;
using UnityEditor;
public abstract class BrickSpawnerStrategy  : ScriptableObject
{
    public abstract void SpawnStrategy(BrickSpawnerSettings settings);
}


