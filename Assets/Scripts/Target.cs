using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    
    
     public GameManager Game_Manager;
     public PlayerCollider Player_Collider;
     public Animator TargetAnimator;
     public Enemy _Enemy;
    private void OnCollisionEnter(Collision collision)
    {

        // --------top hedefe carptıgında  kapıyı ac ve oyuncu hizini 7 yap-------
        if (collision.gameObject.tag == "Ball")
        {
            TargetAnimator.SetBool("OpenDoor", true);
            TargetAnimator.SetBool("Turn", true);
         
               Game_Manager.PlayerSpeed = 7;


        }
        //--------- dusman topu hedefe carptıgında  dusman hizini 7 yap-----
        if (collision.gameObject.tag == "EnemyBall")
        {
            TargetAnimator.SetBool("OpenDoor", true);
            TargetAnimator.SetBool("Turn", true);

            _Enemy.EnemySpeed = 7;


        }
    }

    // ----------------------------------hızlandırıcı  tarafı------------------------
    //---------- top hızlandırıcıya carptıgında player collider kodunda ki hizlanmayi aktifleştir----------
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Player_Collider.BoosterActive = true;
            TargetAnimator.SetBool("Speed", true);
        }
        if (other.gameObject.tag == "EnemyBall")
        {
           _Enemy._BoosterActive = true;
            TargetAnimator.SetBool("Speed", true);
        }
    }

  
  
}
