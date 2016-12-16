using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnEntry : MonoBehaviour {

    public bool DownSpot;
	
	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<Tile>().mType != TileType.Down && DownSpot)
        {
            GameManager.sInstance.EndGame();
        }
        Destroy(col.gameObject);
    }
}
