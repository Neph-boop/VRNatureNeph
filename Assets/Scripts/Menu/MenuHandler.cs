using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public int GameSceneIndex = 0;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        GameData.Is_Tutorial = false;
    }
    private void OnApplicationPause(bool pause)
    {
        
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(GameSceneIndex);
    }

    public void LoadTutorialScene()
    {
        GameData.Is_Tutorial = true;
        SceneManager.LoadScene(GameSceneIndex);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
