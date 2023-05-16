using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPause = false;
    public GameObject pauseMenuUi;
    public GameObject Player; 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPause = true; 

            if(gameIsPause)
            {
                Paused();
                Player.SetActive(false);
            }
            else
            {
                Resume();
            }
        }
    }

    public void Paused()
    {
        Debug.Log("fg");
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0;
        gameIsPause = true;
    }

    public void Resume()
    {
        Debug.Log("ffreejkgej");
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1;
        gameIsPause = false;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("main_menu");
    }
}
