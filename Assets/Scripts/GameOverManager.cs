using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject GameOverUI;
    public Text GameOverText;

    static public GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is already a GameOverManager instance.");
            return;
        }
        instance = this;
    }

    public void OnPlayerDeath()
    {
        GameOverUI.SetActive(true);
        StartCoroutine(TypeText("Votre mental n'a pas pu supporter vos pertes.\nRetour au village.", 20f));
    }

    public void RetryButton()
    {
        GameOverUI.SetActive(false);
        PlayerMentalHealth.instance.Respawn();
    }

    IEnumerator TypeText(string type, float textSpeed)
    {
        string TextBuffer = "";
        foreach (char c in type)
        {
            if (c == '\n')
            {
                yield return new WaitForSeconds(.5f);
            }
            float sumWait = 1 / textSpeed;
            TextBuffer += c;
            GameOverText.text = TextBuffer;
            yield return new WaitForSeconds(sumWait);
        }
    }
}
