using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float turnSpeed=100f;    // Çemberlerin dönme hýzý
    public bool turnDirection;  // Çemberlerin dönme yönü
 
    void Update()
    {
        if (turnDirection == false)
        {   // Eðer dönme yönü false ise saða dön
            transform.Rotate(0f, 0f, turnSpeed * Time.deltaTime);
        }
        else
        {   // Eðer dönme yönü false ise sola dön
            transform.Rotate(0f, 0f, -turnSpeed * Time.deltaTime);
        }
        
    }
}
