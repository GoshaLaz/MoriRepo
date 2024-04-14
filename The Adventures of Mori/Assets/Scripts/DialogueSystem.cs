using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public static string[] lines;
    public float speedText;
    public Text dialogueText;

    private int index;

    private void Start()
    {
        dialogueText.text = string.Empty;
        StartDialogue();
    }

    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(speedText);
        }
    }

    public void scipTextClip()
    {
        if (dialogueText.text == lines[index])
        {
            NextLines();
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = lines[index];
        }
    }

    private void NextLines()
    {
        if(index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}