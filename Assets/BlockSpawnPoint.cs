//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnPoint : MonoBehaviour {

    Vector3 initial;
    //private readonly List<GameObject> SpawnPoints = new List<GameObject>();

    public bool assignPlayerOne;
    //public bool isPlayerOneBlock; //set and pass to Block.cs

    // Use this for initialization
    void Start () {
        SpawnFirstBlock();
    } //end OnEnable
	
	// Update is called once per frame
	void Update () {
	} //end Update

    public void SpawnFirstBlock() {
        initial = this.transform.position;
        BlockGenerator.Instance.ReplaceBlock(initial, assignPlayerOne);
    } //end SpawnFirstBlock

} //end BlockSpawnPoint class
