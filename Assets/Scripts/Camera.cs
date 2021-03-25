using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform Player;
   

   // kamera sürekli olarak belirli bir mesafe ile oyuncuyu takip etsin
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Player.position.z - 30f);
    }
}
