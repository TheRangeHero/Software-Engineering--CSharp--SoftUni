using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    public GameObject itemToDrop;
    private float itemTodropDestroyDelay = 3f;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject item = GameObject.Instantiate(itemToDrop, transform.position, new Quaternion());
            item.SetActive(true);

            Destroy(item, itemTodropDestroyDelay);
        }
    }
}
