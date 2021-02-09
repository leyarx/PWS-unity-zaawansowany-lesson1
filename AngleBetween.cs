using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleBetween : MonoBehaviour
{
    public GameObject enemy;

    Vector3 playerDirection = Vector3.forward;
    Vector3 playerRight;

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
        Debug.Log(Mathf.Acos(Vector3.Dot(playerDirection, vec.normalized)) * Mathf.Rad2Deg);

        if(Vector3.Dot(playerRight, vec.normalized) < 0)
        {
            Debug.Log("right");
        }
        else
        {
            Debug.Log("left");
        }
    }
}
