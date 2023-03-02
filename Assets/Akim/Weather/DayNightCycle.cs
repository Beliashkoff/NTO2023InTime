using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sun;
    public float secondsInFullDay = 120f; // ������� ����� ������� ���� � �������� 
    [Range(0, 1)]
    public float currentTimeOfDay = 0; // ��������� �����
    float sunInitialIntensity;
        
    void Start()
    {
        sunInitialIntensity = sun.intensity; // ���������� ������������� � ����������
    }

    void FixedUpdate()
    {
        UpdateSun(); // ��� FixedUpdate ����� ���������� UpdateSun

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay); // � ������� ����� ����� � ���� ���������� �����

        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0; 
        }
    }

    
    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);  // �������� ��������� ������

        float intensitys = 1;
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f) // ��������� �������
        {
            intensitys = 0;
        }
        else if (currentTimeOfDay <= 0.25f)
        {
            intensitys = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if (currentTimeOfDay >= 0.73f)
        {
            intensitys = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }

        sun.intensity = sunInitialIntensity * intensitys; // �������� �������
    }
}
