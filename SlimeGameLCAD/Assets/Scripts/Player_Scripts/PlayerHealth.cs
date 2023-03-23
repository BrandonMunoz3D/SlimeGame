using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // The player's health at the start
    [SerializeField] private int healthInitial = 5;

    // The player's health right now
    private int healthCurrent;

    // Start is called before the first frame update
    void Start()
    {
        // Initialiase the player's current health
        ResetHealth();
    }

    public void ResetHealth()
    {
        // Reset the player's current health
        healthCurrent = healthInitial;
    }
    // Reduces the player's current health
    // (NB: Call this if hit by enemy, activated trap, etc)

    public void TakeDamage(int damageAmount)
    {
        // Deduct the provided damage amount from the player's current health
        healthCurrent -= damageAmount;

        // If the player has no health left now
        if (healthCurrent <= 0)
        {
            // Kill the player
            Destroy(gameObject);
        }
    }

    // Increase the player's current health
    // (NB: Call this if picked up potion, herb, etc)
    public void Heal(int healAmount)
    {
        // Add the provided heal amount to the player's current health
        healthCurrent += healAmount;

        // If the player has too much health now
        if (healthCurrent > healthInitial)
        {
            // Reset the player's current health
            ResetHealth();
        }
    }

}