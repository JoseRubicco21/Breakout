using UnityEngine;
using BrickSystem;

[CreateAssetMenu(fileName = "Circle", menuName = "Brick Spawner/Strategies/Circle")]
public class Circle : BrickSpawnerStrategy
{
    public override void SpawnStrategy(BrickSpawnerSettings settings, Transform parent)
    {
        // Calculate center of the grid
        float centerX = (settings.getCols() - 1) / 2f;
        float centerY = (settings.getRows() - 1) / 2f;
        
        // Calculate radius (use the smaller dimension to fit the circle in the grid)
        float radius = Mathf.Min(settings.getCols(), settings.getRows()) / 2f;
        
        for(int i = 0; i < settings.getCols(); i++)
        {
            for(int j = 0; j < settings.getRows(); j++)
            {
                // Calculate distance from center
                float distanceX = i - centerX;
                float distanceY = j - centerY;
                float distance = Mathf.Sqrt(distanceX * distanceX + distanceY * distanceY);
                
                // Only spawn if within the circle radius
                if (distance <= radius)
                {
                    Instantiate(
                        settings.getPrefabs()[0],
                        new Vector2(
                        i * (settings.getPrefabs()[0].transform.localScale.x + settings.getXGap()) +  settings.getXOffset(),
                        j * (settings.getPrefabs()[0].transform.localScale.y + settings.getYGap()) + settings.getYOffset() + parent.position.y
                        ),
                        Quaternion.identity
                    );
                    
                }
            }
        }
    }    
}