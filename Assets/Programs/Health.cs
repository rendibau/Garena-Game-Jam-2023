// Health.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

    void Update()
    {
        int currentHealth = playerHealth.GetCurrentHealth();
        int maxHealth = playerHealth.maxHealth;

        for (int i = 0; i < 4; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
