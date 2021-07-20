using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;    // Takip edilecek obje
    void Start()
    {
        
    }
    void Update()
    {
        if (target.position.y > transform.position.y)
        {   // E�er hedefin y eksenide pozisyonu cameran�n y eksenindeki pozisyonundan b�y�kse camera y ekseninde takip eder
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }
    }
}
