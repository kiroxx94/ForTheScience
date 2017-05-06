using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ConsumableItem : MonoBehaviour, Item
{

    public string message;

    public ItemType itemType;
    public int Quantity;
    

    public string GetMessage()
    {
        return message;
    }

    public void Interract()
    {
        print("i interact " + message);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
