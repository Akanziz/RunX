using System.Collections;
using System.Collections.Generic;
using System.Net.Cache;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth; 
    public Image[] hearts;
    public Sprite heartSprite;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        gameManager = FindObjectOfType<GameManager>();
        UpdateHearts();
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            damage = 0;
        }
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        UpdateHearts();
        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = heartSprite;
                hearts[i].color = Color.white;
            }
            else
            {
                hearts[i].sprite = heartSprite;
                hearts[i].color = new Color(1f, 1f, 1f, 0.3f);
            }
        }
    }

    private void GameOver()
    {
        Destroy(gameObject);

        if(gameManager != null)
        {
            gameManager.GameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
