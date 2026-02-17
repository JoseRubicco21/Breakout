
using UnityEngine;

public class PelotaController : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource sfx;
    private bool hasPlayed = false;
    [SerializeField] AudioClip sfxPaddel;  // Sonido al chocar con la pala
    [SerializeField] AudioClip sfxBrick;   // Sonido al chocar con un ladrillo
    [SerializeField] AudioClip sfxWall;    // Sonido al chocar con una pared
    [SerializeField] AudioClip sfxFail;    // Sonido al salir por la pared inferior
    [SerializeField] float force = 1.0f;
    [SerializeField] float maxSpeed = 10.0f;
    [SerializeField] float acceleration = 0.25f;
    [SerializeField] float delay = 2.0f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sfx = GetComponent<AudioSource>();
        if (GameManager.IsRunning)
        {
            Invoke("LanzarPelota", 0);
        }
    }

    void Update()
    {

    }

    private void LanzarPelota()
    {
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

        if (!hasPlayed)
        {
            hasPlayed = true;
            sfx.PlayOneShot(sfxFail);
        }
        if (other.tag == "Wall")
        {
            GameManager.ResetCombo();
            GameManager.UpdateLives();
            GameManager.checkGameOver();
            Invoke("LanzarPelota", delay);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Brick")
        {
            if (rb.linearVelocity.magnitude < maxSpeed)
            {
                rb?.AddForce(rb.linearVelocity.normalized * acceleration, ForceMode2D.Impulse); // Aplica un impulso adicional para aumentar la velocidad                

            }
            sfx.clip = sfxBrick;
            sfx.Play();
            GameManager.UpdateCombo();
            GameManager.UpdateComboMultiplier();
            GameManager.UpdateDrestoyedBricks();
            GameManager.UpdateScore((int)(other.gameObject.GetComponent<Brick>().getPuntuacion() * GameManager.ComboMultiplier));
            Destroy(other.gameObject);
            GameManager.checkWin();
            GameManager.showPoints();
        }
        else if (other.gameObject.tag == "Paddle")
        {
            sfx.clip = sfxPaddel;
            sfx.Play();
        }
        else
        {
            sfx.clip = sfxWall;
            sfx.Play();
        }
    }

}