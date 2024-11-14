using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(StartScene());
        }
    }

    IEnumerator StartScene()
    {
        PlayerMentalHealth.instance.fadeSystem.SetTrigger("FastFadeIn");
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(sceneName);
    }
}
