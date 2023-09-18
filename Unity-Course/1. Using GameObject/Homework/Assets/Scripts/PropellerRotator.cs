using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerRotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.back * 1000*Time.deltaTime);
    }
}
