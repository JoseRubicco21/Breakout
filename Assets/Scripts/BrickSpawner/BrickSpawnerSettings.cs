using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class BrickSpawnerSettings : MonoBehaviour
{
    [SerializeField] private int ROWS = 5;    
    [SerializeField] private int COLS = 8;
    [SerializeField] private float X_GAP = 0.1f;
    [SerializeField] private float Y_GAP = 0.1f;
    [SerializeField] private float offset = 2.7f;
    [SerializeField] private GameObject[] prefabs;

    public int getRows()
    {
        return ROWS;
    }

    public int getCols()
    {
        return COLS;
    }

    public float getXGap()
    {
        return X_GAP;
    }

    public float getYGap()
    {
        return Y_GAP;
    }

    public GameObject[] getPrefabs()
    {
        return prefabs;
    }

    public float getOffset()
    {
        return offset;
    }
}
