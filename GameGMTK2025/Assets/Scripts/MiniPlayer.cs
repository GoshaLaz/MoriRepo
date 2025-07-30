using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniPlayer : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    public Transform pointStart;

    public float setTimeLife;
    private float timeLife;
    public Image healthBar;

    private float multiplier;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        multiplier = 100 / setTimeLife;
    }

    private void Update()
    {
        healthBar.fillAmount = timeLife * multiplier / 100;
        timeLife -= Time.deltaTime;

        if (timeLife <= 0)
        {
            this.transform.position = pointStart.position;
            timeLife = setTimeLife;
        }
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(speed * x, speed * y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            this.transform.position = pointStart.position;
            timeLife = setTimeLife;
        }
    }
}