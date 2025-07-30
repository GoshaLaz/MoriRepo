using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSelifx : MonoBehaviour
{
    public string[] NPClines;
    public string[] NPCnames;
    public GameObject panelDialogue;

    public string[] NPClines1;
    public string[] NPCnames1;

    public string[] NPClines2;
    public string[] NPCnames2;

    public string[] NPClines3;
    public string[] NPCnames3;
    public static float Options;

    public GameObject[] buttonOptions;

    public GameObject enemy;
    public GameObject hpEnemy;

    public GameObject player;
    public GameObject miniGame;
    public GameObject spriteSelifx;

    public void Update()
    {
        if (Options == 7)
        {
            player.SetActive(false);
            miniGame.SetActive(true);
            spriteSelifx.SetActive(true);
            Destroy(gameObject);
        }

        if (Options == 12)
        {
            spriteSelifx.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void DialogueOption()
    {
        DialogueSystem.names = NPCnames1;
        DialogueSystem.lines = NPClines1;
        buttonOptions[0].SetActive(false);
        buttonOptions[1].SetActive(false);
        buttonOptions[2].SetActive(false);
        Options = 3;
    }

    public void DialogueOption2()
    {
        DialogueSystem.names = NPCnames2;
        DialogueSystem.lines = NPClines2;
        buttonOptions[0].SetActive(false);
        buttonOptions[1].SetActive(false);
        buttonOptions[2].SetActive(false);
        Options = 4;
    }

    public void DialogueOption3()
    {
        DialogueSystem.names = NPCnames3;
        DialogueSystem.lines = NPClines3;
        buttonOptions[0].SetActive(false);
        buttonOptions[1].SetActive(false);
        buttonOptions[2].SetActive(false);
        Options = 5;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DialogueSystem.names = NPCnames;
            DialogueSystem.lines = NPClines;
            DialogueSpry2.indexDoneNPC += 1;
            Options = 1;
            panelDialogue.SetActive(true);
            MovePlayer.speed = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            panelDialogue.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Options == 4)
        {
            Player.powerEnemy = 15f;
            Debug.Log("Ok");
            enemy.SetActive(true);
            hpEnemy.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}