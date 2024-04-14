using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    public string[] NPClines;
    public GameObject panelDialogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            panelDialogue.SetActive(true);
            DialogueSystem.lines = NPClines;
        }
    }  
}