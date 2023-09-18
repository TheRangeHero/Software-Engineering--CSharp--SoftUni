using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public delegate void PauseGame();

public class PlayerLogicScript : MonoBehaviour
{

    public Text score;
    public Slider health;
    public event PauseGame pauseGame;
    int _health;
    int _score;
    bool isAlive = true;

    void Start()
    {
        Health = 100;

        PlayerPrefs.SetInt("Score", _score);
    }

    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }

    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            if (isAlive)
            {
                _score = value;
            }
        }
    }

    public void OnPauseClicked()
    {
        pauseGame.Invoke();
    }

    void DestroyMe()
    {
        if (!isAlive)
        {
            return;
        }

        isAlive = false;
        _score = 0;
        PlayerPrefs.Save();
    }



    public void Update()
    {
        score.text = _score.ToString();
        health.value = _health;
        PlayerPrefs.Save();
    }
}