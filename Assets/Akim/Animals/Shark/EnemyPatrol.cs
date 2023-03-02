
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // ������ ��������, � ������� ����� ����������� ��������������
    public List<GameObject> patrolPoints;
    // ������ ������� ����� ��������������
    private int currentPointIndex;
    // �������� ��������������
    public float speed;

    void Start()
    {
        // �������� �������������� � ������ �����
        currentPointIndex = 0;
    }

    void Update()
    {
        // ���� ���������� ������� ����� ��������������, ��������� � ���������
        if (Vector3.Distance(transform.position, patrolPoints[currentPointIndex].transform.position) < 0.1f)
        {
            currentPointIndex++;
            currentPointIndex %= patrolPoints.Count;
        }

        // ���������� ������ � ����� ����������
        Vector3 direction = patrolPoints[currentPointIndex].transform.position - transform.position;
        transform.forward = Vector3.RotateTowards(transform.forward, direction, speed * Time.deltaTime, 0.0f);

        // ������� ������ �� �����������
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPointIndex].transform.position, speed * Time.deltaTime);
    }
}
