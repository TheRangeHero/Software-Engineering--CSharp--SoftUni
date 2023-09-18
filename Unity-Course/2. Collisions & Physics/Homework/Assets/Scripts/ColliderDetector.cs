using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "GateDetectorTag")
        {
            Debug.Log("Gate passed!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GateWalls")
        {
            Debug.Log("Plane crashed! Game Over");                     
            
        }

    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.magenta);
            Debug.Log("Did Hit");
        }

    }
}
