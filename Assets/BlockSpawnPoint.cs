using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnPoint : MonoBehaviour {

    Vector3 initial;
    //private readonly List<GameObject> SpawnPoints = new List<GameObject>();

    [SerializeField] bool isPlayerOneBlock = true; //set and pass to Block.cs

    // Use this for initialization
    void Start () {
        //SpawnPoints.Add(this.gameObject);

        //if (BlockGenerator.Instance.BlockGeneratorReady == true)
        //{
        //    SpawnFirstBlock();
        //    //print(BlockGenerator.Instance.BlockGeneratorReady);
        //}
        //BlockGenerator.Instance.ReplaceBlock(initial, isPlayerOneBlock);
    } //end OnEnable
	
	// Update is called once per frame
	void Update () {
	} //end Update

    public void SpawnFirstBlock() {
        initial = this.transform.position;
        BlockGenerator.Instance.ReplaceBlock(initial, isPlayerOneBlock);
    } //end SpawnFirstBlock

} //end BlockSpawnPoint class
