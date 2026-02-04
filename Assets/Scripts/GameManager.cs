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


    void Start()
    {
            for(var i = 0; i < COLS; i++)
        {
            for(var j = 0; j < ROWS; j++)
            {
                if(j % 2 == 0)
                {
                    
                Instantiate(prefab, new Vector2(
                    i*(prefab.transform.localScale.x+X_SEPARATION) + offset, 
                    j*(prefab.transform.localScale.y+Y_SEPARATION)), Quaternion.identity);
                }  else
                {
    
                
                Instantiate(prefab2, new Vector2(
                    i*(prefab.transform.localScale.x+X_SEPARATION) + offset, 
                    j*(prefab.transform.localScale.y+Y_SEPARATION)), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
