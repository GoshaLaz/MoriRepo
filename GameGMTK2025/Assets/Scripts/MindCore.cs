using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MindCore : MonoBehaviour
{
    public static float hpBoss = 100f;
    public float powerBoss;

    public Image healthBar;
    private Transform playerPos;

    public static float speed = 6f;
    public float timeDefence;
    public float timeAttack;

    private void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void Update()
    {
        healthBar.fillAmount = hpBoss / 100;

        if (hpBoss <= 0)
        {
            //SceneManager.LoadScene(2);
        }

        if (DialogueBoss.indexLinesBoss == 1)
        {
            if (hpBoss >= 40)
            {
                timeAttack -= Time.deltaTime;

                if (timeAttack >= 0)
                {
                    transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
                }
                else if (timeDefence >= 0)
                {
                    timeDefence -= Time.deltaTime;
                }
                else
                {
                    timeAttack = 4f;
                    timeDefence = 2f;
                }
            }

            else
            {
                speed = 7f;
                transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
                hpBoss -= Time.deltaTime * 2;
            }
        }

        else
        {
            hpBoss = 100;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.hpPlayer -= powerBoss;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.hpPlayer -= 0.2f;
        }
    }
}