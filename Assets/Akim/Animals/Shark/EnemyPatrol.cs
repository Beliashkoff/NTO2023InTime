
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // Список объектов, в которых будет происходить патрулирование
    public List<GameObject> patrolPoints;
    // Индекс текущей точки патрулирования
    private int currentPointIndex;
    // Скорость патрулирования
    public float speed;

    void Start()
    {
        // Начинаем патрулирование с первой точки
        currentPointIndex = 0;
    }

    void Update()
    {
        // Если достигнута текущая точка патрулирования, переходим к следующей
        if (Vector3.Distance(transform.position, patrolPoints[currentPointIndex].transform.position) < 0.1f)
        {
            currentPointIndex++;
            currentPointIndex %= patrolPoints.Count;
        }

        // Направляем объект к точке назначения
        Vector3 direction = patrolPoints[currentPointIndex].transform.position - transform.position;
        transform.forward = Vector3.RotateTowards(transform.forward, direction, speed * Time.deltaTime, 0.0f);

        // Двигаем объект по направлению
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPointIndex].transform.position, speed * Time.deltaTime);
    }
}
