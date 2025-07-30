using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    public string[] NPClines;
    public string[] NPCnames;
    public GameObject panelDialogue;

    public static float figth;
    public static float indexFigth;
    public float localIndexFigth;
    public bool isCanSpawnEnemy;
    public GameObject enemy;
    public GameObject hpEnemy;

    public static float isCanSpawnLevel;
    public GameObject miniGame;
    public GameObject player;
    public GameObject spriteSpry;

    public GameObject spry2;
    public Transform posSpry2;

    public void Update()
    {
        if (isCanSpawnLevel == 3 && isCanSpawnEnemy == false)
        {
            player.SetActive(false);
            miniGame.SetActive(true);
            spriteSpry.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DialogueSystem.names = NPCnames;
            DialogueSystem.lines = NPClines;
            DialogueSpry2.indexDoneNPC += 1;
            panelDialogue.SetActive(true);
            MovePlayer.speed = 0;
            indexFigth = localIndexFigth;
            if (isCanSpawnEnemy == false)
            {
                spry2.transform.position = posSpry2.position;
                isCanSpawnLevel = 2;
            }
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
        if (figth == localIndexFigth && isCanSpawnEnemy == true)
        {
            Player.powerEnemy = 15f;
            enemy.SetActive(true);
            hpEnemy.SetActive(true);
            Destroy(this.gameObject);
        }       
    }
}