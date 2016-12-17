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

    float mBlockMoveSpeed = .5f;

    void Start ()
    {
        mRbody = GetComponent<Rigidbody2D>();
    }
	
    void FixedUpdate()
    {
        if (!mFinished)
        {
            mRbody.velocity = (new Vector2(0, -mSpeed));
        }
    }

	void Update ()
    {
        mSpeed = GameManager.sInstance.mConveySpeed;

        if (mInArea && !mFinished)
        {
            if(mType != TileType.Down && GameManager.sInstance.mScore < 10)
            {
                if(mType == TileType.Left)
                {
                    GameManager.sInstance.mLeftBar.material = GameManager.sInstance.mDecideColour;
                }
                if (mType == TileType.Right)
                {
                    GameManager.sInstance.mRightBar.material = GameManager.sInstance.mDecideColour;
                }
            }

            //GameManager.sInstance.mLeftBar

            if (GameManager.sInstance.mSwiped == true)
            {
                GameManager.sInstance.mLeftBar.material = GameManager.sInstance.mNormalColour;
                GameManager.sInstance.mRightBar.material = GameManager.sInstance.mNormalColour;

                if (GameManager.sInstance.mInputController.mSwipeDir == SwipeDir.Left)
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
                    if (mType == TileType.Down)
                    {
                        //pass
                        GameManager.sInstance.AddPoints(1);
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


            }

        }

        if (mFinished)
        {
            if (mType == TileType.Down)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(GameManager.sInstance.mTileSpawner.mSpawnPoint.position.x, transform.position.y, transform.position.z), mBlockMoveSpeed);
            }
            if (mType == TileType.Left)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(GameManager.sInstance.mTileSpawner.mLeftDecide.transform.position.x, transform.position.y, transform.position.z), mBlockMoveSpeed);
            }
            if (mType == TileType.Right)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(GameManager.sInstance.mTileSpawner.mRightDecide.transform.position.x, transform.position.y, transform.position.z), mBlockMoveSpeed);
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
