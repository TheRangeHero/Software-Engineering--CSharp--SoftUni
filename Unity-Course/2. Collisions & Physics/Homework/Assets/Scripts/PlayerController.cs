using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    public float horizontalInput;
    public float rollInput;

    private Rigidbody rb;
    public float verticalForce;
    public float horizontalForce;
    public float rollForce;
    public float forwardForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rb.AddRelativeForce(Vector3.forward * forwardForce, ForceMode.Acceleration);
        //transform.Translate(Vector3.forward * speed);

        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        rb.AddRelativeTorque(Vector3.left * verticalForce * verticalInput, ForceMode.Acceleration);

        // get the user's vertical input
        horizontalInput = Input.GetAxis("Horizontal");
        rb.AddRelativeTorque(Vector3.up * horizontalForce * horizontalInput, ForceMode.Acceleration);

        rollInput = 0;
        if (Input.GetKey(KeyCode.Q))
        {
            rollInput = -1;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rollInput = 1;
        }
        rb.AddRelativeTorque(Vector3.forward * rollForce * rollInput, ForceMode.Acceleration);

        // tilt the plane up/down/left/right based on arrow keys
        //transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontalInput);
        //transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime * rollInput);
    }
}
