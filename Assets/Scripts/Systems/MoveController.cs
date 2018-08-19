//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
    DraggableObject draggable;

    private void Awake() {
        Gesture.Instance.TouchStart += StartTouch;
        Gesture.Instance.TouchEnd += EndTouch;
    } //end Awake

    // Update is called once per frame
    void Update () {
        if (Gesture.Instance.Dragging)
        {
            if (draggable != null)
                draggable.OnDrag(Gesture.Instance.TouchPosition());
        }
        if (Gesture.Instance.Tap) {
            if (draggable != null)
                draggable.TapObject();
        }
    } //end Update

    public void StartTouch() {
        ray = Camera.main.ScreenPointToRay(Gesture.Instance.TouchPosition());

        GameObject scenepause = GameObject.Find("SceneManager");

        gamepausechecking ifpaused = scenepause.GetComponent<gamepausechecking>();

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //Added IF to check for pause state
            if (ifpaused.paused == false)
            {
                if (hit.transform.tag == "Draggable")
                {
                    draggable = hit.transform.GetComponent<DraggableObject>();

                    draggable.BeginDrag(Gesture.Instance.TouchPosition());
                }
            }
         }
    } //end StartTouch

    public void EndTouch() {
        if (draggable != null)
            draggable.EndDrag();
        draggable = null;
    } //end EndTouch
} //end MoveController class
