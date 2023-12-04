using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public EnemyScript enemyScript;
    public FloatingHealthBar floatingHealthBar;
    public float damage = 0.5f;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Touchable") && other.GetComponent<EnemyScript>())
        {
            enemyScript = other.GetComponent<EnemyScript>();
            enemyScript.TakeDamage(damage);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}