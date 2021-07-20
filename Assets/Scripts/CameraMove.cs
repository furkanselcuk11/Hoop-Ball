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
        {   // Eðer hedefin y eksenide pozisyonu cameranýn y eksenindeki pozisyonundan büyükse camera y ekseninde takip eder
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }
    }
}
