using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Image healthBar;
    public static float hpPlayer;
    public float maxHp;

    private float timeDefence;

    public static float powerEnemy;

    public bool isBossFight;

    private void Update()
    {
        healthBar.fillAmount = hpPlayer / 100;

        timeDefence -= Time.deltaTime;

        if (hpPlayer <= 0)
        {
            if (isBossFight == true)
            {
                SceneManager.LoadScene(1);
            }

            else
            {
                hpPlayer = 100;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (timeDefence <= 0)
            {
                hpPlayer -= powerEnemy;
                timeDefence = 2f;
            }
        }
    }
}