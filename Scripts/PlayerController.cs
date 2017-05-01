using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject objectInRay ;
    public int rayLength = 10;
    public KeyCode KeyToInterract = KeyCode.E;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength))
        {
            if (hit.collider.gameObject.CompareTag("Object"))
            {
                objectInRay = hit.collider.gameObject;
            }
            else
            {
                objectInRay = null;
            }
            Debug.DrawLine(ray.origin, hit.point);
        }
        else
        {
            objectInRay = null;
        }


        if (Input.GetKeyDown(KeyToInterract) && objectInRay)
        {
            objectInRay.GetComponent<Item>().Interract();
        }

    }

    void OnGUI()
    {
        if (objectInRay)
        {
            try
            {
                string message = "[" + KeyToInterract.ToString() + "] " + objectInRay.GetComponent<Item>().GetMessage();
                GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 150, 25), message);
            }
            catch (Exception e)
            {
               // print(e);
            }
        }
    }

}
