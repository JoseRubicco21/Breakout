
using UnityEngine;

public class PelotaController : MonoBehaviour
{
    Rigidbody2D rb; 
    [SerializeField] int force = 1;
    [SerializeField] float delay = 2.0f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("LanzarPelota", 0);
    }

    void Update()
    {
        
    }

    private void LanzarPelota(){
        transform.position = Vector3.zero;
        rb.linearVelocity = Vector2.zero;
        float dirX, dirY = -1;
        dirX = Random.Range(0, 2) == 0 ? -1 : 1;
        Vector2 dir = new Vector2(dirX, dirY);
        dir.Normalize();

        rb.AddForce(dir * force, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Wall")
        {
            Invoke("LanzarPelota", delay);
        } 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag =="Brick")
        {
           GameManager.UpdateScore(other.gameObject.GetComponent<Brick>().getPuntuacion());
           Destroy(other.gameObject);
           GameManager.showPoints();
        }
    }

}