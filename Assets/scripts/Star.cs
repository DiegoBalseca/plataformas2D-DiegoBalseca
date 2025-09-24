using UnityEngine;

public class Star : MonoBehaviour
{
    //GameManager _gameManager;

    [SerializeField] private AudioClip _starSFX;

 
    void Awake()
    {
       // _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Interaction()
    {
       // _gameManager.AddStar();

       GameManager.instance.AddStar();
       AudioManager.instance.ReproduceSound(AudioManager.instance._starSFX);
        Destroy(gameObject);
    }
}
