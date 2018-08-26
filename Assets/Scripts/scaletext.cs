using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaletext : MonoBehaviour {
    public GameObject player1;

    public GameObject player2;

    // Use this for initialization
    void Start () {

        player1 = GameObject.Find("player1hud");
        player2 = GameObject.Find("player2hud");

    }
    void Update()
    {
        GameObject gamemanager = GameObject.Find("Game Manager");

        GameManager findplayer = gamemanager.GetComponent<GameManager>();
        if (findplayer.IsPlayerOne)
        {
            player1.gameObject.GetComponent<TextMesh>().color = Color.red;
            player2.gameObject.GetComponent<TextMesh>().color = Color.white;
            player1.gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 1f);
            player2.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
        else if(!findplayer.IsPlayerOne)
        {
            player1.gameObject.GetComponent<TextMesh>().color = Color.white;
            player2.gameObject.GetComponent<TextMesh>().color = Color.red;
            player1.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            player2.gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 1f);
        }
    }

   
}
