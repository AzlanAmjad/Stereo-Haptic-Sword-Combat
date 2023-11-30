using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] FloatingHealthBar floatingHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        floatingHealthBar.UpdateHealthBar(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Awake()
    {
        floatingHealthBar = GetComponentInChildren<FloatingHealthBar>(); 
    }
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        floatingHealthBar.UpdateHealthBar(health, maxHealth);
        if(health <= 0)
        {
            // commit die
        }
    }

}
