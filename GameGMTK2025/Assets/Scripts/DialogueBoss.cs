using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBoss : MonoBehaviour
{
    public GameObject PanelDialogue;
    public GameObject hpBarBoss;

    public string[] NPClines;
    public string[] NPCnames;
    public static float indexLinesBoss;

    public void Awake()
    {
        DialogueSystem.names = NPCnames;
        DialogueSystem.lines = NPClines;
        PanelDialogue.SetActive(true);
        hpBarBoss.SetActive(false);
        indexLinesBoss = 0;
    }

    public void Update()
    {
        if (indexLinesBoss == 1)
        {
            Player.hpPlayer = 100f;
            PanelDialogue.SetActive(false);
            hpBarBoss.SetActive(true);
        }
    }
}