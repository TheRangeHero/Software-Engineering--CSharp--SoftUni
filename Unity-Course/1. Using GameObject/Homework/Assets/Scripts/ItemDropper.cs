using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    public GameObject itemToDrop;
    private float destroyDelay = 4.0f;
    void Update()
    {
        var cubeSpawnPosition = transform.position + new Vector3(0, -1.5f, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject item = GameObject.Instantiate(itemToDrop, cubeSpawnPosition, new Quaternion());
            item.SetActive(true);

            Destroy(item, destroyDelay);
        }
    }
}
