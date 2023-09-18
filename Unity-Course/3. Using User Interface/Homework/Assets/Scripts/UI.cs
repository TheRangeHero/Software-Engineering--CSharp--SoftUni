using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Slider timerUI;
    private int timerDefaultValue = 30;
    public int gateTimeBonusValue = 5;

    public Text gateCounterText;
    private int gatesPassed = -1;
    private int maxGateCount;

    public Image gameOverScreen;
    public Text gameOverText;

    void Start()
    {
        gameOverScreen.gameObject.SetActive(false);

        timerUI.value = timerDefaultValue;
        timerUI.minValue = 0;
        timerUI.maxValue = timerDefaultValue;
        maxGateCount = GameObject.Find("Gates").transform.childCount;
        UpdateGateCounter();
    }

    // Update is called once per frame
    void Update()
    {
        timerUI.value -= Time.deltaTime;

        if (timerUI.value<=0)
        {
            ShowGameOverScreenFailed();
        }

        if (gatesPassed>=maxGateCount)
        {
            ShowGameOverScreenPassed();
        }
    }

    public void Updatetimer()
    {
        timerUI.value += gateTimeBonusValue;
    }

    public void UpdateGateCounter()
    {
        gatesPassed += 1;
        gateCounterText.text = $"{gatesPassed} / {maxGateCount}";
    }

    public void ShowGameOverScreenPassed()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameOverText.text = "Passed";
        gameOverText.color = Color.green;
    }

    public void ShowGameOverScreenFailed()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameOverText.text = "FAILED";
        gameOverText.color = Color.red;
    }

    public void ShowGameOverScreenDeath()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameOverText.text = "YOU DIED";
        gameOverText.color = Color.red;
    }

    public void OnRestartClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}
