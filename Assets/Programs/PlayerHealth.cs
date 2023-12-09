using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   public int health;
   public int maxHealth = 4;

   public SpriteRenderer playerSr;
   public CharacterController playerMm;

    void Start()
    {
        health = maxHealth;
    }

   public void TakeDamage(int amount)
   {
        health -= amount;
        if(health <= 0)
        {
            playerSr.enabled = false;
            playerMm.enabled = false;
        }
   }
    void Update()
    {
        
    }
}
