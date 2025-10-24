using UnityEngine;

public class Coin : MonoBehaviour
{
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
        AudioManager.instance.ReproduceSound(AudioManager.instance._coinSFX);
        Destroy(gameObject);
    }
}
