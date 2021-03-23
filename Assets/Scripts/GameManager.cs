using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform Player;
    public float PlayerSpeed;
    public Rigidbody PlayerRb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player.Translate(0, 0, PlayerSpeed*Time.deltaTime);
    }
}
