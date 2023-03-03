using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGeneration : MonoBehaviour
{

    // ���������� ����������, ������� ����� �������� terrain

    public int width = 256;
    public int height = 256;
    public int depth = 20;
    public float scale = 20f;

    float offsetX = 100f;
    float offsetY = 100f;

    private void Start() // �������� ��������� ���������
    {
        offsetX = Random.Range(0f, 9999f); 
        offsetY = Random.Range(0f, 9999f);
    }

    void Update() // ��������� terrain
    {
        Terrain terrain = GetComponent<Terrain>(); // ���������� �������� � ���������� terrain
        terrain.terrainData = GenerateTerrain(terrain.terrainData); // ��� ��������� terrain ���������� ��������� �������, ������� ��������� �����
    }
        
    TerrainData GenerateTerrain(TerrainData terrainData) 
    {
        terrainData.heightmapResolution = width + 1; // �������� ������� �����

        terrainData.size = new Vector3(width, depth, height); // ��������� �������� terrain
        terrainData.SetHeights(0, 0, GenerationHeights()); // ��� ������� ����� ����� ������������ ������� GenerationHeights
        
        return terrainData;
    }

    float[,] GenerationHeights()
    {
        float[,] heights = new float[width, height]; // ������ ��� ���������� ������ � ������
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = HeightCalc(x, y); // �������� ������������ �������� � ����������� ��� ���������� ��������� ����� ���� �������
            }
        }

        return heights;
    }

    float HeightCalc(int x, int y)
    { 
        float xCoord = (float)x / width * scale + offsetX; // �������� ���������� 
        float yCoord = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }

}
