using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    public static DialogueManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null )
        {
            Destroy(gameObject);
        }

        Instance = this;

        gameObject.AddComponent<AudioSource>();

    }

    public void BeginDialogue(AudioClip audioClip)
    {

    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
