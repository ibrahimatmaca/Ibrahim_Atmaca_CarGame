using System.Collections;
using UnityEngine;
using UnityEditor;

public class LevelDesignEditor : Editor
{
    

    [MenuItem("Level Tasarım Araçları/Level Oluştur %g", false, 10)]
    static void CreateLevel()
    {
        // Yeni bir duvar oluştur 0 Vector3.zero da
        GameObject newObject = Instantiate(Resources.Load<GameObject>("Prefab/Level"), Vector3.zero, Quaternion.identity);

    }

    // Kısayol: Control + G
    
    [MenuItem("Level Tasarım Araçları/Kısa Duvar ", false, 10)]
    static void KisaDuvarYap()
    {
        // Yeni bir duvar oluştur 0 Vector3.zero da
        GameObject newObject = Instantiate(Resources.Load<GameObject>("Prefab/Wall"), Vector3.zero, Quaternion.identity);

        GameObject level = GameObject.FindGameObjectWithTag("Level");
        GameObjectUtility.SetParentAndAlign(newObject, level);
        newObject.transform.localScale = new Vector3(1f, 1f, 1f);
        Selection.activeObject = newObject;
    }
    [MenuItem("Level Tasarım Araçları/Orta Duvar ", false, 10)]
    static void OrtaDuvarYap()
    {
        // Yeni bir duvar oluştur 0 Vector3.zero da
        GameObject newObject = Instantiate(Resources.Load<GameObject>("Prefab/Wall"), Vector3.zero, Quaternion.identity);

        GameObject level = GameObject.FindGameObjectWithTag("Level");
        GameObjectUtility.SetParentAndAlign(newObject, level);
        newObject.transform.localScale = new Vector3(1f, 1.5f, 1f);
        Selection.activeObject = newObject;
    }
    [MenuItem("Level Tasarım Araçları/Uzun Duvar ", false, 10)]
    static void UzunDuvarYap()
    {
        // Yeni bir duvar oluştur 0 Vector3.zero da
        GameObject newObject = Instantiate(Resources.Load<GameObject>("Prefab/Wall"), Vector3.zero, Quaternion.identity);

        GameObject level = GameObject.FindGameObjectWithTag("Level");
        GameObjectUtility.SetParentAndAlign(newObject, level);
        newObject.transform.localScale = new Vector3(1f, 2f, 1f);
        Selection.activeObject = newObject;
    }

    [MenuItem("Level Tasarım Araçları/Araba Spawn Noktası Oluştur",false,10)]
    static void SpawnPoint()
    {
        GameObject newObject = Instantiate(Resources.Load<GameObject>("Prefab/SpawnPoint"), Vector3.zero, Quaternion.identity);

        GameObject level = GameObject.FindGameObjectWithTag("Level");
        GameObjectUtility.SetParentAndAlign(newObject, level);
        Selection.activeObject = newObject;
    }

    [MenuItem("Level Tasarım Araçları/Hedef Noktası Oluştur",false,10)]
    static void TargetPoint()
    {
        GameObject newObject = Instantiate(Resources.Load<GameObject>("Prefab/TargetPoint"), Vector3.zero, Quaternion.identity);

        GameObject level = GameObject.FindGameObjectWithTag("Level");
        GameObjectUtility.SetParentAndAlign(newObject, level);
        Selection.activeObject = newObject;
    }
}
