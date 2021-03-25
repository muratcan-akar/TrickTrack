using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public GameManager Game_Manager;
    public float BoostSpeed;
    public bool BoosterActive;
   
    // -------------------------playerın carpmaları----- 
    private void OnTriggerEnter(Collider other)
    {
        // --------------booster a carptığında hızlanma aktif ise  player hızını 12 yap---------
        if (other.gameObject.tag == "Booster")
        {
            if (BoosterActive)
            {
                Game_Manager.PlayerSpeed = 12;
            }
        }
        // --------------booster a carptığında hızlanma aktif değil ise  player hızını 4 yap---------
        if (other.gameObject.tag == "Booster")
        {
            if (!BoosterActive)
            {
                Game_Manager.PlayerSpeed = 4;
                Debug.Log("carpti");
            }
        }
        //---------hızlandırıcıdan cıktğı zaman tekrar playerın hızını 7 yap-----------
        if (other.gameObject.tag == "BoosterFinish")
        {
            Game_Manager.PlayerSpeed = 7;
        }
        // -------------engelin önüne geldiği zaman oyuncunun hızını 0 yap--------
        if (other.gameObject.tag == "TriggerStop")
        {
            Game_Manager.PlayerSpeed = 0;
        }
        // --------finishline a carparsam   oyunu sonlandır------
        if (other.gameObject.tag == "FinishLine")
        {
            Game_Manager.PlayerSpeed = 0;
            Game_Manager.FinishGame();
        }


    }
   

   
}
