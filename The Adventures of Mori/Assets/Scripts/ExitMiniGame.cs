using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMiniGame : MonoBehaviour
{
    public GameObject player;
    public GameObject gameLevel;

    public string[] NPClines;
    public string[] NPCnames;
    public GameObject panelDialogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MiniPlayer")
        {
            
            DialogueSystem.names = NPCnames;
            DialogueSystem.lines = NPClines;
            panelDialogue.SetActive(true);
            player.SetActive(true);
            gameLevel.SetActive(false);
        }
    }
}