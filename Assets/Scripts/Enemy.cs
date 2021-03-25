using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float EnemySpeed;
    public Animator EnemyAnimator;
    public Transform BallPosition;
    public GameObject EnemyBall;
    public bool _BoosterActive;
    public float ShootPower;
   
   // düsman engelin önündeki durdurucuya carptığında düsman hızını 0 yap ve 0.3 saniye Düsman ates etme kodunu calıstır
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TriggerStop")
        {
            EnemySpeed = 0;
            Invoke("EnemyFire", 0.3f);

        }
        // --------------booster a carptığında hızlanma aktif ise  Düsman hızını 12 yap---------
        if (other.gameObject.tag == "Booster")
        {
            if (_BoosterActive)
            {
                EnemySpeed = 12;
            }
        }
        // --------------booster a carptığında hızlanma aktif değil ise  Düsman hızını 4 yap---------
        if (other.gameObject.tag == "Booster")
        {
            if (!_BoosterActive)
            {
                EnemySpeed = 4;
            }
        }
        if (other.gameObject.tag == "BoosterFinish")
        {
            EnemySpeed = 7;
        }
      
    }
    //-----------------------------hedefe dogru  top attır--------------
    public void EnemyFire()
    {
        GameObject CreatedBall = Instantiate(EnemyBall, BallPosition.position, BallPosition.rotation);
        CreatedBall.GetComponent<Rigidbody>().velocity = transform.forward *ShootPower+transform.up*9f;
    }
    //---------------Oyun baslama tusuna basınca düsmananın hizini 7 yap---------
    public void StartButton()
    {
        EnemyAnimator.SetBool("Run", true);
        EnemySpeed = 7;
    }
   
  //---------------düsmanı ileri dogru dusman hızı degişkeninde sürekli hareket ettir---------
    void Update()
    {
        transform.Translate(0, 0, EnemySpeed * Time.deltaTime); 
    }
}
