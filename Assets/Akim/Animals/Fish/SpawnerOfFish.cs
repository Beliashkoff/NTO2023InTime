using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerOfFish : MonoBehaviour
{
    [SerializeField]
    List<GameObject> FishPrefabs;
    [SerializeField]
    GameObject Plot;
    [SerializeField]
    List<GameObject> Waypoints;

    private void Update() // ��������, �������. ��� ������ �������, ����� �������!!!!
    {
        FishSpawn();
    }   
        
    void FishSpawn()
    {
        float plotz = Plot.transform.position.z; // ������ �������� ����� �� ��� z
        
        if (GameObject.FindGameObjectsWithTag("Fish").Count() < 2) // ��������� ������� ��� ��������� �� �����
        {
            int randomIndex = Random.Range(0, FishPrefabs.Count); // ����� ��������� ����
            GameObject randomFish = Instantiate(FishPrefabs[randomIndex], new Vector3(2, 0, plotz), Quaternion.identity); // ������� ��������� ����, ������ �� �����
            randomFish.transform.parent = Plot.transform;
            randomFish.GetComponent<PatrolFish>().waypoints = Waypoints; 
        }
            
    }

}
