using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    [SerializeField] private AudioSource _bgmSource;
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioClip _levelBGM;

    public AudioClip menuBGM;

    public AudioClip _starSFX;
    public AudioClip _coinSFX;
    public AudioClip _heartSFX;
    public AudioClip jumpSFX;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        // Reproducir automáticamente la música del nivel al iniciar
        if (_levelBGM != null)
        {
            _bgmSource.clip = _levelBGM;
            _bgmSource.loop = true;  // Asegura que se repita
            _bgmSource.Play();
        }
    }

    public void ReproduceSound(AudioClip clip)
    {
        if (clip != null)
            _sfxSource.PlayOneShot(clip);
    }

    public void ChangeBGM(AudioClip bgmclip)
    {
        if (bgmclip == null) return;

        _bgmSource.clip = bgmclip;
        _bgmSource.loop = true;
        _bgmSource.Play();
    }
}
