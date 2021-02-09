using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleBetween : MonoBehaviour
{
    public GameObject enemy;

    Vector3 playerDirection = Vector3.forward;

    void Update()
    {
        if(enemy)
        {
            Vector3 vec = enemy.transform.position - this.transform.position;
            Debug.Log(Mathf.Acos(Vector3.Dot(playerDirection, vec.normalized)) * Mathf.Rad2Deg);
        }
    }
}
