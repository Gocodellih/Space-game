// HealthSystem.cs
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    private int maxHealth;
    private int currentHealth;
    

    // Reference to the UI Slider
    public Slider slider;           
    // Events for health-related actions
    public delegate void HealthChangedDelegate(int currentHealth, int maxHealth);
    //public event HealthChangedDelegate OnHealthChanged;
    public event HealthChangedDelegate OnHealthChanged;

    void Start()
    {
        InitializeHealth();
        UpdateHealthUI(GetCurrentHealth(), GetMaxHealth());
    }

    void InitializeHealth()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Beregn maxHealth baseret p� massen af Rigidbody'en
            maxHealth = Mathf.RoundToInt(rb.mass);
        }
        else
        {
            // Standardv�rdi for maxHealth, hvis Rigidbody ikke findes
            maxHealth = 100;
        }

        // S�t current health til max health ved start
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);



        UpdateHealthUI(GetCurrentHealth(), GetMaxHealth());


        if (currentHealth == 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI(GetCurrentHealth(), GetMaxHealth());
    }

    void Die()
    {
        // Tilf�j d�dsadf�rd her
        Debug.Log("Objektet er d�dt!");
        Destroy(gameObject);
    }

    void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        if (slider != null)
        {
            Debug.Log("Slider is not null");

            // Update Slider's value directly
            slider.value = currentHealth;
        }
        

     }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
