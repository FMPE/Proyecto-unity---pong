using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    public Text scorePlayerText;
    public Text scoreEnemyText;

    public int maxQuantity = 0;
    private int scorePlayerQuantity = 0;
    private int scoreEnemyQuantity = 0;

    public SceneChanger sceneChanger;
    public AudioSource pointAudio;

    private void OnTriggerEnter2D(Collider2D ball)
    {
        if(gameObject.CompareTag("Izquierdo"))
        {
            scoreEnemyQuantity++;
            UpdateScoreLabel(scoreEnemyText, scoreEnemyQuantity);
        }
        else if(gameObject.CompareTag("Derecho"))
        {
            scorePlayerQuantity++;
            UpdateScoreLabel(scorePlayerText, scorePlayerQuantity);
        }
        pointAudio.Play();

        CheckScore();

        ball.GetComponent<BallBehaviour>().gameStarted = false;
    }

    void CheckScore()
    {
        if (scorePlayerQuantity >= maxQuantity)
        {
            sceneChanger.ChangeSceneTo("WinScene");
        }
        else if (scoreEnemyQuantity >= maxQuantity)
        {
            sceneChanger.ChangeSceneTo("LoseScene");
        }
    }

    private void UpdateScoreLabel(Text label, int score)
    {
        label.text = score.ToString();
    }
}
