using UnityEngine;
using UnityEngine.UI;

public class PlayerShipScript : MonoBehaviour
{
    public Slider scoreSlider;
    public static int Score;
    public GameObject RocketPrefab;
    public GameObject RocketLaunchPositionGO;

    float speed = 0.18f;
    float minX = -15f;
    float maxX = 15f;
    float minZ = -4.2f;
    float maxZ = 12f;
    float horizontalAxis;
    float verticalAxis;
    float planeReturnDampTime = 0.2f;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontalAxis * speed, 0f, verticalAxis * speed);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, Mathf.Clamp(transform.position.z, minZ, maxZ));

        var targetAngle = horizontalAxis * 20;
        var progress = Mathf.Abs(horizontalAxis) / 1f;
        var yAngle = Mathf.LerpAngle(transform.rotation.eulerAngles.y, targetAngle, progress);
        transform.rotation = Quaternion.Euler(0f, yAngle, 0f);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Fire");
            Fire();
        }

    }


    public void UpdateScore(int score)
    {
        Score += score;
        scoreSlider.value = Score;
    }

    private void Fire()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.tag == "Building")
            {

                var rocket = Instantiate(RocketPrefab, RocketLaunchPositionGO.transform.position, RocketLaunchPositionGO.transform.rotation);
                rocket.transform.LookAt(hit.transform);
            }

        }


    }
}
