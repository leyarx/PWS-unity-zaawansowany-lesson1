using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CombatSystem))]
public class EnemyPatrol : MonoBehaviour
{
    public CombatSystem player;

    private Vector3 enemyDirection = Vector3.forward;
    private float enemyFOVHalf = 60f;
    private float enemySightDistance = 100f;
    private float enemySpeed = 2f;

    private CombatSystem cs;

    // Start is called before the first frame update
    void Start()
    {
        cs = GetComponent<CombatSystem>();

        if (!player)
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, enemyDirection * 10, Color.green);

        Vector3 vec = player.transform.position - this.transform.position;
        float distanceToPlayer = vec.magnitude;

        if (distanceToPlayer < enemySightDistance)
        {
            float angle = Mathf.Acos(Vector3.Dot(enemyDirection, vec.normalized)) * Mathf.Rad2Deg;

            if (angle < enemyFOVHalf || float.IsNaN(angle))
            {
                Debug.Log("Player detected");
                
                enemyDirection = vec.normalized;

                // go to player
                transform.Translate(enemyDirection * Time.deltaTime * enemySpeed, Space.World);

                // check if player in enemy attack range
                if (distanceToPlayer < cs.attackRange)
                {
                    player.TakeDamage(cs.damage);
                }
            }
        }
    }
}
