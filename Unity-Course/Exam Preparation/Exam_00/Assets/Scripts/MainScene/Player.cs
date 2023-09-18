using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private FloatEvent onUpdateHealth = new FloatEvent();

    public static bool IsAlive { get; private set; }

    private int currentHealth;

    public void Awake()
    {
        IsAlive = true;
        UpdateHealth(maxHealth);
    }

    public void UpdateHealth(int value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);
        if (currentHealth <= 0)
        {
            IsAlive = false;
        }

        onUpdateHealth.Invoke(currentHealth);
    }
}
