using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject Enemy;

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
    }
    
}
