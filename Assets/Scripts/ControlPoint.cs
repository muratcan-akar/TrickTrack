using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoint : MonoBehaviour
{
    float xRot, yRot;
    public Rigidbody ball;
    public GameObject _Ball;
    public float RotateSpeed = 5;
    public float ShootPower=25f;
    public LineRenderer line;
    public GameManager Game_Maneger;
    
    public Transform ShotPoint;

    private void Update()
    {
        transform.position = ball.position;
        //--------- Mouse tıklayınca Line rendereRın görünmesi ve mouse hareketine göre atış açısının ayarlanması
        if (Input.GetMouseButton(0))
        {
            LineControler();
            xRot += Input.GetAxis("Mouse X") * RotateSpeed;
            yRot += Input.GetAxis("Mouse Y") * RotateSpeed;
            if (yRot < -35f)
            {
                yRot = -35f;
            }
            transform.rotation = Quaternion.Euler(yRot, xRot, 0f);
        }
        //------------Mousedan elielimizi cekince line rendererın görünmemesi ve topu olusturup fırlayması------- 
        if (Input.GetMouseButtonUp(0))
        {
            line.gameObject.SetActive(false);
           GameObject CreatedBall = Instantiate(_Ball, ShotPoint.position, ShotPoint.rotation);
           CreatedBall.GetComponent<Rigidbody>().velocity = transform.forward * ShootPower;

        
        }
    }
    //------------------------------Sürekli atesi aktif et----------------
    public void AfterFinishFire()
    {
        StartCoroutine(AfterFinishBallFire());
    }
    //------0.3 saniyeede bir top at ----------------
    IEnumerator AfterFinishBallFire()
    {
        
        yield return new WaitForSeconds(0.3f);
        
        GameObject CreatedBall = Instantiate(_Ball, ShotPoint.position, ShotPoint.rotation);
        CreatedBall.GetComponent<Rigidbody>().velocity = transform.forward * ShootPower;
        StartCoroutine(AfterFinishBallFire());
        Game_Maneger.PlayerSpeed++;

    }
        //----------------------------------- Line renderer Sekilinin ayarlanması----------------------------
        void LineControler()
    {
        line.gameObject.SetActive(true);
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position + transform.forward * 2.5f + transform.up * 1.1f);
        line.SetPosition(2, transform.position + transform.forward * 5f + transform.up * 1.4f);
        line.SetPosition(3, transform.position + transform.forward * 7.5f + transform.up * 1.6f);
        line.SetPosition(4, transform.position + transform.forward * 10f + transform.up * 1.4f);
        line.SetPosition(5, transform.position + transform.forward * 12.5f + transform.up * 1.05f);
        line.SetPosition(6, transform.position + transform.forward * 20f);
    }

}
