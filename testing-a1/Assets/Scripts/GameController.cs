using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    private int _badCount = 0;
    private int _goodCount = 0;
    private bool timeIsOver = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
  
        if(timeIsOver)
        {
            if(_badCount <= _goodCount)
            {
                Debug.Log("you lose!");
                return;
            }
            else
            {
                Debug.Log("You Won!");
                return;
            }
        }
        
    }
}
