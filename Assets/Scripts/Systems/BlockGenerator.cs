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

    SpriteRenderer BlockOverlay;
    private readonly List<Sprite> blockOverlay1 = new List<Sprite>(); //squares
    public Sprite overlay1;
    public Sprite overlay2;

    private readonly List<Sprite> blockOverlay2 = new List<Sprite>(); //rectangles
    public Sprite overlay3;
    public Sprite overlay4;

    //private readonly List<Sprite> blockOverlay3 = new List<Sprite>();
    //public Sprite overlay5;
    //public Sprite overlay6;


    //[SerializeField] public bool BlockGeneratorReady = false;

    // Use this for initialization
    protected override void Awake () {
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

        blockOverlay1.Add(overlay1);
        blockOverlay1.Add(overlay2);
        blockOverlay2.Add(overlay3);
        blockOverlay2.Add(overlay4);

        //BlockGeneratorReady = true;

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

        int blockColorIndex = Random.Range(0, blockColors.Count);
        BlockSprite.color = blockColors[blockColorIndex];

        //BlockOverlay = newGameObject.GetComponentInChildren<SpriteRenderer>();
        BlockOverlay = newGameObject.transform.Find("Overlay2D").GetComponent<SpriteRenderer>();
        newGameObject.transform.position = initialPosition;

        if (blockTypeIndex == 0)
        {
            int blockOverlayIndex = Random.Range(0, blockOverlay1.Count);
            BlockOverlay.sprite = blockOverlay1[blockOverlayIndex];
            //print("block type " +blockTypeIndex);
        } else if (blockTypeIndex == 1 || blockTypeIndex == 2)
        {
            int blockOverlayIndex = Random.Range(0, blockOverlay2.Count);
            BlockOverlay.sprite = blockOverlay2[blockOverlayIndex];
            //print("block type " + blockTypeIndex);
        }
        //else if (blockTypeIndex == 2)
        //{
        //    int blockOverlayIndex = Random.Range(0, blockOverlay3.Count);
        //    BlockOverlay.sprite = blockOverlay3[blockOverlayIndex];
        //    //print("block type " + blockTypeIndex);
        //}

        //Assign Block to Players
        //if (!isPlayerOneBlock)
        //{
        //    //newGameObject.
        //    //isPlayerOneBlock = false;
        //    print("Player 2");
        //}

    } //end ReplaceBlock

} //end BlockGenerator class
