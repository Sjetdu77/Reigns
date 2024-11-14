using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentSceneManager : MonoBehaviour
{
    public string activeScene = "Amarania";
    public Vector3 respawnPoint;

    public static CurrentSceneManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is already a CurrentSceneManager instance.");
            return;
        }
        instance = this;

        respawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    void Start()
    {
        SceneManager.activeSceneChanged -= ChangedActiveScene;
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= ChangedActiveScene;
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        transform.position = GameObject.FindGameObjectWithTag(activeScene).transform.position;
        respawnPoint = GameObject.FindGameObjectWithTag(next.name).transform.position;
        activeScene = next.name;
    }
}
