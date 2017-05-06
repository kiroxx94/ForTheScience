using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public TextAsset textFile;
    public string[] textLines;
    public Text theText;

    public GameObject textBox;
    public int currentLine;
    public int endAtLine;

    public PlayerController player;


	// Use this for initialization
	void Start () {

        player = FindObjectOfType<PlayerController>();

        DialogContainer dialogContainer = DialogContainer.Load(textFile);

        foreach(Dialog dialog in dialogContainer.dialogs)
        {
            print(dialog.text);
        }

       /* if (textFile)
        {
            textLines = (textFile.text.Split('\n'));

        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }*/


	}
	
	// Update is called once per frame
	void Update () {
       // theText.text = textLines[currentLine];



	}
}
