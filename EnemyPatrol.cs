using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject player;

    private Vector3 enemyDirection = Vector3.forward;
    private float enemyFOV = 120f;
    private float enemySightDistance = 100f;
    private float enemySpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
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

        if (vec.magnitude < enemySightDistance)
        {
            float angle = Mathf.Acos(Vector3.Dot(enemyDirection, vec.normalized)) * Mathf.Rad2Deg;

            if (angle < enemyFOV / 2 || float.IsNaN(angle))
            {
                Debug.Log("Player detected");
                
                enemyDirection = vec.normalized;

                // go to player
                transform.Translate(enemyDirection * Time.deltaTime * enemySpeed, Space.World);
            }
        }
    }
}
