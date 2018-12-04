using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectrtionalPlatform : MonoBehaviour {

    private PlatformEffector2D effector2D;
    private float waitTime = 0f;


	// Use this for initialization
	void Start ()
    {
        effector2D = GetComponent<PlatformEffector2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.S))
        {
            effector2D.rotationalOffset = 180f;
            waitTime = 0.3f;
        }
        else if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
        else if(effector2D.rotationalOffset != 0f)
        {
            effector2D.rotationalOffset = 0f;
        }
		
	}
}
