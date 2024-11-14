using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LevelLoad(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
