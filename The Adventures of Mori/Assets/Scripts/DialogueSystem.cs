using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour
{
    public static string[] lines;
    public static string[] names;
    public float speedText;
    public Text dialogueText;
    public Text nameText;

    public static int index;

    public GameObject[] buttonOptions;

    private void Start()
    {
        dialogueText.text = string.Empty;
        nameText.text = string.Empty;
        StartDialogue();
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in names[index].ToCharArray())
        {
            nameText.text += c;
            yield return new WaitForSeconds(0);
        }

        foreach (char c in lines[index].ToCharArray())     
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
            nameText.text = names[index];
        }
    }

    private void NextLines()
    {
        if(index < lines.Length - 1)       
        {
            index++;
            dialogueText.text = string.Empty;
            nameText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            index = 0;
            if (DialogueNPC.indexFigth == 1)
            {
                DialogueNPC.figth = 1;
            }
            if (DialogueNPC.indexFigth == 2)
            {
                DialogueNPC.figth = 2;
            }
            if (DialogueNPC.indexFigth == 3)
            {
                DialogueNPC.figth = 3;
            }
            if (DialogueLarian.Options == 1)
            {
                dialogueText.text = string.Empty;
                nameText.text = string.Empty;
                buttonOptions[0].SetActive(true);
                buttonOptions[1].SetActive(true);
                buttonOptions[2].SetActive(true);
            }


            if (DialogueNPC.indexFigth == 1)
            {
                DialogueNPC.figth = 1;
            }
            if (DialogueNPC.indexFigth == 2)
            {
                DialogueNPC.figth = 2;
            }
            if (DialogueNPC.indexFigth == 3)
            {
                DialogueNPC.figth = 3;
            }
            if (DialogueSimilia.Options == 1)
            {
                dialogueText.text = string.Empty;
                nameText.text = string.Empty;
                buttonOptions[3].SetActive(true);
                buttonOptions[4].SetActive(true);
            }

            if (DialogueSelifx.Options == 1)
            {
                dialogueText.text = string.Empty;
                nameText.text = string.Empty;
                buttonOptions[5].SetActive(true);
                buttonOptions[6].SetActive(true);
                buttonOptions[7].SetActive(true);
            }

            if (DialogueSimilia.Options == 1)
            {
                Debug.Log("Hi");
            }
            else
            {   
                if (DialogueLarian.Options == 1)
                {
                    Debug.Log("Hi");
                }
                else
                {
                    if (DialogueSelifx.Options == 1)
                    {
                        Debug.Log("Hi");
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                }
            }

            if (DialogueSimilia.Options == 3)
            {
                DialogueSimilia.Options = 8;
            }          

            if (DialogueNPC.isCanSpawnLevel == 2)
            {
                DialogueNPC.isCanSpawnLevel = 3;
            }

            if (DialogueLarian.Options == 3)
            {
                DialogueLarian.Options = 8;
            }
            else if (DialogueLarian.Options == 5)
            {
                DialogueLarian.Options = 11;
            }

            if (DialogueSelifx.Options == 3)
            {
                DialogueSelifx.Options = 7;
            }
            else if (DialogueSelifx.Options == 5)
            {
                DialogueSelifx.Options = 12;
            }

            if (DialogueSpry2.indexDoneNPC2 == 1)
            {
                SceneManager.LoadScene(1);
            }

            DialogueBoss.indexLinesBoss = 1;
            MovePlayer.speed = 8;
        }
    }
}