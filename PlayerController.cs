using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CombatSystem))]
public class PlayerController : MonoBehaviour
{
    public CombatSystem enemy;
    private CombatSystem cs;

    // Start is called before the first frame update
    void Start()
    {
        cs = GetComponent<CombatSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = enemy.transform.position - this.transform.position;

        // Attack enemy
        if (Input.GetKeyDown(KeyCode.Space) && vec.magnitude < cs.attackRange)
        {
            enemy.TakeDamage(cs.damage);
        }
    }
}
