using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounting : MonoBehaviour {
    public Text scoreTextMesh;
    private int Score;

    // Use this for initialization
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject checkblock = GameObject.Find("Game Manager");
        GameManager currentblocks = checkblock.GetComponent<GameManager>();
        updateScore(currentblocks.BlocksInPlay);
    }

    public void updateScore(int value)
    {
        
    }
}
