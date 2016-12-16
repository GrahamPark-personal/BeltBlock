using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TileType
{
    Down = 0,
    Left,
    Right
}

public class Tile : MonoBehaviour {

    public TileType mType;

    [HideInInspector]
    public TileType mCurrDecision;

    float mSpeed;

    Rigidbody2D mRbody;

    Rect mRect;

    bool alreadyDeltWith = false;

    [HideInInspector]
    public bool mInArea = false;

    [HideInInspector]
    public bool mMoving = false;

    bool mFinished = false;

    Vector2 touchPos;
    Vector3 worldPoint;

    void Start ()
    {
        mRbody = GetComponent<Rigidbody2D>();
    }
	
    void FixedUpdate()
    {
        if (!mMoving || !mFinished)
        {
            mRbody.velocity = (new Vector2(0, -mSpeed));
        }
    }

	void Update ()
    {
        mSpeed = GameManager.sInstance.mConveySpeed;

        if (mInArea && !mFinished)
        {
            //if(Input.touchCount > 0)
            //{
            //    foreach (Touch touch in Input.touches)
            //    {
            //        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);
            //        Vector2 touchPos = new Vector2(worldPoint.x, worldPoint.y);
            //        Collider2D hit = Physics2D.OverlapPoint(touchPos);

            //        if(hit.tag == "Tile" && GameManager.sInstance.mInputController.thumbDown && !GameManager.sInstance.mTileHeld)
            //        {
            //            GameManager.sInstance.mTileHeld = true;
            //            touchPos = transform.position;
            //            mMoving = true;
            //            mInArea = false;
            //            break;
            //        }

            //    }
            //}

            if(GameManager.sInstance.mSwiped == true)
            {

                if(GameManager.sInstance.mInputController.mSwipeDir == SwipeDir.Left)
                {
                    mCurrDecision = TileType.Left;
                }
                else if (GameManager.sInstance.mInputController.mSwipeDir == SwipeDir.Right)
                {
                    mCurrDecision = TileType.Right;
                }

                //decision made
                if (mCurrDecision == TileType.Down)
                {
                    print("here");
                    if (mType == TileType.Down)
                    {
                        //pass
                        GameManager.sInstance.AddPoints(1);
                        transform.position = new Vector3(GameManager.sInstance.mTileSpawner.mSpawnPoint.position.x, transform.position.y, transform.position.z);
                    }
                    else
                    {
                        //fail
                        Destroy(this.gameObject);
                        GameManager.sInstance.EndGame();

                    }
                }
                else if (mCurrDecision == TileType.Left)
                {
                    if (mType == TileType.Left)
                    {
                        //pass
                        GameManager.sInstance.AddPoints(1);
                        transform.position = new Vector3(GameManager.sInstance.mTileSpawner.mLeftDecide.transform.position.x, transform.position.y, transform.position.z);
                    }
                    else
                    {
                        //fail
                        Destroy(this.gameObject);
                        GameManager.sInstance.EndGame();
                    }
                }
                else if (mCurrDecision == TileType.Right)
                {
                    if (mType == TileType.Right)
                    {
                        //pass
                        GameManager.sInstance.AddPoints(1);
                        transform.position = new Vector3(GameManager.sInstance.mTileSpawner.mRightDecide.transform.position.x, transform.position.y, transform.position.z);
                    }
                    else
                    {
                        //fail
                        Destroy(this.gameObject);
                        GameManager.sInstance.EndGame();
                    }
                }

                mFinished = true;
                mMoving = false;
                mInArea = false;

                GameManager.sInstance.mSwiped = false;
                GameManager.sInstance.mTileHeld = false;
            }
            else
            {
                //delt with after it passes the bottom

                //print("here");
                //if (mType == TileType.Down)
                //{
                //    //pass
                //    GameManager.sInstance.AddPoints(1);
                //    transform.position = new Vector3(GameManager.sInstance.mTileSpawner.mSpawnPoint.position.x, transform.position.y, transform.position.z);
                //}
                //else
                //{
                //    //fail
                //    Destroy(this.gameObject);
                //}

                //mFinished = true;
                //mMoving = false;
                //mInArea = false;

                //GameManager.sInstance.mSwiped = false;
                //GameManager.sInstance.mTileHeld = false;

            }

        }

        //if (mMoving)
        //{

        //    if (Input.touchCount > 0)
        //    {
        //            worldPoint = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
        //            touchPos = new Vector2(worldPoint.x, worldPoint.y);
        //            transform.position = new Vector3(touchPos.x, touchPos.y, transform.position.z);
        //    }
        //    else
        //    {
        //        //decision made
        //        mFinished = true;
        //        if (mCurrDecision == TileType.Down)
        //        {
        //            if(mType == TileType.Down)
        //            {
        //                //pass
        //                transform.position = new Vector3(GameManager.sInstance.mTileSpawner.mSpawnPoint.position.x, transform.position.y, transform.position.z);
        //            }
        //            else
        //            {
        //                //fail
        //                Destroy(this.gameObject);
        //            }
        //        }
        //        else if(mCurrDecision == TileType.Left)
        //        {
        //            if(mType == TileType.Left)
        //            {
        //                //pass
        //                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //            }
        //            else
        //            {
        //                //fail
        //                Destroy(this.gameObject);
        //            }
        //        }
        //        else if (mCurrDecision == TileType.Right)
        //        {
        //            if (mType == TileType.Right)
        //            {
        //                //pass
        //                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //            }
        //            else
        //            {
        //                //fail
        //                Destroy(this.gameObject);
        //            }
        //        }

        //        mMoving = false;
        //        GameManager.sInstance.mTileHeld = false;
        //    }
        //}
    }
}
