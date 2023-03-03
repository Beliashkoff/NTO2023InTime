using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGeneration : MonoBehaviour
{

    // обьявление переменных, которые будут изменять terrain

    public int width = 256;
    public int height = 256;
    public int depth = 20;
    public float scale = 20f;

    float offsetX = 100f;
    float offsetY = 100f;

    private void Start() // создание рандомной генерации
    {
        offsetX = Random.Range(0f, 9999f); 
        offsetY = Random.Range(0f, 9999f);
    }

    void Update() // изменение terrain
    {
        Terrain terrain = GetComponent<Terrain>(); // записываем свойства в переменную terrain
        terrain.terrainData = GenerateTerrain(terrain.terrainData); // для изменения terrain используем отдельную функцию, которая обьявлена позже
    }
        
    TerrainData GenerateTerrain(TerrainData terrainData) 
    {
        terrainData.heightmapResolution = width + 1; // поднятие высоких точек

        terrainData.size = new Vector3(width, depth, height); // изменение размеров terrain
        terrainData.SetHeights(0, 0, GenerationHeights()); // для задания высто будем использовать функцию GenerationHeights
        
        return terrainData;
    }

    float[,] GenerationHeights()
    {
        float[,] heights = new float[width, height]; // массив для сохранения ширины и высоты
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = HeightCalc(x, y); // передаем максимальные значения в калькулятор для вычесления изменения путем шума перлина
            }
        }

        return heights;
    }

    float HeightCalc(int x, int y)
    { 
        float xCoord = (float)x / width * scale + offsetX; // изменяем координаты 
        float yCoord = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }

}
