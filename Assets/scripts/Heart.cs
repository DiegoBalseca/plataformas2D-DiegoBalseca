using UnityEngine;

public class Heart : MonoBehaviour
{
    [Header("Configuración del sonido")]
    [SerializeField] private AudioClip _heartSFX;   // Sonido que se reproducirá al recoger el corazón

    private bool _collected = false; // Evita que se recoja varias veces

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Solo reacciona si el objeto que toca es el jugador
        if (_collected) return; // protección doble
        if (collision.CompareTag("Player"))
        {
            _collected = true;
            Interaction();
        }
    }

    public void Interaction()
    {
        // Suma vida al GameManager
        GameManager.instance.AddHeart();  // Necesitas crear este método en tu GameManager

        // Reproduce el sonido del corazón
        if (_heartSFX != null)
            AudioManager.instance.ReproduceSound(_heartSFX);

        // Destruye el corazón de la escena
        Destroy(gameObject);
    }
}
