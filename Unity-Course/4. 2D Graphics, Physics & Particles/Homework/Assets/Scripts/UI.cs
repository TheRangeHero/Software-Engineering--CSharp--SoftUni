using System;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image timerImage;
    public float timer;
    public Text gateCouterText;
    public Image gameOverScreen;
    public Text gameOverText;

    public int timerDefaultValue = 10;
    public int gateTimeBonusValue = 5;

    private int gatesPassed = -1;
    private int maxGatesCount;

    public void Start()
    {
        gameOverScreen.gameObject.SetActive(false);
        timer = timerDefaultValue;
        timerImage.fillAmount = 1;
        maxGatesCount = GameObject.Find("Obstacles").transform.childCount;
        UpdateGateCounter();
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        float percentMaxHealth = Mathf.InverseLerp(0, timerDefaultValue, timer);
        timerImage.fillAmount = percentMaxHealth;
        if (timer <= 0)
        {
            ShowGameOverScreenFail();
        }

        if (gatesPassed >= maxGatesCount)
        {
            ShowGameOverScreenPassed();
        }
    }

    public void UpdateTimer()
    {
        timer += gateTimeBonusValue;
    }

    public void UpdateGateCounter()
    {
        gatesPassed += 1;
        gateCouterText.text = $"{gatesPassed} / {maxGatesCount}";
    }

    public void ShowGameOverScreenPassed()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameOverText.text = "Passed";
        gameOverText.color = Color.green;
    }

    public void ShowGameOverScreenDeath()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameOverText.text = "YOU DIED";
        gameOverText.color = Color.red;
    }

    public void ShowGameOverScreenFail()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameOverText.text = "FAILED";
        gameOverText.color = Color.red;
    }

    public void OnRestartClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}
