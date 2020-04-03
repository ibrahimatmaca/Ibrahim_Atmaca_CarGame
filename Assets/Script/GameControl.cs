using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;

    [HideInInspector] public int levelIndex = 0;
    public int totalNumberOfLevels;

    public bool gameOver = false;

    [HideInInspector] public bool isPressed = false;
    [HideInInspector] public bool isRight = false;
    [HideInInspector] public bool isLeft = false;

    [Header("UI Objects")]
    public GameObject startPanel;
    public GameObject nextLevelPanel;
    public GameObject carRestartPanel;
    public Text timeText;

    public List<GameObject> levels;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < totalNumberOfLevels; i++) // Level klasöründeki tüm level leri klasörden alıyoruz!
        {
            levels.Add(Resources.Load<GameObject>("Level/Level" + (i+1).ToString()));
        }
    }

    public void PressedControl(string _direction) // Sol ve sağ tıklama kontrolü
    {
        isPressed = true;
        if(_direction == "right")
            isRight = true;
        else
            isLeft = true;
    }

    public void PointerUp() // Event trigger da elimizi butonlardan çektiğimiz için dönme fonksiyon çalışmaması için
    {
        isPressed = false;
        isRight = false;
        isLeft = false;
    }

    public void RestartCar() // kaza veya süre sıfırlanınca en son ki arabayı tekrar spwan etme durumu
    {
        LevelScript.instance.LastCarSpawn();
        gameOver = false;
        carRestartPanel.SetActive(false);
    }
    public void NextLevel() 
    {
        startPanel.SetActive(true);
        nextLevelPanel.SetActive(false);
    }

    public void StartLevel()
    {
        Instantiate(levels[levelIndex]);
        startPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
