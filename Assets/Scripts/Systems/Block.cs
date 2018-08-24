//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Block : DraggableObject {

    Ray ray;
    RaycastHit hit;
    Vector3 initial;

    private int AssignedBlockIndexPos;

    //NOTE: 2 Player currently disabled! BlockGenerator needs to be able to set IsPlayerOneBlock of newBlock

    //AudioSource audioSource;
    [SerializeField] bool isPlayerOneBlock = true; //passed from spawn point

    private void Awake() {
        IsPlaced = false;
        IsDragging = false;
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
            //for single player remove this IF (not it's content)
            //if ((isPlayerOneBlock && GameManager.Instance.isPlayerOne)|| (!isPlayerOneBlock && !GameManager.Instance.isPlayerOne)) {
            //    base.BeginDrag(pointerPosition);
            //    initial = this.transform.position;
            //}

            IsDragging = true;
            base.BeginDrag(pointerPosition);
            initial = this.transform.position;
            
        } 
    } //end BeginDrag

    public override void OnDrag(Vector3 pointerPosition) {
        if (!IsPlaced) {
            //for a single player remove this if (not it's content though)
            //if ((isPlayerOneBlock && GameManager.Instance.isPlayerOne) || (!isPlayerOneBlock && !GameManager.Instance.isPlayerOne))
            //{
            //    base.OnDrag(pointerPosition);
            //}

                base.OnDrag(pointerPosition);
            
        }    
    } //end OnDrag

    public override void EndDrag()
    {
        //checks if the ray hits something at 1 distance. Used to define context of space behind dragged block.
        //if ((isPlayerOneBlock && GameManager.Instance.isPlayerOne) || (!isPlayerOneBlock && !GameManager.Instance.isPlayerOne)) {

        base.EndDrag();

        if (!IsPlaced)
        {
            IsDragging = false;
            if (Physics.Raycast(ray, out hit, 1))
            {
                //checks hit object's tag
                if (hit.transform.tag == "PlayArea")
                {
                    this.transform.position = new Vector3(hit.point.x, hit.point.y, this.transform.position.z);

                    this.GetComponent<Rigidbody>().isKinematic = false;
                    this.GetComponent<Rigidbody>().useGravity = true;

                    //this.GetComponentInChildren<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    //this.transform.position = new Vector2(hit.point.x, hit.point.y);
                    //this.GetComponent<Rigidbody2D>().bodyType;   //set bodytype to dyamic to apply forces

                    //Makes Blocks placed in the PlayArea non-draggable
                    IsPlaced = true;

                    //Collect Block GameObject to list BlocksInPlayIndex.
                    GameManager.Instance.SetBlockIntoPlay(this.gameObject);

                    //Store the index for the block within itself for reference
                    AssignedBlockIndexPos = GameManager.Instance.CurrentBlockIndexPos;

                    //Changes to the next Players turn after Block is placed.
                    //GameManager.Instance.NextTurn();

                    BlockGenerator.Instance.ReplaceBlock(initial, isPlayerOneBlock);
                    //BlockGenerator.Instance.ReplaceBlock(initial);


                    print("Assigned Block Index: " + AssignedBlockIndexPos);
                }
                else
                    this.transform.position = initial;
            }
            else
                this.transform.position = initial;
        } //end if (!IsPlaced)
        //}
    } //end EndDrag

    //    void OnCollisionEnter (Collision col) {
    //    if(this.IsDragging = true && col.gameObject.tag == "Draggable")
    //    {
    //        //check other for isPlaced. If true, ignore.
    //        //Destroy(col.gameObject);
    //        Physics.IgnoreCollision(this.GetComponent<Collider>(), col.gameObject.GetComponent<Collider>());
    //    }
    //} //end OnCollisionEnter

    //public override void TapObject()
    //{
    //    //if the object is placed play a note
    //     if(isPlaced)
    //        audioSource.Play();
    //} //end TapObject
} //end Block class
