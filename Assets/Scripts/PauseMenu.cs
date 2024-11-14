using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    static public bool isPaused = false;

    public GameObject pauseMenu;
    public GameObject SettingsWindow;
    public Animator menuAnimator;
    public Animator SettingsAnimator;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        isPaused = false;
        PlayerMovement.instance.enabled = true;
        SettingsWindow.SetActive(false);
        menuAnimator.SetTrigger("Hide");
    }

    void Pause()
    {
        isPaused = true;
        PlayerMovement.instance.MovePlayer(0, 0);
        PlayerMovement.instance.enabled = false;
        menuAnimator.SetTrigger("Show");
    }

    public void QuitButton()
    {
        Resume();
        PlayerMovement.instance.enabled = true;
    }

    public void MainMenuButton()
    {
        Resume();
        SceneManager.LoadScene(0);
    }

    public void SettingsButton()
    {
        SettingsWindow.SetActive(true);
        SettingsAnimator.SetTrigger("Show");
    }

    public void CloseSettingsWindow()
    {
        StartCoroutine(CloseSettingsAnimation());
    }

    IEnumerator CloseSettingsAnimation()
    {
        SettingsAnimator.SetTrigger("Hide");
        yield return new WaitForSeconds(1f / 6);
        SettingsWindow.SetActive(false);
    }
}
