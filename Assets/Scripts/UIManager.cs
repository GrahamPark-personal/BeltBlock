using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject mEndScreen;
    public GameObject mStartScreen;

    public Text mScore;
    public Text mEndScore;
    public Text mBestScore;
    public Text mMessage;

    public int mScoreNum;
    public int mBestScoreNum;
    public string mMessageStr;

    void Start ()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            mBestScoreNum = PlayerPrefs.GetInt("HighScore");
        }
	}
	

	void Update ()
    {

        if(GameManager.sInstance.mScore != mScoreNum)
        {
            mScoreNum = GameManager.sInstance.mScore;
        }


        mScore.text = "" + mScoreNum;
        mEndScore.text = "" + mScoreNum;
        mBestScore.text = "" + mBestScoreNum;
        mMessage.text = mMessageStr;
    }

    public void SetEndScreenVisible(bool op)
    {
        mEndScreen.SetActive(op);
    }

    public void SetStartScreenVisible(bool op)
    {
        mStartScreen.SetActive(op);
    }

    public void ButtonPress()
    {
        Debug.Log("Button Pressed");
        GameManager.sInstance.Reset();
    }
}
