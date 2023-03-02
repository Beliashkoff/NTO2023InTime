using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerOfFish : MonoBehaviour
{
    public List<GameObject> fishPrefabs;
    public GameObject Plot;

    private void Update() // ��������, �������. ��� ������ �������, ����� �������!!!!
    {
        FishSpawn();
    }   

    void FishSpawn()
    {
        float plotz = Plot.transform.position.z; // ������ �������� ����� �� ��� z
        
        if (GameObject.FindGameObjectsWithTag("Fish").Count() < 2) // ��������� ������� ��� ��������� �� �����
        {
            int randomIndex = Random.Range(0, fishPrefabs.Count); // ����� ��������� ����
            GameObject randomFish = Instantiate(fishPrefabs[randomIndex], new Vector3(2, 0, plotz), Quaternion.identity); // ������� ��������� ����, ������ �� �����
        }

    }

}
