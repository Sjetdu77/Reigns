using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public GameObject SettingsWindow;
    public Animator SettingsAnimation;

    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsButton()
    {
        SettingsWindow.SetActive(true);
        SettingsAnimation.SetTrigger("Show");
    }

    public void CloseSettingsWindow()
    {
        StartCoroutine(CloseSettingsAnimation());
    }

    IEnumerator CloseSettingsAnimation()
    {
        SettingsAnimation.SetTrigger("Hide");
        yield return new WaitForSeconds(1f / 6);
        SettingsWindow.SetActive(false);
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
