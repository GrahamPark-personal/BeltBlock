using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour {

    public GameObject[] mTiles;

    public GameObject mLeftDecide;
    public GameObject mRightDecide;

    public Transform mSpawnPoint;

    public float mInerval;

    float mCurrTime;

	void Start ()
    {
        mCurrTime = Time.time + mInerval;

    }
	
	
	void Update ()
    {
        if (GameManager.sInstance.mPlayingGame)
        {
            if (Time.time >= mCurrTime)
            {
                int tile = Random.Range(0, 4);
                if (tile != 4 && tile != 3)
                {
                    GameObject temp = Instantiate(mTiles[tile], mSpawnPoint.position, mSpawnPoint.rotation) as GameObject;
                }
                mCurrTime = Time.time + mInerval;
            }
        }
	}
}
