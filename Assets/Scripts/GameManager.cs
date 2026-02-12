using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static int Score { get; private set; } = 0; 
    public static int Lives { get; private set; } = 3;

    public static void UpdateScore(int points) { Score += points; }

    public static void UpdateLives() { Lives--; } 

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
