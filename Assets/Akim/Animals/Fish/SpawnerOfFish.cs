using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerOfFish : MonoBehaviour
{
    public List<GameObject> fishPrefabs;
    public GameObject Plot;

    private void Update() // временно, удалить. Для вызова функции, позже удалить!!!!
    {
        FishSpawn();
    }   

    void FishSpawn()
    {
        float plotz = Plot.transform.position.z; // узнаем значения плота по оси z
        
        if (GameObject.FindGameObjectsWithTag("Fish").Count() < 2) // проверяем сколько рыб находится на сцене
        {
            int randomIndex = Random.Range(0, fishPrefabs.Count); // берем рандомную рыбу
            GameObject randomFish = Instantiate(fishPrefabs[randomIndex], new Vector3(2, 0, plotz), Quaternion.identity); // спавним рандомную рыбу, справа от плота
        }

    }

}
