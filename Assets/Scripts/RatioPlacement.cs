using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScreenType
{
    Width = 0,
    Height,
    None
}

public enum Opperand
{
    DividedBy = 0,
    MultipliedBy,
    Plus,
    Minus,
    None
}

[System.Serializable]
public struct ScreenVect2
{
    public ScreenType mScreenX;
    public Opperand mActionX;
    public float mNumX;

    [Space(10)]

    public ScreenType mScreenY;
    public Opperand mActionY;
    public float mNumY;
}

public class RatioPlacement : MonoBehaviour {

    public ScreenVect2 myPos;
    public ScreenVect2 mySize;

    Vector2 mFinPos;
    Vector2 mFinSize;

    void Start ()
    {
        mFinPos = GetNewPos(myPos);
        mFinSize = GetNewPos(mySize);

        transform.position += new Vector3(mFinPos.x, mFinPos.y,transform.position.z);
        //transform.localScale = mFinSize;
    }

    Vector2 GetNewPos(ScreenVect2 mPos)
    {
        float mNumberX = 0;
        float mNumberY = 0;

        if (mPos.mScreenX == ScreenType.Height)
        {
            mNumberX = Screen.height;
        }
        else if (mPos.mScreenX == ScreenType.Width)
        {
            mNumberX = Screen.width;
        }
        else
        {
            mNumberX = 0;
        }

        if (mPos.mActionX == Opperand.DividedBy)
        {
            if (mPos.mNumX != 0)
            {
                mNumberX = mNumberX / mPos.mNumX;
            }
            else
            {
                Debug.Log("tried to divide by zero");
            }
        }
        else if (mPos.mActionX == Opperand.Minus)
        {
            mNumberX = mNumberX - mPos.mNumX;
        }
        else if (mPos.mActionX == Opperand.MultipliedBy)
        {
            mNumberX = mNumberX * mPos.mNumX;
        }
        else if (mPos.mActionX == Opperand.Plus)
        {
            mNumberX = mNumberX + mPos.mNumX;
        }
        else if(mPos.mScreenX == ScreenType.None)
        {
            mNumberX = mPos.mNumX;
        }
        //y section
        if (mPos.mScreenY == ScreenType.Height)
        {
            mNumberY = Screen.height;
        }
        else if (mPos.mScreenY == ScreenType.Width)
        {
            mNumberY = Screen.width;
        }
        else
        {
            mNumberY = 0;
        }

        if (mPos.mActionY == Opperand.DividedBy)
        {
            if (mPos.mNumY != 0)
            {
                mNumberY = mNumberY / mPos.mNumY;
            }
            else
            {
                Debug.Log("tried to divide by zero");
            }
        }
        else if (mPos.mActionY == Opperand.Minus)
        {
            mNumberY = mNumberY - mPos.mNumY;
        }
        else if (mPos.mActionY == Opperand.MultipliedBy)
        {
            mNumberY = mNumberY * mPos.mNumY;
        }
        else if (mPos.mActionY == Opperand.Plus)
        {
            mNumberY = mNumberY + mPos.mNumY;
        }
        else if (mPos.mScreenY== ScreenType.None)
        {
            mNumberY = mPos.mNumY;
        }

        return new Vector2(mNumberX, mNumberY);
    }
	
}
