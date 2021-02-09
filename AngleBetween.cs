using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleBetween : MonoBehaviour
{
    public GameObject enemy;
    float enemyBoundsRadius = 1f;

    Vector3 playerDirection = Vector3.forward;
    Vector3 playerRight;
    float playerBoundsRadius = 1f;

    private void Start()
    {
        playerRight = Vector3.Cross(playerDirection, Vector3.up);
        setImportantVariable();
    }
    
    private void setImportantVariable() 
    { 
        if (!enemy)
        {
            this.enabled = false;
        }
    }

    void Update()
    {
        Vector3 vec = enemy.transform.position - this.transform.position;

        if (playerBoundsRadius + enemyBoundsRadius > vec.magnitude)
        {
            Debug.Log("Collision!");
        }
        else
        {
            float angle = Mathf.Acos(Vector3.Dot(playerDirection, vec.normalized)) * Mathf.Rad2Deg;
            Debug.Log("Angle between player and enemy: " + angle);

            if(angle < 90)
            {
                Debug.Log("front");
            }
            else
            {
                Debug.Log("back");
            }


            if (Vector3.Dot(playerRight, vec.normalized) < 0)
            {
                Debug.Log("right");
            }
            else
            {
                Debug.Log("left");
            }
        }
    }
}
