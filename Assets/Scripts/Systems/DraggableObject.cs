//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour {

    // Use this for initialization
    protected Vector3 distance;
    float  positionX;
    float  positionY;
    public bool IsPlaced { get; set; }

    // Update is called once per frame
    //void Update () {}

    public virtual void BeginDrag(Vector3 pointerPosition) {
            distance = Camera.main.WorldToScreenPoint(transform.position);
            positionX = pointerPosition.x - distance.x;
            positionY = pointerPosition.y - distance.y;
    } //end BeginDrag

    public virtual void OnDrag(Vector3 pointerPosition) {
        Vector3 currentPosition = new Vector3(pointerPosition.x - positionX, pointerPosition.y - positionY, distance.z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(currentPosition);

        //keeps blocks from being dragged off camera. 
        //BUG: If touch held off camera then returned to screen, block will transform position
        if (currentPosition.y >= Screen.height || currentPosition.y <= 0 || currentPosition.x >= Screen.width || currentPosition.x <= 0)
        {
            EndDrag();
            //print("edge collision");
            //return;
        }
        else
        {
            this.transform.position = worldPosition;
        }
    } //end OnDrag

    public virtual void EndDrag() {
       //this.transform.position = initalPosition;
    } //end EndDrag

    public virtual void TapObject() {
        //this.transform.position = initalPosition;
    } //end TapObject
} //end DraggableObject class
