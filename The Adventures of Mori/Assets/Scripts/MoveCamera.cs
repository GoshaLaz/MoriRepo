using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float speed;
    private Transform posCamera;

    private void Awake()
    {
        posCamera = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, posCamera.position, speed * Time.deltaTime);
    }
}