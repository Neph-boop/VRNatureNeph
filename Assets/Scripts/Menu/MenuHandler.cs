using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public int GameSceneIndex = 0;

    public void LoadGameScene()
    {
        SceneManager.LoadScene(GameSceneIndex);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
