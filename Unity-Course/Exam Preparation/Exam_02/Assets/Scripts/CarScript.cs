using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarScript : MonoBehaviour
{
    private const float MinZ = -1.7f;
    private const float MaxZ = 10f;
    public float Speed = 0.05f;

    public static int Health = 5;

    public Slider Healthbar;
    public GameObject GameOverMenu;
    public RoadScript RoadScript;

    float _horizontalAxis;
    float _verticalAxis;

    // Use this to move the car forward/backward and left/right
    private Rigidbody _rigidbody;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider coll)
    {

        // Detect hit with either tag "Health" or tag "Enemy"

        if (coll.tag == "Health" )
        {
            Health++;
        }
        else if (coll.tag == "Enemy")
        {
            Health--;
        }

        Healthbar.value = Health;
    }

    // Update is called once per frame
    void Update()
    {



        if (Health <= 0)
        {
            // GameOver
            RoadScript.RoadSpeed = 0f;
            GameOverMenu.SetActive(true);
        }
        else
        {
            _horizontalAxis = Input.GetAxis("Horizontal");
            _verticalAxis = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(_horizontalAxis, 0, _verticalAxis);

            _rigidbody.transform.Translate(movement * Speed * Time.deltaTime);
            

            if (MinZ > _rigidbody.transform.position.z)
            {
                _rigidbody.transform.position = new Vector3(_rigidbody.transform.position.x, _rigidbody.transform.position.y, MinZ);
            }
            if (MaxZ < _rigidbody.transform.position.z)
            {
                _rigidbody.transform.position = new Vector3(_rigidbody.transform.position.x, _rigidbody.transform.position.y, MaxZ);
            }

            // _rigidbody.position = new Vector3(_rigidbody.position.x, _rigidbody.position.y, Mathf.Clamp(_rigidbody.position.z, MinZ, MaxZ));



        }
    }
}
