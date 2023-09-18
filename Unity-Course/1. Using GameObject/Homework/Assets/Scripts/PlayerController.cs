using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    private float horizontalInput;
    private float rollInput;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move forward
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime * 20);

        //Rotate up/down
        verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);

        //rotate left/right
        horizontalInput = Input.GetAxis("Horizontal");
        this.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontalInput);

       //rotate around him
        rollInput = 0;
        if (Input.GetKey(KeyCode.Q))
        {
            rollInput = -1;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rollInput = 1;
        }
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime * rollInput);


        //bool rotateRightKey = Input.GetKey(KeyCode.E);
        //bool rotateLeftKey = Input.GetKey(KeyCode.Q);

        //if (rotateRightKey)
        //{
        //    this.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        //}
        //else if (rotateLeftKey)
        //{
        //    this.transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        //}
    }
}
