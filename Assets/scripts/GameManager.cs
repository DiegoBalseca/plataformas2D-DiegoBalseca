using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public bool _isPaused = false;

    [SerializeField] public InputActionAsset playerInputs;
    private InputAction _pauseInput; 

    int _stars = 0;
    int _coins = 0;
    int _hearts = 0;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

        _pauseInput = InputSystem.actions["Pause"];
    }

    // 🔸 Sumar estrella
    public void AddStar()
    {
        _stars++;
        Debug.Log("Estrellas recogidas: " + _stars);

        // Actualizar UI si tienes
        // GUIGame.Instance.UpdateStarUI(_stars);
    }

    // 🔸 Sumar moneda
    public void AddCoin()
    {
        _coins++;
        Debug.Log("Monedas recogidas: " + _coins);

        // Actualizar UI si tienes
        // GUIGame.Instance.UpdateCoinUI(_coins);
    }

    // 🔸 Sumar corazón
    public void AddHeart()
    {
        _hearts++;
        Debug.Log("Corazones recogidos: " + _hearts);

        // Actualizar UI si tienes
        // GUIGame.Instance.UpdateHeartUI(_hearts);
    }

    void Update()
    {
        if (_pauseInput.WasPerformedThisFrame())
        {
            Pause();
        }
    }

    // 🔸 Alternar pausa
    public void Pause()
    {
        if (_isPaused)
        {
            Time.timeScale = 1;
            GUIGame.Instance.ChangeCanvasStatus(GUIGame.Instance._pauseCanvas, false);
            playerInputs.FindActionMap("Player").Enable();
            _isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            GUIGame.Instance.ChangeCanvasStatus(GUIGame.Instance._pauseCanvas, true);
            playerInputs.FindActionMap("Player").Disable();
            _isPaused = true;
        }
    }
}

