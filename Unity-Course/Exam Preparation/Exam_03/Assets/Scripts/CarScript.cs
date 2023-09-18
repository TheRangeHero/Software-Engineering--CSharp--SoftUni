using UnityEngine;
using System.Collections;

public class CarScript : MonoBehaviour
{
	public static bool IsAlive;

    public GuiManager GuiManager;
	public GameObject Explosion;
    private float _moveSpeed = 0.05f;
	private float _zMax = 7.19f;
	private float _zMin = 1.61f;
	private float _xMin = 10.53f;
	private float _xMax = 18.36f;
	private float _yCoordinate = 0.415f;
    public int Score;
    float _gameTime;

	// Use this for initialization
	void Start ()
    {
        IsAlive = true;
        Score = PlayerPrefs.GetInt("Score", 0);
        GuiManager.ScoreLbl.text = string.Format("Score : {0}", Score.ToString());
        _gameTime = 0f;
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (IsAlive)
        {
            ManageInput();
            ManageLimitations();
            ManageSensitivity();
        }
	}

    void ManageInput()
    {

    }

    void ManageLimitations()
    {

    }

    void ManageSensitivity()
    {
        if (Time.timeSinceLevelLoad > (_gameTime + 15))
        {
            _gameTime += 15;
            _moveSpeed += 0.01f;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Crash();
			col.gameObject.SetActive(false);
        }
        else if (col.tag == "Coin")
        {
            col.gameObject.SetActive(false);
        }
    }

    void Crash()
    {
        IsAlive = false;
        GuiManager.ShowDeadText();
    }

}
