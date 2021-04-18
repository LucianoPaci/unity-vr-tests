using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Invoke("DestroyBall", 4f);
    }

    public void DestroyBall()
    {
        Destroy(gameObject);
    }

    //private void Update()
    //{
    //    if (GameObject.FindGameObjectsWithTag("Ball").Length > 2)
    //    {
            

    //    }
    //}
}
 