using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounting : MonoBehaviour {
    public Text scoreTextMesh;
    private int score;

    //public GameObject checkblock = GameObject.Find("Game Manager");
    //GameManager currentblocks = checkblock.GetComponent<GameManager>();

    // Use this for initialization
    void Start()
    {
        score = 0;
        CheckBlocksInPlay();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        scoreTextMesh.text = "Blocks: " + score;
        CheckBlocksInPlay();
    }
    public void CheckBlocksInPlay() {
        score = GameManager.Instance.BlocksInPlay;
        //score = currentblocks.BlocksInPlay;
    } //end CheckBlocksInPlay
} //end ScoreCounting
