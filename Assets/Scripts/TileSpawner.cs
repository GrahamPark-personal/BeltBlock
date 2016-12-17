using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour {

    public GameObject[] mTiles;

    public GameObject mLeftDecide;
    public GameObject mRightDecide;

    public Transform mSpawnPoint;

    [HideInInspector]
    public float mStartInt;

    public float mInerval;
    public float mDecrease;

    float mCurrTime;

	void Start ()
    {
        mCurrTime = Time.time + mInerval;
        mStartInt = mInerval;
    }
	
	
	void Update ()
    {

        if (GameManager.sInstance.mPlayingGame)
        {
            if (Time.time >= mCurrTime)
            {
                if (mInerval > 0.2 && GameManager.sInstance.mConveySpeed < GameManager.sInstance.mMaxSpeed)
                {
                    mInerval -= mDecrease;
                }

                if (GameManager.sInstance.mScore < 5)
                {
                    int tile = Random.Range(1, 3);
                    if (tile != 3)
                    {
                        GameObject temp = Instantiate(mTiles[tile], mSpawnPoint.position, mSpawnPoint.rotation) as GameObject;
                    }
                }
                else
                {
                    int tile = Random.Range(0, 3);
                    if (tile != 4 && tile != 3)
                    {
                        GameObject temp = Instantiate(mTiles[tile], mSpawnPoint.position, mSpawnPoint.rotation) as GameObject;
                    }
                }

                mCurrTime = Time.time + mInerval;
            }
        }
	}
}
