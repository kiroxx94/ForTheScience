using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventManager: MonoBehaviour {

    public EventType eventType;
    public Status status;
    public LayerMask targetMask;

    private Talker talker;

    
    public void Start()
    {
        talker = GetComponent<Talker>();
    }


    public void Update()
    {
        
       

    }

    void OnTriggerEnter(Collider other)
    {
        var result = targetMask == (targetMask | (1 << other.gameObject.layer));
        if (result) {
            if (eventType == EventType.Talker && talker && status == Status.Pending)
            {
                talker.play();
            }
        }
    }


}
