using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Dialog {

    [XmlElement("Author")]
    public string author;

    [XmlElement("timer")]
    public float timer;

    [XmlElement("text")]
    public string text;

}
