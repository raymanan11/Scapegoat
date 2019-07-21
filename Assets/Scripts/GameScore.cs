using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{

    int score = 0;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>(); // gets the text component 
        scoreText.text = score.ToString(); // the .text gets the actual string in the text box and makes it equal to our score variable
    }

    public void Score(int scorePerShot) { // allows other classes to call this function in order to update the score
        score = score + scorePerShot;
        scoreText.text = score.ToString();
    }
}
