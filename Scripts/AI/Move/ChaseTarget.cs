using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseTarget : MonoBehaviour {

    // Target

    private GameObject target;

    // Move configuration

 //   public MoveType moveType;

    // Speed configuration

 //   public int speed;

    // Rotation config

  //  public bool rotationEnabled;
  //  public int rotationSpeed;

    private NavMeshAgent agent;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void setTarget(GameObject target)
    {
        this.target = target;
    }

    public void Move()
    {
        if (target)
        {

           // var rotation = Quaternion.LookRotation(target.transform.position - transform.position);

            /*if (moveType == MoveType.MoveTowards)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed); // pas terrible dir * Time.deltaTime * speed
            }
            if (moveType == MoveType.Lerp)
            {
                transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * speed); // pas terrible dir * Time.deltaTime * speed
            }*/

            agent.SetDestination(target.transform.position);

            /* if (rotationEnabled)
             {
                 //  transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
             }/*/
        }


    }

}
