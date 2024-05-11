using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayer : MonoBehaviour
{
    public bool isOnClick;
    private float timeActive;
    public float publicTimeActive;

    private float timeAttack;

    public Sprite[] SpriteEnemy;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        timeActive = publicTimeActive;
    }

    private void Update()
    {
        timeActive -= Time.deltaTime;    

        if (Input.GetMouseButtonDown(0))
        {
            if (timeActive <= 0)
            {
                isOnClick = true;
                timeActive = publicTimeActive;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && isOnClick == true)
        {
            Enemy.hpEnemy -= 15f;
            isOnClick = false;
        }

        if (collision.gameObject.tag == "Boss" && isOnClick == true)
        {
            MindCore.hpBoss -= 10f;
            isOnClick = false;
        }
    }
}