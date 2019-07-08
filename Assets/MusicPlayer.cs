using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    [SerializeField] float levelLoadDelay;
    // Start is called before the first frame update
    void Start() {
        PlayNextLevel();
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void Awake() {
        DontDestroyOnLoad(gameObject); //don't destroy the thing attached to (in this case MusicPlayer script) so when it goes to next level MusicPlayer is still there
    }

    void PlayNextLevel () {
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
