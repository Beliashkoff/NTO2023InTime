using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : SpawnerOfFish
{
    public GameObject fish;
    public float speed;
    public GameObject plot;
    void Update()
    {
        Vector3 direction = patrolPoints[currentPoint].transform.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

        if (direction.magnitude < 0.5f)
        {
            currentPoint++;
            if (currentPoint >= patrolPoints.Count)
            {
                currentPoint = 0;
            }
        }
}
