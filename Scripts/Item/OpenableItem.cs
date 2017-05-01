using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenableItem : MonoBehaviour, Item  {

    private string message;
    public string message_Open;
    public string message_Close;

    public bool isOpen;

    public AnimationClip open_animation;
    public AnimationClip close_animation;

    void Start()
    {
        if (isOpen)
        {
            message = message_Open;
            this.GetComponent<Animation>().Play(close_animation.name);
        }
        else
        {
            message = message_Close;
            this.GetComponent<Animation>().Play(open_animation.name);
        }
    }

    public string GetMessage()
    {
        return message;
    }

    public void Interract()
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            message = message_Open;
            this.GetComponent<Animation>().Play(close_animation.name);
            
        }
        else
        {
            message = message_Close;
            this.GetComponent<Animation>().Play(open_animation.name);
        }
        
    }



}
