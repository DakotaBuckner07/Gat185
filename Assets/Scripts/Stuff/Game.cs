using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    public static float Score { get; set; } = 0;
    public TextMeshProUGUI scoreUI;
    public GameObject startScreen;
    public GameObject gameOverScreen;
    public TextMeshProUGUI finalScoreUI;
    public AudioSource music;
    public float gameEndTimer = 5.0f;
    public Character character;
    public Health health;

    static Game instance = null;


    public enum eState
    {
        Title,
        StartGame,
        PauseGame,
        Game,
        GameOver
    }

    public eState State { get; set; } = eState.Title;

    private void Awake()
    {
        instance = this;
        health = GetComponent<Health>();
    }

    private void Update()
    {
        switch (State)
        {
            case eState.Title:
                startScreen.SetActive(true);
                gameOverScreen.SetActive(false);
                gameEndTimer = 5.0f;
                break;
            case eState.StartGame:
                startScreen.SetActive(false);
                Health.gameStarted = true;
                health.health = 100;
                Score = 0;
                music.Play();
                State = eState.Game;
                break;
            case eState.PauseGame:
                break;
            case eState.Game:
                Score += Time.deltaTime;
                scoreUI.text = "Score: " + (int)Score;
                if (health.health <= 0) State = eState.GameOver;
                break;
            case eState.GameOver:
                Health.gameStarted = false;
                gameEndTimer -= Time.deltaTime;
                music.Stop();
                if (gameEndTimer <= 0)
                {
                    gameOverScreen.SetActive(true);
                    finalScoreUI.text = "Final Score: " + (int)Score;
                }
                break;
        }
    }

    public static Game Instance
    {
        get
        {
            return instance;
        }
    }


    public void AddPoints(int points)
    {
        Score += points;
        scoreUI.text = string.Format("{0:D4}", Score);
    }

    public void StartGame()
    {
        State = eState.StartGame;
    }

    public void PauseGame()
    {
        State = eState.PauseGame;
    }

    public void RestartGame()
    {
        State = eState.Title;
        //character.transform.position = new Vector3(41.8f, 0, -51.1f);
        //character.transform.rotation = new Quaternion(0, -38.757f, 0, 0).normalized;
    }

    public void BackToTitleGame()
    {
        State = eState.Title;
        Score = 0;
    }
}
