using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float turnSpeed=100f;    // �emberlerin d�nme h�z�
    public bool turnDirection;  // �emberlerin d�nme y�n�
 
    void Update()
    {
        if (turnDirection == false)
        {   // E�er d�nme y�n� false ise sa�a d�n
            transform.Rotate(0f, 0f, turnSpeed * Time.deltaTime);
        }
        else
        {   // E�er d�nme y�n� false ise sola d�n
            transform.Rotate(0f, 0f, -turnSpeed * Time.deltaTime);
        }
        
    }
}
