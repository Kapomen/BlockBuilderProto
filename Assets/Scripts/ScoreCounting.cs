using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounting : MonoBehaviour {
    public Text scoreTextMesh;
    private int score;

    // Use this for initialization
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject checkblock = GameObject.Find("Game Manager");
        GameManager currentblocks = checkblock.GetComponent<GameManager>();
        scoreTextMesh.text = "Blocks: " + score;
        score = currentblocks.BlocksInPlay;
    }

}
