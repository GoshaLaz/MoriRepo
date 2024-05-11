using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Image healthBar;
    public static float hpEnemy = 100;    
    public float maxHp;

    public float speed;
    private Transform playerPos;

    public float timeDefence = 2f;
    public float timeCycle = 5f;
    public bool isCanDefence;

    public string[] NPClines;
    public string[] NPCnames;
    public GameObject panelDialogue;
    public bool isCanTalk;

    public GameObject hpEnemyBar;

    public Sprite[] SpriteEnemy;
    private SpriteRenderer spriteRenderer;
    private bool isCanAnim = false;

    private void Awake()
    {
        hpEnemy = maxHp;
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        timeDefence -= Time.deltaTime;
        timeCycle -= Time.deltaTime;
        healthBar.fillAmount = hpEnemy / 100;
        if (timeCycle <= 0 && isCanDefence == false)
        {
            isCanDefence = true;
            timeDefence = 2f;
        }

        if (isCanDefence == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);

            if (isCanAnim == false)
            {
                healthBar.fillAmount = hpEnemy / 100;
                if (this.transform.position.y >= playerPos.position.y)
                {
                    spriteRenderer.sprite = SpriteEnemy[1];
                }

                else if (this.transform.position.y < playerPos.position.y)
                {
                    spriteRenderer.sprite = SpriteEnemy[0];
                }
            }
        }
        if (isCanDefence == true)
        {
            if (timeDefence <= 0)
            {
                isCanDefence = false;
                timeCycle = 5f;
            }
        }

        if (hpEnemy <= 0)
        {
            Player.powerEnemy = 0f;
            Player.hpPlayer = 100f;
            DialogueSpry2.indexBossPower -= 1;
            if (isCanTalk == true)
            {
                DialogueSystem.names = NPCnames;
                DialogueSystem.lines = NPClines;
                panelDialogue.SetActive(true);
            }
            MovePlayer.speed = 0;
            hpEnemyBar.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isCanAnim = true;
            StopCoroutine(ExampleCoroutine());
            StartCoroutine(ExampleCoroutine());
        }
    }

    IEnumerator ExampleCoroutine()
    {
        healthBar.fillAmount = hpEnemy / 100;
        spriteRenderer.sprite = SpriteEnemy[2];
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.sprite = SpriteEnemy[3];
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.sprite = SpriteEnemy[4];
        yield return new WaitForSeconds(0.3f);
        isCanAnim = false;
        healthBar.fillAmount = hpEnemy / 100;
    }
}