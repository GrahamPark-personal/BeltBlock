using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager sInstance = null;

    public ConveyerController mConveryer;
    public InputController mInputController;
    public TileSpawner mTileSpawner;
    public UIManager mUIManager;


    [HideInInspector]
    public int mScore = 0;

    public float mBackgroundSpeed;

    public bool mSwiped = false;

    float mStartSpeed;

    public float mConveySpeed;
    public float mConveyIncrease;
    public float mMaxSpeed;
    public float mInterval;
    float mTime;

    [HideInInspector]
    public bool mPlayingGame = false;

    [HideInInspector]
    public bool mPaused = false;

    [HideInInspector]
    public bool mTileHeld = false;

    float mResetTimer = 0;

    void Awake()
    {
        if(sInstance == null)
        {
            sInstance = this;
        }else
        {
            Destroy(this);
        }
    }

    
    void Start ()
    {
        mStartSpeed = mConveySpeed;
        mTime = Time.time + mInterval;

    }

    public void AddPoints(int amount)
    {
        if(amount >= 0)
        {
            mScore += amount;
        }
    }

	
	
	void Update ()
    {
        if (mPlayingGame)
        {
            if (mSwiped == true)
            {
                //get inputcontrollers direction
                mSwiped = false;
            }

            if (Time.time >= mTime && mConveySpeed < mMaxSpeed)
            {
                mConveySpeed += mConveyIncrease;
                mTime = Time.time + mInterval;
                //mTileSpawner.mInerval -= mConveyIncrease;
                if (mTileSpawner.mInerval < .3)
                {
                    mTileSpawner.mInerval = .3f;
                }

                if (mConveySpeed >= mMaxSpeed)
                {
                    mConveySpeed = mMaxSpeed;
                }
            }
        }else if(!mPaused && Time.time > mResetTimer)
        {
            if(Input.touchCount > 0)
            {
                StartGame();
            }
        }
	}

    public void Reset()
    {
        mResetTimer = Time.time + 0.1f;
        mUIManager.SetEndScreenVisible(false);
        mConveySpeed = mStartSpeed;
        mScore = 0;
        mUIManager.SetStartScreenVisible(true);
        mPlayingGame = false;
        mPaused = false;
    }

    public void EndGame()
    {
        mPaused = true;
        mPlayingGame = false;
        mUIManager.SetEndScreenVisible(true);

        GameObject[] mAllTiles = GameObject.FindGameObjectsWithTag("Tile");

        foreach (GameObject obj in mAllTiles)
        {
            Destroy(obj.gameObject);
        }

        if (mUIManager.mScoreNum > mUIManager.mBestScoreNum)
        {
            mUIManager.mBestScoreNum = mUIManager.mScoreNum;
        }
    }

    public void StartGame()
    {
        mUIManager.SetStartScreenVisible(false);
        mPlayingGame = true;
    }
}
