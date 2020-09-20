using System;
using UnityEngine;
using UnityEngine.Events;

public static class Game
{
    public static int Record { get; private set; }
    public static int Score => Convert.ToInt32(_score);
    public static bool IsOver;
    public static bool IsPaused { get; private set; }

    public static float _score;
    public static int _scorePerSecond;

    public static event UnityAction GameStarted;
    public static event UnityAction GameLosed;

    public static void StartNewGame()
    {
        _score = 0;
        GameStarted?.Invoke();
    }

    public static void OverGame()
    {
        IsOver = true;

        if (Score > Record)
            PlayerPrefs.SetInt("record", Score);

        GameLosed?.Invoke();
    }

    public static void Initialize()
    {
        IsOver = false;
        IsPaused = false;

        _scorePerSecond = 50;

        if (PlayerPrefs.HasKey("record"))
            Record = PlayerPrefs.GetInt("record");
        else
        {
            Record = 0;
            PlayerPrefs.SetInt("record", 0);
        }
    }

    public static void Pause()
    {
        IsPaused = true;
        Time.timeScale = 0f;
    }

    public static void Continue()
    {
        IsPaused = false;
        Time.timeScale = 1f;
    }

    public static void AddScore(float passingTime)
    {
        Game._score += passingTime * Game._scorePerSecond;
    }
}
