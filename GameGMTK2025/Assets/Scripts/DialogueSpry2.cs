using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSpry2 : MonoBehaviour
{
    public string[] NPClines;
    public string[] NPCnames;

    public string[] NPClines1;
    public string[] NPCnames1;

    public string[] NPClines2;
    public string[] NPCnames2;
    public GameObject panelDialogue;

    public static int indexBossPower = 0;
    public static int indexDoneNPC = 0;
    public static int indexDoneNPC2 = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (indexBossPower == 0)
            {
                DialogueSystem.names = NPCnames;
                DialogueSystem.lines = NPClines;
            }
            else if (indexBossPower < 0)
            {
                DialogueSystem.names = NPCnames1;
                DialogueSystem.lines = NPClines1;
            }
            else if (indexBossPower > 0)
            {
                DialogueSystem.names = NPCnames2;
                DialogueSystem.lines = NPClines2;
            }

            panelDialogue.SetActive(true);
            MovePlayer.speed = 0;
            indexDoneNPC2 = 1;
        }
    }
}