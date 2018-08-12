//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


public delegate void OnTouchEnd();
public delegate void OnTouchStart();

public class Gesture : MonoSingleton<Gesture> {
   
    private bool tap;
    private bool swipeLeft;
    private bool swipeRight;
    private bool swipeDown;
    private bool swipeUp;
    private bool isSwiping;
    private bool dragging;
    private Vector2 startTouch;
    private Vector2 swipeDelta;
    private bool mobile = false;
    Ray ray;
    RaycastHit hit;

    public event OnTouchStart TouchStart;
    public event OnTouchEnd TouchEnd;
    private void Update() {
        tap = false;
        swipeLeft = false;
        swipeRight = false;
        swipeUp = false;
        swipeDown = false;

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            mobile = false;
            tap = true;
            isSwiping = true;
            dragging = true;
            startTouch = Input.mousePosition;
            if (TouchStart != null)
            {
                TouchStart();
            }
        } else if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            //If the touch ends call the function from another script
            if (TouchEnd != null)
            {
                TouchEnd();
            }
            Reset();
        }
        #endregion
        #region Mobile Inputs
        if (Input.touches.Length != 0)
        {
            mobile = true;
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isSwiping = true;
                tap = true;
                startTouch = Input.touches[0].position;
                dragging = true;
                if (TouchStart != null)
                {
                    TouchStart();
                }
            } else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                dragging = false;
                //If the touch ends call the function from another script
                if (TouchEnd != null)
                {
                    TouchEnd();
                }
                Reset();
            }
        }
        #endregion

        //Calculate Drag
        swipeDelta = Vector2.zero;
        if (isSwiping)
        {
            if (Input.touches.Length != 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0)) //Should this use Input.touches.Length = 0 instead?
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        //Significant Drag exists
        if (swipeDelta.magnitude > 125)
        {
            //direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //left or right
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }else
            {
                //up or down
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }

            Reset();
        }
    } //end Update

    private void Reset() {
        isSwiping = false;
        startTouch = Vector2.zero;
        swipeDelta = Vector2.zero;
    } //end Reset

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool Tap { get { return tap; }}
    public bool Dragging { get { return dragging; } }
    public Vector3 TouchPosition() {
        if (mobile)
           return Input.touches[0].position;
        else
           return Input.mousePosition;
    } //end TouchPosition
} //end Gesture class
