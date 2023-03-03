using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

	public List<GameObject> patrolPoints;
	public float speed;
	public float rotationSpeed;

	private int currentPoint;
	public bool isHit = false;
	private Rigidbody rb;
	private Animator animator;
	private void Start()
	{
		animator = GetComponentInChildren<Animator>();
		rb = GetComponent<Rigidbody>();
		currentPoint = 0;
	}

	private void Update()
	{
		if (!isHit)
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
			else
			{
				transform.Translate(0, 0, speed * Time.deltaTime);
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "veslo" || other.tag == "Interact Obj")
		{
			isHit = true;
			animator.Play("Idle");
			rb.useGravity = true;
		}
	}
}
