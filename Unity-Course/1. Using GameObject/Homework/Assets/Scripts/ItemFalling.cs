using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFalling : MonoBehaviour
{
   

    void LateUpdate()
    {
        this.transform.Translate(new Vector3(0, -0.1f, 0));

        
    }
}
