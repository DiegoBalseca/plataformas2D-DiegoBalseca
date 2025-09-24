using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance{get; private set;}

    [SerializeField] private AudioSource _bgmSource;
    [SerializeField] private AudioSource _sfxSource;

    public AudioClip menuBGM;

    public AudioClip _starSFX;
    public AudioClip _coinSFX;

    void Awake()
    {
        if (instance != null & instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    
    

    public void ReproduceSound(AudioClip clip)
    {
        _sfxSource.PlayOneShot(clip);
    }


    public void ChangeBGM(AudioClip bgmclip)
    {
        _bgmSource.clip = bgmClip;
        _bgmSource.Play();
    }
  
}
