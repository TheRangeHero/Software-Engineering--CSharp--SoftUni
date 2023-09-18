using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.15f;

    [SerializeField]
    private float minX = -20f;

    [SerializeField]
    private float maxX = 20f;

    [SerializeField]
    private float minZ = 0f;

    [SerializeField]
    private float maxZ = 20f;

    private Transform transformCached;
    private float horizontalAxis;
    private float positionZ;

    // Start is called before the first frame update
    void Start()
    {
        transformCached = transform;
        positionZ = transformCached.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.IsAlive)
        {
            return;
        }

        horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalAxis, 0f, 0f);
        // transform.Translate(movement * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y,Mathf.Clamp(transform.position.z,minZ,maxZ));





        //Rotation
        float targetAngle = horizontalAxis * 20;
        float progress = Mathf.Abs(horizontalAxis);
        float yAngle = Mathf.LerpAngle(transformCached.rotation.eulerAngles.y, targetAngle, progress);
        transformCached.rotation = Quaternion.Euler(0f, yAngle, 0f);
    }
}
