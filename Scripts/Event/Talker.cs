using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talker : MonoBehaviour {



    private bool enable = false ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void play()
    {
        enable = true;
    }

    void OnGUI()
    {
        if (enable)
        {

        }
    }


}
