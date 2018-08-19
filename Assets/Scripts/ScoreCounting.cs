using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounting : MonoBehaviour {

    public TextMesh scoreTextMesh;
    private string scoreText;
    private int Score = 0;
    // Use this for initialization
    void Start()
    {
        scoreText = scoreTextMesh.text;
        updateScore(0);

    }

    // Update is called once per frame
    void Update()
    {

    }
    /*
    public void ModScore(int _value)
    {
        Score += _value;
        playerScore.updateScore(Score);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Brick")
        {
            ModScore(100);
        }
    }*/

    public void updateScore(int value)
    {
        scoreTextMesh.text = scoreText;
        scoreTextMesh.text += value;
    }
}
