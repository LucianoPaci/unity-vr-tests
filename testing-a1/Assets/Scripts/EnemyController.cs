using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public static Action OnEnemyDied = null;
    public float xRange;
    public float yRange;
    public float zRange;
    public float speed = 3f;
    void Start()
    {
        transform.LookAt(Camera.main.transform);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            //Destroy(gameObject); // Destroy ourself

            TeleportEnemy();

            //if(OnEnemyDied != null)
            //{
            //    OnEnemyDied();

            //}
        }

    }

    public void TeleportEnemy()
    {
        //UnityEngine.Random.Range(xRange)

        float newX = UnityEngine.Random.Range(-xRange, xRange);
        float newY = UnityEngine.Random.Range(1, yRange);
        float newZ = UnityEngine.Random.Range(-zRange, zRange);
        transform.position = new Vector3(newX, newY, newZ);
        transform.LookAt(Camera.main.transform);
    }
}
