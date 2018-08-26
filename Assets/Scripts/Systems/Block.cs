//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Block : DraggableObject {

    Ray ray;
    RaycastHit hit;
    Vector3 initial;

    //private int AssignedBlockIndexPos;

    //NOTE: 2 Player currently disabled! BlockGenerator needs to be able to set IsPlayerOneBlock of newBlock

    //AudioSource audioSource;
    public bool assignPlayerOne;  //passed from spawn point
    private bool isPlayerOneBlock;

    private void Start() {
        IsPlaced = false;
        isPlayerOneBlock = assignPlayerOne;

        //print("Block- Player 1 " + isPlayerOneBlock);
        //audioSource = this.GetComponent<AudioSource>();
    } //end Awake
    //private void Start(){}

    private void Update() {
        //casts a ray from the center of the object
        ray = new Ray(transform.GetComponent<Collider>().bounds.center, Vector3.forward);
        Debug.DrawRay(ray.origin, ray.direction * 1, Color.blue);
    } //end Update

    public override void BeginDrag(Vector3 pointerPosition) {
        if (!IsPlaced) {

            //for 2 player
            if ((isPlayerOneBlock && GameManager.Instance.IsPlayerOne) || (!isPlayerOneBlock && !GameManager.Instance.IsPlayerOne))
            {
                this.gameObject.layer = 8; //DraggedBlock Layer
                base.BeginDrag(pointerPosition);
                initial = this.transform.position;
            }

            //for 1 player
            //this.gameObject.layer = 8; //DraggedBlock Layer
            //base.BeginDrag(pointerPosition);
            //initial = this.transform.position;
            
        } 
    } //end BeginDrag

    public override void OnDrag(Vector3 pointerPosition) {
        if (!IsPlaced) {
            //for 2 player
            if ((isPlayerOneBlock && GameManager.Instance.IsPlayerOne) || (!isPlayerOneBlock && !GameManager.Instance.IsPlayerOne))
            {
                if (this.gameObject.layer == 0)
                {
                    this.gameObject.layer = 8;
                }
                base.OnDrag(pointerPosition);
            }

            //for 1 player
            //if (this.gameObject.layer == 0)
            //{
            //    this.gameObject.layer = 8;
            //}
            //    base.OnDrag(pointerPosition);
            
        }    
    } //end OnDrag

    public override void EndDrag()
    {
        //checks if the ray hits something at 1 distance. Used to define context of space behind dragged block
        if ((isPlayerOneBlock && GameManager.Instance.IsPlayerOne) || (!isPlayerOneBlock && !GameManager.Instance.IsPlayerOne)) {

        this.gameObject.layer = 0;
        base.EndDrag();

        if (!IsPlaced)
            {
            if (Physics.Raycast(ray, out hit, 1))
                {
                //checks hit object's tag
                if (hit.transform.tag == "PlayArea")
                    {
                    this.gameObject.layer = 9;  //PlacedBlocks Layer
                    this.transform.position = new Vector3(hit.point.x, hit.point.y, this.transform.position.z);

                    this.GetComponent<Rigidbody>().isKinematic = false;
                    this.GetComponent<Rigidbody>().useGravity = true;

                    //Makes Blocks placed in the PlayArea non-draggable
                    IsPlaced = true;

                    //Collect Block GameObject to list BlocksInPlayIndex.
                    GameManager.Instance.SetBlockIntoPlay(this.gameObject);

                    //Store the index for the block within itself for reference
                    //AssignedBlockIndexPos = GameManager.Instance.CurrentBlockIndexPos;

                    //Changes to the next Players turn after Block is placed.
                    GameManager.Instance.NextTurn();

                    BlockGenerator.Instance.ReplaceBlock(initial, isPlayerOneBlock);
                    }
                else
                    this.transform.position = initial;
                }
            else
                this.transform.position = initial;
            } //end if (!IsPlaced)
        }
    } //end EndDrag

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name =="Pit")
        {
            GameManager.Instance.RemoveBlockFromPlay(this.gameObject);
            Destroy(this.gameObject);
            //print("pit");
        }
    } //end OnCollisionEnter

    //public override void TapObject()
    //{
    //    //if the object is placed play a note
    //     if(isPlaced)
    //        audioSource.Play();
    //} //end TapObject
} //end Block class
