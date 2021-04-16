using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public static Action OnPlayerDied = null;

    public GameObject ballPrefab;
    public Transform ballTransform;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("BottomTrigger") || Input.GetButtonDown("Fire1"))
        {
            GameObject tmpBall = Instantiate(ballPrefab, ballTransform.position, ballTransform.rotation);
            tmpBall.GetComponent<Rigidbody>().velocity = ballTransform.forward * speed;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (OnPlayerDied != null)
            {
                OnPlayerDied();
            }

        }
    }
}
