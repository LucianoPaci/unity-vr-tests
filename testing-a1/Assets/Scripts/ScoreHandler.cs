using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private int score;

    private TextMeshPro variableText;

    private void OnEnable()
    {
        EnemyController.OnEnemyDied += UpdateScore;
        GameManager.OnRestart += ResetScore;

    }
    private void OnDisable()
    {
        EnemyController.OnEnemyDied -= UpdateScore;
        GameManager.OnRestart -= ResetScore;
    }

    private void Start()
    {
        variableText = GetComponent<TextMeshPro>();
    }

    private void UpdateScore()
    {
        score++;
        variableText.text = "Score: " + score.ToString();
    }

    private void ResetScore()
    {
        score = 0;
        variableText.text = "Score: " + score.ToString();
    }
}
