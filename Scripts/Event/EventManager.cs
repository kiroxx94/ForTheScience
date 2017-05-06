using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventManager: MonoBehaviour {

    public EventType eventType;
    private Status status;
    public LayerMask targetMask;

    private DialogManager dialogManager; 


    public void Start()
    {
        dialogManager = GetComponent<DialogManager>();
    }


    public void Update()
    {
        
       

    }

    void OnTriggerEnter(Collider other)
    {
        var result = targetMask == (targetMask | (1 << other.gameObject.layer));
        if (result) {
            if (eventType == EventType.DialogManager && dialogManager && status == Status.Pending)
            {
                dialogManager.play();
            }
        }
    }


}
