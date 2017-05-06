using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class PathFollower : MonoBehaviour {

    //public MoveType moveType;
    public bool automaticMove = true ;
    public bool loopPath = true; 
    public GameObject path;

    //public float speed = 5.0f;
    // public bool rotationEnabled = true;
    //public float rotationSpeed = 5.0f ;
    public float reachDistance = 1.0f;
    private Transform[] path_points;

    private int currentPoint = 0;

    // Params Gizmos

    public Color rayColor = Color.white;

    private NavMeshAgent agent;



    // Use this for initialization
    void Start () {
        path_points = path.GetComponentsInChildren<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update () {

        if (automaticMove)
        {
            Move();
        }


	}

    public void Move()
    {
        float dist = Vector3.Distance(path_points[currentPoint].position, transform.position);

        /*var rotation = Quaternion.LookRotation(path_points[currentPoint].position - transform.position);
        //Vector3 dir = path[currentPoint].position - transform.position;
        if (moveType == MoveType.MoveTowards)
        {
            transform.position = Vector3.MoveTowards(transform.position, path_points[currentPoint].position, Time.deltaTime * speed); // pas terrible dir * Time.deltaTime * speed
        }
        if (moveType == MoveType.Lerp)
        {
            transform.position = Vector3.Lerp(transform.position, path_points[currentPoint].position, Time.deltaTime * speed); // pas terrible dir * Time.deltaTime * speed
        }

        if (rotationEnabled)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }*/

        agent.SetDestination(path_points[currentPoint].position);


        if (dist <= reachDistance)
        {
            currentPoint++;
        }

        if (currentPoint >= path_points.Length && loopPath)
        {
            currentPoint = 0;
        }
        if(currentPoint >= path_points.Length && !loopPath)
        {
            currentPoint = path_points.Length;
        }
    }


    private void OnDrawGizmos()
    {

        Gizmos.color = rayColor;

        if (path != null)
        {

            path_points = path.GetComponentsInChildren<Transform>();
 
            for (int i = 0; i < path_points.Length; i++)
            {
                Vector3 position = path_points[i].position;

                if (i > 0)
                {
                    Vector3 previous = path_points[i - 1].position;
                    Gizmos.DrawLine(previous, position);
                }

                if (path_points[i] != null)
                {
                    Gizmos.DrawWireSphere(position, reachDistance);
                }
            }

            if(path_points.Length > 1 && loopPath)
            {
                Gizmos.DrawLine(path_points[0].position, path_points[path_points.Length - 1].position);
            }

        }
    }

}
