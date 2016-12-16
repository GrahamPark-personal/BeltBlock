using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionArea : MonoBehaviour {

	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Tile")
        {
            col.GetComponent<Tile>().mInArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Tile")
        {
            col.GetComponent<Tile>().mInArea = false;
        }
    }
}
