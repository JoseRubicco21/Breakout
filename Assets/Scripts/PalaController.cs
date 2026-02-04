using UnityEngine;

public class PalaController : MonoBehaviour
{
    private const float GAMEZONEWIDTH = 2.5f;
    const float MAX_X  = GAMEZONEWIDTH;
    const float MIN_X = -GAMEZONEWIDTH;
    [SerializeField] float speed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            float x = transform.position.x; // Obtener la posición actual de x de la pala
    if (x > MIN_X && Input.GetKey("left")) {
        // Desplazamiento hacia la izquierda con un valor negativo
        // Utilizamos deltaTime para obtener una referencia de la velocidad independiente del hardware
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    } else if (x < MAX_X && Input.GetKey("right")) {
        transform.Translate(speed * Time.deltaTime, 0, 0); // Desplazamiento hacia la derecha
    }
    }
}
