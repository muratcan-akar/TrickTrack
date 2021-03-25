using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineTarget : MonoBehaviour
{
    
    public Animator FinishLineAnimator;
 
    // -----Finislineda ki hedefe top carpar ise parcalanmayı aktif et------
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
           
            FinishLineAnimator.SetBool("Trigger", true);

        }
    }


}
