using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

[XmlRoot("DialogCollection")]
public class DialogContainer {

    [XmlArray("Dialogs")]
    [XmlArrayItem("Dialog")]
    public List<Dialog> dialogs = new List<Dialog>();

    public static DialogContainer Load(TextAsset _xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(DialogContainer));
        StringReader reader = new StringReader(_xml.text);
        DialogContainer dialogs = serializer.Deserialize(reader) as DialogContainer;
        reader.Close();

        return dialogs;
    }


}
