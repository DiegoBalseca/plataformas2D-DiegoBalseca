using UnityEngine;

public class MenuManager : MonoBehaviour
{
    
     public void ChangeScene(string sceneName)
    {
        SceneLoad.Instance.ChangeScene(sceneName);
    }
}
