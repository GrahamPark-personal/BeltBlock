using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SwipeDir
{
    Down = 0,
    Left,
    Right
}

public class InputController : MonoBehaviour {

    public SwipeDir mSwipeDir = SwipeDir.Down;

    public float mMinSwipeDist;

    public float mMaxSwipeTime;

    public Image cube;


    [HideInInspector]
    public bool thumbDown = false;

    [HideInInspector]
    public Vector2 mStartPos = Vector2.zero;

    float mStartTime = 0.0f;


    public GameObject Sphere;

    public GameObject right;
    public GameObject left;



    void Start ()
    {
		
	}
	
	
	void Update ()
    {

        if (Input.touchCount > 0)
        {
            //Sphere.transform.position = new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, Sphere.transform.position.z);
            

            foreach (Touch touch in Input.touches)
            {

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        mStartPos = touch.position;
                        mStartTime = Time.time;
                        thumbDown = true;
                        break;
                    case TouchPhase.Canceled:
                        thumbDown = false;
                        break;
                    case TouchPhase.Ended:

                        float distance = (touch.position - mStartPos).magnitude;
                        float time = Time.time - mStartTime;

                        if (thumbDown && time < mMaxSwipeTime && distance > mMinSwipeDist)
                        {
                            Vector2 mDirection = touch.position - mStartPos;
                            Vector2 mSwipeType = Vector2.zero;

                            if(Mathf.Abs(mDirection.x) > Mathf.Abs(mDirection.y))
                            {
                                mSwipeType = Vector2.right * Mathf.Sign(mDirection.x);
                            }else
                            {
                                mSwipeType = Vector2.up * Mathf.Sign(mDirection.y);
                            }

                            mSwipeType = Vector2.right * Mathf.Sign(mDirection.x);

                            if (mSwipeType.x != 0.0f)
                            {
                                if (mSwipeType.x > 0.0f)
                                {
                                    //right
                                    mSwipeDir = SwipeDir.Right;
                                    GameManager.sInstance.mSwiped = true;
                                }
                                else
                                {
                                    //left
                                    mSwipeDir = SwipeDir.Left;
                                    GameManager.sInstance.mSwiped = true;
                                }
                            }

                            if (mSwipeType.y != 0.0f)
                            {
                                if (mSwipeType.y > 0.0f)
                                {
                                    //up
                                }
                                else
                                {
                                    //down
                                }
                            }
                        }
                        break;

                }
            }
	        

        }

    }
}
