using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterFinish : MonoBehaviour
{

    public Enemy _Enemy;
    public GameManager Game_Manager;
    public ControlPoint Control_Point;
    public ParticleSystem FinishParticalEffect;

    // ----------------Baslangıcta basarı efektini Gösterme-----------
    void Start()
    {
        FinishParticalEffect.Stop(true);
    }
    //-------Bitis cizgisine oyuncu carparsa basarı efektini göster,düsmanı durdur  bitişten sonraki oynayısı 2 saniye sonra  aktif et---
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _Enemy.EnemySpeed = 0;
            Invoke("AfterFinishStarr", 2f);
            FinishParticalEffect.Play(true);
            Debug.Log("OyunBitti");

        }
        //------------Bitiş cizgisine önce düşman carpar ise game over ekranını aç ve oyuncuyu durdur----- 
        if (other.gameObject.tag == "Enemy")
        {

            Game_Manager.GameOverUı.SetActive(true);
            Game_Manager.PlayerSpeed = 0;
        }
    }

    // -----------ControldekiPointteki bitişten sonraki ateş etmeyi çalıştır----------
    void AfterFinishStarr()
    {
        Control_Point.AfterFinishFire();
    }

    
}
