using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class RaftController : MonoBehaviour
{
    public int health = 3;
    public Animator animator;
    public GameObject[] rafts;
    public GameObject spawner;
	
    private bool isSailOpen  = false;
    public float speed = 1;
	public bool isStorm;
	private PlayerController playerController;
	private void FixedUpdate()
	{
		playerController = FindObjectOfType<PlayerController>();
		transform.Translate(transform.forward * Time.fixedDeltaTime * speed);
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.tag);
		if (other.tag == "Terrain")
		{
			playerController.GameOver();
		}
		if(other.tag == "veslo")
		{
			other.transform.parent = transform;
		}
		if (other.tag == "Interaction Obj")
		{
			other.transform.parent = transform;
		}
		if (other.tag == "Fish")
		{
			other.transform.parent = transform;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if(other.tag == "veslo" || other.tag == "Interaction Obj" || other.tag == "Player")
		{
			other.transform.parent = null;
		}
	}
	public void LowerSail()
	{
		if (isStorm)
		{
			Destroy(spawner.transform.GetChild(0).gameObject);
			Instantiate(rafts[1], spawner.transform.position, spawner.transform.rotation, spawner.transform);
			health = 1;
		}
		else
		{
			if (!isSailOpen)
			{
				isSailOpen = true;
				animator.Play("Sail lower");
				speed = 2f;
			}
			else
			{
				isSailOpen = false;
				animator.Play("Sail unlower");
				speed = 1;
			}
		}

    }
    public void Damage()
    {
		health -= 1;
		Debug.Log(health);
		if (health == 2)
		{
			Destroy(spawner.transform.GetChild(0).gameObject);
			Instantiate(rafts[0], spawner.transform.position, spawner.transform.rotation, spawner.transform);
		}
		else if (health == 1)
		{
			Destroy(spawner.transform.GetChild(0).gameObject);
			Instantiate(rafts[1], spawner.transform.position, spawner.transform.rotation, spawner.transform);
		}
		else
		{
			playerController.GameOver();
		}
	}
}
