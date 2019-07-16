using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] float levelLoadDelay;
    // Start is called before the first frame update
    void Start()
    {
        PlayNextLevel();
    }

    void PlayNextLevel() {
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void LoadNextLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;  // tells you what index level you are on
        int nextSceneIndex = currentSceneIndex + 1;
        int lastLevelIndex = SceneManager.sceneCountInBuildSettings;
        print(currentSceneIndex);
        if (nextSceneIndex == lastLevelIndex) {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

}
