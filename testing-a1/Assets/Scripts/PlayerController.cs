using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
            GameObject tmpBall =  Instantiate(ballPrefab, ballTransform.position, ballTransform.rotation);
            tmpBall.GetComponent<Rigidbody>().velocity = ballTransform.forward * speed;
            
        }
    }
}
