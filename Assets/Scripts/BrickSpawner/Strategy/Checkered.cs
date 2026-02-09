using UnityEngine;
using BrickSystem;

[CreateAssetMenu(fileName = "Checkered", menuName = "Brick Spawner/Strategies/Checkered")]
public class Checkered : BrickSpawnerStrategy
{
    public override void SpawnStrategy(BrickSpawnerSettings settings)
    {
        for(int i = 0; i < settings.getCols(); i++)
        {
            for(int j = 0; j < settings.getRows(); j++)
            {
                // Skip every other brick in a checkered pattern
                if ((i + j) % 2 == 0)
                {
                    Instantiate(
                        settings.getPrefabs()[0],
                        new Vector2(
                                                 i * (settings.getPrefabs()[0].transform.localScale.x + settings.getXGap() ) +settings.getOffset(),
                        j * (settings.getPrefabs()[0].transform.localScale.y + settings.getYGap())),
                        Quaternion.identity
                    );
                }
            }
        }
    }    
}