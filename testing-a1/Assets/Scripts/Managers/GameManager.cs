using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject Enemy;
    public GameObject Ball;
    public GameObject Player;
    public static Action OnRestart;

    private void OnEnable()
    {
        PlayerController.OnPlayerDied += GameOver;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerDied -= GameOver;
    }

    void GameOver()
    {
        Canvas.SetActive(true);
        Enemy.SetActive(false);
        Player.GetComponent<PlayerController>().ResetPosition();
    }


    public void Restart()
    {
        Canvas.SetActive(false);
        Enemy.GetComponent<EnemyController>().TeleportEnemy();
        Enemy.SetActive(true);
        Player.GetComponent<PlayerController>().ResetPosition();
        if (OnRestart != null)
        {
            OnRestart();
        }
    }
    
}
