using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementChanger : MonoBehaviour {

    public TileType mChangeTo;


    void Start ()
    {
		
	}
	

	void Update ()
    {
		
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Tile")
        {
            col.GetComponent<Tile>().mCurrDecision = mChangeTo;
        }
    }
}
