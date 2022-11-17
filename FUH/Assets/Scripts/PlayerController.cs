using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    List<string> ActivesItems = new();
    List<DialogueLine> dialogueList = new();

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        rigidbody2d = GetComponent<Rigidbody2D>();
        
        ReadDataCSV rd = new();
        rd.ReadFileData();
        rd.ExtractData();
        dialogueList = rd.dialogueList;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovimientoJugador();
    }

    private void MovimientoJugador() 
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 position = rigidbody2d.position;
        position.x += 3.0f * horizontal * Time.deltaTime;
        position.y += 3.0f * vertical * Time.deltaTime;
        
        rigidbody2d.MovePosition(position);
    }

    public void AddItem(string ItemName)
    {
        ActivesItems.Add(ItemName);
    }
    public List<string> GetItemList()
    {
        return ActivesItems;
    }
    public List<DialogueLine> GetDialogueLines() 
    {
        return dialogueList;
    }
}

public class ReadDataCSV
{
    public string datosString;

    public string dataPathAssets;
    public string DialogueDataName = "/Dialogos.csv";
    //private string persistentDataPath;

    public string header;
    public string[] lines;
    public List<DialogueLine> dialogueList = new();

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