using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] private BrickSpawnerSettings brickSpawner;
    public static int Score { get; private set; } = 0; 
    public static int Lives { get; private set; } = 3;
    public static bool IsRunning { get; private set; } = false;

    public static int LifeTreshold { get; private set; } = 500;
    public static int DestroyedBricks { get; private set; } = 0;
    public static int ComboCounter { get; private set; } = 0;
    
    public static float ComboMultiplier { get; private set; } = 1f;
    public static void UpdateScore(int points) { Score += points;
        if (Score >= LifeTreshold)
        {
            Lives++;
            LifeTreshold += 500;
        }
     }
    
    public static void UpdateDrestoyedBricks() { DestroyedBricks++; }
    public static void UpdateLives() { Lives--; } 
    public static void UpdateCombo() { ComboCounter++; UpdateComboMultiplier(); } 
    public static void ResetCombo() { ComboCounter = 0; ComboMultiplier = 1f; } 

    public static void checkGameOver()
    {
        if (Lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public static void nextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene("Win");

        }
        else
        {
        ResetCombo();
        DestroyedBricks = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);            
        }
    }

    public static void checkWin()
    {
        if (DestroyedBricks >= GameObject.FindAnyObjectByType<BrickSpawnerSettings>().getTotalBricks())
        {
            nextLevel();
        }
    }

    public static void UpdateComboMultiplier()
    {
        if (ComboCounter % 5 == 0 && ComboCounter > 0)
        {
            ComboMultiplier += 0.25f;
        }
    }
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !IsRunning)
        {
            IsRunning = !IsRunning;
            SceneManager.LoadScene("Scene-00");
            
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

        public static void showPoints()
    {
        Debug.Log("Puntuacion: " + Score);
        Debug.Log("Combo: " + ComboCounter + " (x" + ComboMultiplier + ")");
    }
}
