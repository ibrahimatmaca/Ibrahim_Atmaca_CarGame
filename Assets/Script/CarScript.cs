using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    private float carSpeed;
    private float parkFirstTime;

    public float parkingTime;

    private bool isClick = false;
    //private bool movement = true;
    
    private Rigidbody2D carRigi;

    private void Start()
    {
        parkFirstTime = parkingTime;

        carSpeed = LevelScript.instance.carSpeed;
        carRigi = GetComponent<Rigidbody2D>();
        GameControl.instance.timeText.text = "Süre: " + parkingTime.ToString() + " s";
    }

    private void Update()
    {
        if(GameControl.instance.carRestartPanel.activeSelf == false)
        {
            GameControl.instance.timeText.text = "Süre: " + parkingTime.ToString("f0") + " s";
            if (Input.GetMouseButtonDown(0)) //Arabaların başlangıçta kullanıcı ekrana tıklayana kadar beklemesi için
                isClick = true;
        }

        if (!GameControl.instance.gameOver && isClick)
        {
            ChangeCarRotation();
            //if(movement)
            carRigi.velocity = transform.up * carSpeed;

            parkingTime -= Time.deltaTime;
            GameControl.instance.timeText.text = "Süre: " + parkingTime.ToString("f0") + " s";
            if (parkingTime.ToString("f0") == "0")
            {
                GameControl.instance.gameOver = true;
                GameControl.instance.carRestartPanel.SetActive(true);
                isClick = false;
                parkingTime = parkFirstTime;
            }
        }
        else
            carRigi.velocity = transform.up * 0; // gameover durumunda  arabanın hareketinin engellemek amacıyla
    }

    //Arabanın sağ veya sola manevra kabiliyeti içim
    private void ChangeCarRotation()
    {
        if (GameControl.instance.isPressed)
        {
            if (GameControl.instance.isRight)
                transform.Rotate(new Vector3(0, 0, -1f));
            else 
                transform.Rotate(new Vector3(0, 0, 1f));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Car")) // Herhangi bir araba veya duvara çarparsa gameover
        {
            isClick = false;
            GameControl.instance.gameOver = true;
            GameControl.instance.carRestartPanel.SetActive(true);
        }

        if (other.CompareTag("TargetPoint")) // hedef noktasına gelinince sonraki hedef ve sonraki doğma noktaları tetikleniyor
        {
            LevelScript.instance.targetControlIndex += 1;

            if (LevelScript.instance.spawnPoints.Count > 1)
            {
                if(LevelScript.instance.spawnPoints.Count > LevelScript.instance.spawnControlIndex)
                    LevelScript.instance.spawnControlIndex += 1;
            }

            other.gameObject.SetActive(false); //hedef noktasının animasyonu kapatmak için
            carRigi.velocity = transform.up * 0; // aynı şekilde araba durdurmak için
            LevelScript.instance.CreateCar(); //spawn noktasında yeni araba oluşturma fonksiyon
            //movement = false;
            this.enabled = false; // her arabanın kendi script i çalışacağı için bu arabanın artık scriptinin çalışmasına gerek yoktur!
        }
    }

}
