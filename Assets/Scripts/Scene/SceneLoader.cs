using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
