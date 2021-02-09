using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public float health = 100f;
    public float damage = 10f;
    public float attackRange = 3f;

    public void TakeDamage(float amount)
    {
        if(health > 0)
            health -= amount;
    }
}
