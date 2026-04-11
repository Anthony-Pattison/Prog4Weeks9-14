using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
   public void quitGame()
    {
        Application.Quit();
    }
}
