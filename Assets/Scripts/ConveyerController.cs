using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConveyerController : MonoBehaviour {

    public float mSpeed;

    [HideInInspector]
    public Renderer mImg;

    [HideInInspector]
    public float mOffset;

    void Start()
    {
        mImg = GetComponent<Renderer>();
    }

    void Update()
    {
        mSpeed = GameManager.sInstance.mBackgroundSpeed;
        mOffset = Time.time * mSpeed;
        mImg.sharedMaterial.SetTextureOffset("_MainTex", new Vector2(0, mOffset));
    }
}
