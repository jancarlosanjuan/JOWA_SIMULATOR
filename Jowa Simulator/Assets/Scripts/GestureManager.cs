using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureManager : MonoBehaviour
{
    public static GestureManager Instance;
    public SwipeProperty _swipeProperty;
    //public TwoFingerPanProperty _twoFingerPanProperty;
    public RotateProperty _rotateProperty;
    public PlayerMode playerMode;
    public PlayerVariables playerVar;
    private Vector2 startPoint = Vector2.zero;
    private Vector2 endPoint = Vector2.zero;
    private float gestureTime = 0;
    Touch trackedFinger1;
    private Touch gesturefinger1;
    private Touch gesturefinger2;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touchCount == 1)
            {
                SingleTouch();
            }
            else
            {
                gesturefinger1 = Input.GetTouch(0);
                gesturefinger2 = Input.GetTouch(1);

                /*if(gesturefinger1.phase == TouchPhase.Moved && gesturefinger2.phase == TouchPhase.Moved &&
                    Vector2.Distance(gesturefinger1.position, gesturefinger2.position) <=
                    (_twoFingerPanProperty.maxDistance * Screen.dpi))
                {
                    FireTwoFingerPanGesture();
                    
                }*/
                if ((gesturefinger1.phase == TouchPhase.Moved ||
                    gesturefinger2.phase == TouchPhase.Moved) &&
                        Vector2.Distance(gesturefinger1.position, gesturefinger2.position) >=
                        (_rotateProperty.minDistance * Screen.dpi))
                {
                    Vector2 prevPoint1 = GetPreviousPoint(gesturefinger1);
                    Vector2 prevPoint2 = GetPreviousPoint(gesturefinger2);

                    Vector2 diff_vector = gesturefinger1.position - gesturefinger2.position;
                    Vector2 prev_diff_vector = prevPoint1 - prevPoint2;

                    float angle = Vector2.Angle(prev_diff_vector, diff_vector);

                    if (angle >= _rotateProperty.minChange)
                    {
                        Vector3 cross = Vector3.Cross(prev_diff_vector, diff_vector);
                        if (cross.z > 0)
                        {
                            Debug.Log("Counter CW");
                            playerVar.setBulletDirection(90);
                        }
                        else if (cross.z < 0)
                        {
                            Debug.Log("CW");
                            playerVar.setBulletDirection(270);
                        }
                    }
                }
            }
        }
    }

    private void SingleTouch()
    {
        trackedFinger1 = Input.GetTouch(0);

        if (trackedFinger1.phase == TouchPhase.Began)
        {
            startPoint = trackedFinger1.position;
            gestureTime = 0;
        }

        if (trackedFinger1.phase == TouchPhase.Ended)
        {
            endPoint = trackedFinger1.position;
            /*if (gestureTime <= _tapProperty.tapTime && Vector2.Distance(startPoint, endPoint) < (Screen.dpi * _tapProperty.tapMaxDistance))
            {
                //Debug.Log("TAP!");
                FireTapEvent(startPoint);
            }*/
            if (gestureTime <= _swipeProperty.swipeTime && 
                (Vector2.Distance(startPoint, endPoint) >= (_swipeProperty.minSwipeDistance * Screen.dpi)))
            {
                //Debug.Log("Swipe");
                FireSwipeEvents();
            }
        }
        else
        {
            gestureTime += Time.deltaTime;
        }
    }

    private void FireTwoFingerPanGesture()
    {
        Debug.Log("Two Finger Pan");
    }
    private Vector2 GetPreviousPoint(Touch t)
    {
        return t.position = t.deltaPosition;
    }

    private void FireSwipeEvents()
    {
        Vector2 diff = endPoint - startPoint;

        if(Mathf.Abs(diff.x) > Mathf.Abs(diff.y))
        {
            if(diff.x > 0)
            {
                playerMode.changeModeRight();
                Debug.Log("RIGHT");
            }
            else
            {
                playerMode.changeModeLeft();
                Debug.Log("LEFT");
            }
        }
        else
        {
            if(diff.y > 0)
            {
                Debug.Log("UP");
            }
            else
            {
                Debug.Log("DOWN");
            }
        }
    }
}
