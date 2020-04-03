using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public static LevelScript instance;

    public float carSpeed;

    [HideInInspector] public int targetControlIndex = 0;
    [HideInInspector] public int spawnControlIndex = 0;

    public List<GameObject> spawnPoints = new List<GameObject>();
    public List<GameObject> targetPoints = new List<GameObject>();

    private GameObject spawnCar;
    private GameObject createSpawn;
    private List<GameObject> carList = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for(int i = 1; i < targetPoints.Count; i++) // tüm hedef noktalarını kapatıyoruz!
            targetPoints[i].SetActive(false);

        spawnCar = Resources.Load<GameObject>("Prefab/Car"); // Resource klasörden direkt olarak prefab'ı çektik
        CreateCar();
    }
    // Oluşacak arabanın spawn noktasını ve hedefini aktif hale getirerek bir araba oluşturuyor!
    public void CreateCar()
    {
        if(carList.Count < targetPoints.Count) //araba sayısı hedeften küçükse yeni hedefi aktif et ve araba oluştur!
        {
            createSpawn = Instantiate(spawnCar, spawnPoints[spawnControlIndex].transform.position, Quaternion.identity, spawnPoints[spawnControlIndex].transform);
            carList.Add(createSpawn);
            targetPoints[targetControlIndex].SetActive(true);
        }
        else // eğer araba sayısı hedef sayısına eşise bir sonraki level ' e geçiliyor
        {
            GameControl.instance.levelIndex += 1;
            GameControl.instance.nextLevelPanel.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    public void LastCarSpawn()
    { //Herhangi bir gameover yanma durumunda en son arabayı rotasyon sıfırlayıp spwan noktasına geri taşıyor!
        createSpawn.transform.rotation = Quaternion.Euler(0,0,0);
        createSpawn.transform.position = spawnPoints[spawnControlIndex].transform.position;
    }

}
