using UnityEngine;
using UnityEngine.UI;

public class GUIGame : MonoBehaviour
{
  public static GUIGame Instance;  
   public GameObject _pauseCanvas; 

   private Image _healthBar;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
        Instance = this;
        }
    }


    public void ChangeCanvasStatus(GameObject canvas, bool status)
    {
        canvas.SetActive(status);
    }


    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        _healthBar.fillAmount =  currentHealth / maxHealth;
    }


    public void Resumen()
    {
        GameManager.instance.Pause();
    }

    public void ChangeScene(string sceneName)
    {
        SceneLoad.Instance.ChangeScene(sceneName);
    }

}
