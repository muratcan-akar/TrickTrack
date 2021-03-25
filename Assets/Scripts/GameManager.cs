using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public Animator PlayerAnimator;
 
    public Transform Player;
    public float PlayerSpeed=0;
    public Rigidbody PlayerRb;
  
    public GameObject StartButon;
    public GameObject GameOverUı;
    public GameObject TheEndUı;
    // ------------------baslagıcta uı ekranlarnı kapat---------
    private void Start()
    {
        GameOverUı.SetActive(false);
        TheEndUı.SetActive(false);
    }
    // ---------------------start butonuna tıklayınca oyuncuyu harekete gecir---------
    public void StartButton()
    {
        PlayerAnimator.SetBool("Run", true);
        PlayerSpeed = 7;
        StartButon.SetActive(false);
    }
    //---------Restart butonuna basınca oyunu baslat sahneyi yeniden yükle------------ 
     public void RestartButon()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }


    //----------- finish game calısınca 1 saniye sonra oyunu durdur the end  ekranını aç---------

    public void FinishGame()
    {
        Invoke("StopGame", 1f);
        TheEndUı.SetActive(true);

    }
    //------------oyunu durdur-----------------
    public void StopGame()
    {
        Time.timeScale = 0;
    }
    
   

    // --------------------oyuncuya oyuncu hız degiskeni ile sürekli ileri dogru hareket ver----------
    void Update()
    {
       
        Player.Translate(0, 0, PlayerSpeed*Time.deltaTime);
    }
}
