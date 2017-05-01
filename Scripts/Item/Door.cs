using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Item  {

    public string name;
    public string message;
    public bool isOpen;
    public bool isRightDoor;

    public string GetMessage()
    {
        return message;
    }

    public void Interract()
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            message = "Ouvrir la porte";
            if (isRightDoor)
            {
                this.GetComponent<Animation>().Play("close_right");
            }
            else
            {
                this.GetComponent<Animation>().Play("close_left");
            }
        }
        else
        {
            message = "Fermer la porte";
            if (isRightDoor)
            {
                this.GetComponent<Animation>().Play("open_right");
            }
            else
            {
                this.GetComponent<Animation>().Play("open_left");
            }
        }
        
    }



}
