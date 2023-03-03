using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Player condition")]
    public float health; //0-100
	public float stamina; //0-100
    public float staminaChanger =  -0.6f; //на сколько меняется выносливость в секунду
    private float oldStaminaChanger;
	public float healthChanger =  0f; //на сколько меняется здоровье в секунду
	private float oldHealthChanger = 0;

	[Header("Menu variables")]
    public Image healtBar;
	public Image staminaBar;

    private float staminaChangeTime = 0;
    private float healthChangeTime = 0;
    public Volume volume;
    public GameObject gameOver;
    private Vignette vignette;
	void Start()
    {
        oldStaminaChanger = staminaChanger;
        oldHealthChanger = healthChanger;
    }

    void Update()
    {
        if (healtBar == null)
        {
            healtBar = GameObject.FindGameObjectWithTag("health bar").GetComponent<Image>();
            staminaBar = GameObject.FindGameObjectWithTag("stamina bar").GetComponent<Image>();
        }
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
            GameOver();
        }
        VignetteUpdate();


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
		//обновление параметров игрока
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
    private void VignetteUpdate()
    {
        if (volume.profile.TryGet(out vignette))
        {
            vignette.intensity.value = Mathf.Clamp(1 - stamina / 100 +0.2f, 0.2f, 0.6f);
        }
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
        StartCoroutine(loadTimer());
	}
    IEnumerator loadTimer()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
