using UnityEngine;
using BrickSystem;

public class BrickSpawner : MonoBehaviour
{
    [SerializeField] BrickSpawnerSettings settings;
    [SerializeField] BrickSpawnerStrategy strategy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        strategy.SpawnStrategy(settings);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
