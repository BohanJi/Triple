using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] GameObject dialogueMask;
    [SerializeField] GameObject dialoguePanel;
    public string dialogueTitol;

    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;
    private TMP_Text ActiveDialogueText;

    private List<DialogueLine> dialogueLines = new();

    ReadDataCVS dialogues;

    // Start is called before the first frame update
    void Start()
    {
        dialogues = FindObjectOfType<ReadDataCVS>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetButtonDown("Interaction"))
        {
            if (!didDialogueStart)
                StartDialogue();
            else NextDialogueLine();
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialogueMask.SetActive(true);
        lineIndex = 0;
        ShowLine();
    }

    private void ShowLine()
    {
        ActiveDialogueText.text = dialogueLines[lineIndex].dialogue;
    }

    private void NextDialogueLine()
    {
        ActiveDialogueText.text = string.Empty;
        lineIndex++;
        if (lineIndex < dialogueLines.Count)
        {
            ShowLine();
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMask.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMask.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMask.SetActive(false);
        }
    }
}