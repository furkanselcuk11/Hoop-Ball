using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float turnSpeed=100f;
    public bool turnDirection;
    void Start()
    {
        
    }
    void Update()
    {
        if (turnDirection == false)
        {
            transform.Rotate(0f, 0f, turnSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0f, 0f, -turnSpeed * Time.deltaTime);
        }
        
    }
}
