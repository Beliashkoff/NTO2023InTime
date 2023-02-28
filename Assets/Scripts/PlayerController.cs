using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Player condition")]
    public float health; //0-100
	public float stamina; //0-100
    public float staminaChanger =  -0.3f; //на сколько меняется выносливость в секунду
    public float healthChanger =  -0.3f; //на сколько меняется здоровье в секунду

    [Header("Menu variables")]
    public Image healtBar;
	public Image staminaBar;
	void Start()
    {
        
    }

    void Update()
    {
        //обновление параметров игрока
        stamina = 100 + staminaChanger * Time.time;
        health = 100 +  healthChanger * Time.time;
        healtBar.fillAmount = health * 0.01f;
        staminaBar.fillAmount = stamina * 0.01f;
    }
}
