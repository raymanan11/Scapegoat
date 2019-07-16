using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    
    // Start is called before the first frame update
    
    private void Awake() {
        int numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
        if (numMusicPlayer > 1) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject); //don't destroy the thing attached to (in this case MusicPlayer script) so when it goes to next level MusicPlayer is still there
        }
        
    }

    
}
