using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadDataCVS : MonoBehaviour
{
    string datosString;

    public string dataPathAssets;
    public string DialogueDataName = "/Dialogos.csv";
    //private string persistentDataPath;

    public string header;
    public string[] lines;
    public List<DialogueLine> dialogueList = new();

    [ContextMenu("Read File")]
    public void ReadFileData()
    {
        dataPathAssets = Application.dataPath;
        //persistentDataPath = Application.persistentDataPath;
        datosString = "";

        StreamReader sr = new(path: dataPathAssets + DialogueDataName);
        string line;

        while ((line = sr.ReadLine()) != null)
        {
            datosString += line + "\n";
        }
    }

    [ContextMenu("Extract Data")]
    public void ExtractData()
    {
        lines = datosString.Split('\n');
        header = lines[0];

        dialogueList.Clear();

        for (int i = 1; i < lines.Length - 1; i++)
        {
            string[] splittedLine = lines[i].Split(';');

            if (splittedLine.Length == 4)
            {
                dialogueList.Add(new DialogueLine()
                {
                    title = splittedLine[0],
                    lineNumber = int.Parse(splittedLine[1]),
                    role = splittedLine[2],
                    dialogue = splittedLine[3]
                });
                Debug.Log(dialogueList[^1]);
            }
        }
    }
}

public struct DialogueLine
{
    public string title;
    public int lineNumber;
    public string role;
    public string dialogue;
}