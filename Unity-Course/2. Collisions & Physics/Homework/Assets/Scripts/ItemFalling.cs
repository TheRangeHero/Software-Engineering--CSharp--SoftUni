using UnityEngine;

public class ItemFalling : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.AddComponent<Rigidbody>();
    }
}
