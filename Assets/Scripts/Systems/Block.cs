//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Block : DraggableObject {

    Ray ray;
    RaycastHit hit;
    Vector3 initial;
    //AudioSource audioSource;
    [SerializeField] bool isPlayerOneBlock = true;

    private void Awake() {
        isPlaced = false;
        //audioSource = this.GetComponent<AudioSource>();
    } //end Awake
    //private void Start(){}

    private void Update() {
        //casts a ray from the center of the object
        ray = new Ray(transform.GetComponent<Collider>().bounds.center, Vector3.forward);
        Debug.DrawRay(ray.origin, ray.direction * 1, Color.blue);
    } //end Update

    public override void BeginDrag(Vector3 pointerPosition) {
        if (!isPlaced) {
            //for single player remove this IF (not it's content)
            if ((isPlayerOneBlock && GameManager.Instance.isPlayerOne)|| (!isPlayerOneBlock && !GameManager.Instance.isPlayerOne)) {
                base.BeginDrag(pointerPosition);
                initial = this.transform.position;
            }
        } 
    } //end BeginDrag

    public override void OnDrag(Vector3 pointerPosition) {
        if (!isPlaced) {
            //for a single player remove this if (not it's content though)
            if ((isPlayerOneBlock && GameManager.Instance.isPlayerOne) || (!isPlayerOneBlock && !GameManager.Instance.isPlayerOne))
            {
                base.OnDrag(pointerPosition);
            }
        }    
    } //end OnDrag

    public override void EndDrag()
    {
        //checks if the ray hits something at 1 distance. Used to define context of space behind dragged block.
        if ((isPlayerOneBlock && GameManager.Instance.isPlayerOne) || (!isPlayerOneBlock && !GameManager.Instance.isPlayerOne)) {
            base.EndDrag();

            if (Physics.Raycast(ray, out hit, 1))
            {
                //checks hit object's tag
                if (hit.transform.tag == "PlayArea")
                {
                    this.transform.position = new Vector3(hit.point.x, hit.point.y, this.transform.position.z);
                    this.GetComponent<Rigidbody>().useGravity = true;
                    this.GetComponent<Rigidbody>().isKinematic = false;

                    //this.transform.position = new Vector2(hit.point.x, hit.point.y);
                    //this.GetComponent<Rigidbody2D>().bodyType;   //set bodytype to dyamic to apply forces

                    //Makes Blocks placed in the PlayArea non-draggable
                    isPlaced = true;   //possibly change tag to not be 'draggable' instead?

                    //Changes to the next Players turn after Block is placed.
                    GameManager.Instance.NextTurn();

                    //
                    // ERIC- Call BlockGenerator here. 
                    //Reference the value of isPlayerOneBlock if needed to identify P1 or P2.
                    //Reference this.transform.position = initial; to use the initial position of the block 
                    //that calls the generator to instantialize the new block in its position.
                    //

                }
                else
                    this.transform.position = initial;
            }
            else
                this.transform.position = initial;
        }
    } //end EndDrag

    //public override void TapObject()
    //{
    //    //if the object is placed play a note
    //     if(isPlaced)
    //        audioSource.Play();
    //} //end TapObject
} //end Block class
