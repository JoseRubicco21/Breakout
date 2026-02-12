using UnityEngine;
using BrickSystem;

[CreateAssetMenu(fileName = "GradientCols", menuName = "Brick Spawner/Strategies/Gradient Cols")]
public class GradientCols : BrickSpawnerStrategy
{
    public override void SpawnStrategy(BrickSpawnerSettings settings)
    {
        // Gradient pattern: 0, 1, 2, 2, 1, 0, 0, 1, 2, 2, 1, 0...
        int[] gradientPattern = { 0, 1, 2, 3, 3, 2, 1,0   };
        int prefabCount = settings.getPrefabs().Length;
        
        for(int i = 0; i < settings.getCols(); i++)
        {
            for(int j = 0; j < settings.getRows(); j++)
            {
                // Get prefab index based on row and gradient pattern
                int patternIndex = i % gradientPattern.Length;
                int prefabIndex = gradientPattern[patternIndex] % prefabCount;
                
                Instantiate(
                    settings.getPrefabs()[prefabIndex],
                    new Vector2(
                        i * (settings.getPrefabs()[prefabIndex].transform.localScale.x + settings.getXGap()) + settings.getXOffset(),
                        j * (settings.getPrefabs()[prefabIndex].transform.localScale.y + settings.getYGap())+ settings.getYOffset()),
                    Quaternion.identity
                );
            }
        }
    }    
}