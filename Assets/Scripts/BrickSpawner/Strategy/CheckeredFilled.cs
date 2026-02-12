using UnityEngine;
using BrickSystem;

[CreateAssetMenu(fileName = "CheckeredFilled", menuName = "Brick Spawner/Strategies/CheckeredFilled")]
public class CheckeredFilled : BrickSpawnerStrategy
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
                                                 i * (settings.getPrefabs()[0].transform.localScale.x + settings.getXGap() ) +settings.getXOffset(),
                        j * (settings.getPrefabs()[0].transform.localScale.y + settings.getYGap()) + settings.getYOffset()),
                        Quaternion.identity
                    );
                } else
                {
                           Instantiate(
                        settings.getPrefabs()[1],
                        new Vector2(
                                                 i * (settings.getPrefabs()[1].transform.localScale.x + settings.getXGap() ) +settings.getXOffset(),
                        j * (settings.getPrefabs()[1].transform.localScale.y + settings.getYGap()) + settings.getYOffset()),
                        Quaternion.identity
                    );
                }
            }
        }
    }    
}