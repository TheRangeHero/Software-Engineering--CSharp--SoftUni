using UnityEngine;

public class SelfRotateScript : MonoBehaviour
{
    [SerializeField]
	private float _rotateSpeed = 60f;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up*_rotateSpeed, Space.Self);
    }
}
