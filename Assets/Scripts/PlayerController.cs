using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Player condition")]
    public float health; //0-100
	public float stamina; //0-100
    public float staminaChanger =  -0.6f; //�� ������� �������� ������������ � �������
    private float oldStaminaChanger;
	public float healthChanger =  0f; //�� ������� �������� �������� � �������
	private float oldHealthChanger = 0;

	[Header("Menu variables")]
    public Image healtBar;
	public Image staminaBar;

    private float staminaChangeTime = 0;
    private float healthChangeTime = 0;
	void Start()
    {
        oldStaminaChanger = staminaChanger;
        oldHealthChanger = healthChanger;
    }

    void Update()
    {

		if (stamina > 100)
            stamina= 100;
		else if (stamina < 0)
			stamina = 0;

		if (stamina >= 100)
        {
            healthChanger = 2;
        }
        else if (stamina < 10)
        {
			healthChanger = -10f;
		}
        else
        {
            healthChanger = 0;
        }
        if (health <= 0)
        {
            Debug.Log("Game Over");
        }


		if (staminaChanger != oldStaminaChanger)
		{
			staminaChangeTime = Time.time;
			oldStaminaChanger = staminaChanger;
		}
		if (healthChanger != oldHealthChanger)
		{
			healthChangeTime = Time.time;
			oldHealthChanger = healthChanger;   
		}
		//���������� ���������� ������
		stamina = 100 + staminaChanger * (Time.time - staminaChangeTime);
		health = 100 +  healthChanger * (Time.time - healthChangeTime);
        healtBar.fillAmount = health * 0.01f;
        staminaBar.fillAmount = stamina * 0.01f;
        
    }
    public IEnumerator StaminaRecovery()
    {
        staminaChanger = 5;
        yield return new WaitForSeconds(6);
		staminaChanger = -0.6f;
	}
}
