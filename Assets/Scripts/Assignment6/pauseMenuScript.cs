using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenuScript : MonoBehaviour
{
    public KeyCode pauseKey;
    public GameObject pauseMenuObjects;
    bool pause = false;
    eventCore EventCore;
    private void Start()
    {
        EventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
    }
    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (!pause)
            {
                pauseGame();
                return;
            }
            if (pause)
            {
                unPauseGame();
                return;
            }
            print(pause);

        }
    }
    public void unPauseGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuObjects.SetActive(false);
        Time.timeScale = 1.0f;
        pause = false;
        EventCore.EV_unPauseGame.Invoke();
    }

    public void pauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenuObjects.SetActive(true);
        pause = true;
        Time.timeScale = 0.0f;
        EventCore.EV_pauseGame.Invoke();
    }

    public void loadMenuScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
