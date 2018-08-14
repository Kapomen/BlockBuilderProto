using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator3 : MonoSingleton<BlockGenerator3> {

    public GameObject newBlock;

	// Use this for initialization
	void Start () {	
	} //end Start
	
	// Update is called once per frame
	void Update () {
	} //end Update

    public void ReplaceBlock(Vector3 initialPosition, bool isPlayerOneBlock) {
        GameObject newGameObject = Instantiate(newBlock);
        newGameObject.transform.position = initialPosition;

        //Assign Block to Players
        if (!isPlayerOneBlock)
        {
            //newGameObject.
            //isPlayerOneBlock = false;
            print("Player 2");
        }

    } //end ReplaceBlock

} //end BlockGenerator class
