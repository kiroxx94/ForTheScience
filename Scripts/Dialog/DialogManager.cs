using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

    public TextAsset textFile;
    public bool autmaticStart = false;
    public bool destroyAtTheEnd = false;
    private int currentLine = 0;
    private Status status = Status.Pending;
    private bool enable = false;
    private DialogContainer dialogContainer;
    private float timer = 0;

    // Use this for initialization
    void Start()
    {
        dialogContainer = DialogContainer.Load(textFile);
        timer = dialogContainer.dialogs[currentLine].timer;
    }

    public void play()
    {
        enable = true;
        status = Status.Running;
        currentLine = 0;
        timer = dialogContainer.dialogs[currentLine].timer;
    }

    void OnGUI()
    {
        if ((enable || autmaticStart) && dialogContainer != null && dialogContainer.dialogs.Count > 0)
        {
            string message = dialogContainer.dialogs[currentLine].author + " : " +dialogContainer.dialogs[currentLine].text ;
            GUI.Box(new Rect((Screen.width / 2)- ((message.Length * 6)/2), Screen.height * 0.85f, (message.Length*6) , 25), message);
        }
    }


    // Update is called once per frame
    void Update()
    {
        // theText.text = textLines[currentLine];
        if ((enable || autmaticStart) && dialogContainer != null && dialogContainer.dialogs.Count > 0)
        {

            timer -= Time.deltaTime;

            if(timer < 0)
            {
                if(currentLine < dialogContainer.dialogs.Count-1)
                {
                    currentLine++;
                    timer = dialogContainer.dialogs[currentLine].timer;
                }
                else
                {
                    enable = false;
                    autmaticStart = false;

                    status = Status.Done;
                    if (destroyAtTheEnd)
                    {
                        Destroy(this.gameObject);
                    }
                }
               
            }


        }


    }
}
