using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoSingleton<BlockGenerator> {

    private readonly List<GameObject> blockTypes = new List<GameObject>();
    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    //public GameObject block4;

    SpriteRenderer BlockSprite;
    private readonly List<Color> blockColors = new List<Color>();
    public Color color1 = new Color(0, 0, 1, 1);
    public Color color2 = new Color(0, 1, 0, 1);
    public Color color3 = new Color(1, 0, 0, 1);
    //public Color color4 = new Color(0, 0, 0, 1);
    //public Color color5 = new Color(0, 0, 0, 1);
    //public Color color6 = new Color(0, 0, 0, 1);

    // Use this for initialization
    void Start () {
        //Load Generator
        blockTypes.Add(block1);
        blockTypes.Add(block2);
        blockTypes.Add(block3);
        //blockTypes.Add(block4);

        blockColors.Add(color1);
        blockColors.Add(color2);
        blockColors.Add(color3);
        //blockColors.Add(color4);
        //blockColors.Add(color5);
        //blockColors.Add(color6);

        //Setting up probability: 
        ////Use a public or random set int to change the number of times a block type or color is added to their lists.
    } //end Start
	
	// Update is called once per frame
	void Update () {
	} //end Update

    public void ReplaceBlock(Vector3 initialPosition, bool isPlayerOneBlock) {
        //GameObject newGameObject = Instantiate(block1);
        int blockTypeIndex = Random.Range(0, blockTypes.Count);
        GameObject newGameObject = Instantiate(blockTypes[blockTypeIndex]);

        BlockSprite = newGameObject.GetComponent<SpriteRenderer>();

        //BlockSprite.color = Color.blue;

        int blockColorIndex = Random.Range(0, blockColors.Count);
        BlockSprite.color = blockColors[blockColorIndex];

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
