using UnityEngine;
using BrickSystem;

[CreateAssetMenu(fileName = "Skull", menuName = "Brick Spawner/Strategies/Skull")]
public class Skull : BrickSpawnerStrategy
{
    public override void SpawnStrategy(BrickSpawnerSettings settings)
    {
        // 5x5 Skull pattern (1 = brick, 0 = empty)
        // Reading from bottom to top (j=0 is bottom row)
        int[,] skullPattern = new int[5, 5]
        {
            { 0, 1, 1, 1, 0 }, // Bottom row (j=0) - jaw
            { 1, 0, 1, 0, 1 }, // j=1 - teeth
            { 1, 1, 1, 1, 1 }, // j=2 - lower skull
            { 1, 0, 1, 0, 1 }, // j=3 - eyes
            { 0, 1, 1, 1, 0 }  // Top row (j=4) - top of skull
        };
        
        for(int i = 0; i < settings.getCols() && i < 5; i++)
        {
            for(int j = 0; j < settings.getRows() && j < 5; j++)
            {
                if (skullPattern[i, j] == 1)
                {
                    Instantiate(
                        settings.getPrefabs()[0],
                        new Vector2(
                            i * (settings.getPrefabs()[0].transform.localScale.x + settings.getXGap()) + settings.getOffset(),
                            j * (settings.getPrefabs()[0].transform.localScale.y + settings.getYGap())),
                        Quaternion.identity
                    );
                }
            }
        }
    }    
}
