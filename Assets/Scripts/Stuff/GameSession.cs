using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class GameSession : MonoBehaviour
{
    public static float Score { get; set; } = 0;
    public TextMeshProUGUI scoreUI;
    public GameObject startScreen;
    public TextMeshProUGUI finalScoreUI;
    public GameObject gameOverScreen;
    public AudioSource music;
    public float gameEndTimer = 5.0f;
    public Character character;
    public Health health;
    public UnityEvent startSessionEvents;

    static GameSession instance = null;


    public enum eState
    {
        StartSession,
        Session,
        EndSession,
        GameOver
    }

    public eState State { get; set; } = eState.StartSession;

    private void Awake()
    {
        instance = this;
        health = GetComponent<Health>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        switch (State)
        {
            case eState.StartSession:
                Health.gameStarted = true;
                EventManager.Instance().TriggerEvent("StartSession");
                GameController.Instance.transition.StartTransition(Color.clear, 1);
                Score = 0;
                startSessionEvents?.Invoke();
                State = eState.Session;
                break;
            case eState.Session:
                break;
            case eState.EndSession:
                break;
            case eState.GameOver:
                break;
        }
    }

    public static GameSession Instance
    {
        get
        {
            return instance;
        }
    }


    public void AddPoints(int points)
    {
        Score += points;
        scoreUI.text = (Score + "/7");

        character.GetComponent<RaycastPerception>().distance -= 2;
    }
}
