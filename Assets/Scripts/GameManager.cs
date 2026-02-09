using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject prefab;
    public GameObject prefab2;
    private float offset = -2.7f;
    [SerializeField] int ROWS = 5;
    [SerializeField] int COLS = 8;
    [SerializeField] float X_SEPARATION = 0.1f;
    [SerializeField] float Y_SEPARATION = 0.1f;
    [SerializeField] BrickSpawnerStrategy strategy;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
