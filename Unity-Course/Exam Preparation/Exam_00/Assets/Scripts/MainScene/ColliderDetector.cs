using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    public IntEvent OnObstacleHit;
    
    void OnCollisionEnter(Collision collision)
    {
        if (Player.IsAlive && (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Barrel"))
        {
            if (collision.gameObject.CompareTag("Barrel"))
            {
                OnObstacleHit.Invoke(collision.gameObject.GetComponent<Obstacle>().Damage);
            }
            else if (collision.gameObject.CompareTag("Obstacle"))
            {
                OnObstacleHit.Invoke(collision.gameObject.GetComponent<Obstacle>().Damage);
            }
            
           
        }
    }
}
