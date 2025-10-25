using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Configuración del sonido")]
    [SerializeField] private AudioClip _coinSFX;
    private bool _collected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_collected) return; 
        if (collision.CompareTag("Player"))
        {
            _collected = true;
            Interaction();
        }
    }

    public void Interaction()
    {
        GameManager.instance.AddCoin();

        
        if (_coinSFX != null)
            AudioManager.instance.ReproduceSound(_coinSFX);

        Destroy(gameObject);
    }
}
