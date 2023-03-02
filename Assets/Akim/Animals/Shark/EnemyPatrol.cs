using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

	public List<GameObject> patrolPoints;
	public float speed;
	public float viewRange;
	public float stopDistance;
	public float rotationSpeed;

	private int currentPoint;
	private GameObject player;
	public bool isHit = false;
	private bool isDamaging = false;
	private RaftController raftController;
	private void Start()
	{
		raftController= FindObjectOfType<RaftController>();
		currentPoint = 0;
		player = GameObject.FindGameObjectWithTag("Player");
	}

	private void Update()
	{
		// ѕровер€ем, находитс€ ли игрок в зоне видимости врага
		if (Vector3.Distance(transform.position, player.transform.position) < viewRange && !isHit)
		{
			// ≈сли да, то прит€гиваем врага к игроку
			Vector3 direction = player.transform.position - transform.position;
			direction.y = 0.3f;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

			if (direction.magnitude > stopDistance)
			{
				transform.Translate(0, 0, speed * Time.deltaTime);
			}
			if(Vector3.Distance(transform.position, player.transform.position) <= stopDistance + 0.1f && !isDamaging)
			{
				isDamaging = true;
				GiveDamage();
			}
		}
		else
		{
			// ≈сли нет, то патрулируем по указанным точкам
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

	private IEnumerator WaitAndPrint(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		isDamaging = false;
	}

	public void GiveDamage()
	{
		if (isDamaging)
		{
			raftController.Damage();
			StartCoroutine(WaitAndPrint(5));
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "veslo" || other.tag == "Interact Obj")
		{
			isHit = true;
		}
	}
}
