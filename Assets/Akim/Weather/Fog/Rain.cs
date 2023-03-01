using UnityEngine;
public class Rain : MonoBehaviour
{
    [Tooltip("Light rain looping clip")]
    public AudioClip RainSoundLight;

    [Tooltip("Medium rain looping clip")]
    public AudioClip RainSoundMedium;

    [Tooltip("Heavy rain looping clip")] 
    public AudioClip RainSoundHeavy;
    public AudioSource audioSource;

    void playRain()
    {
        audioSource = GetComponent<AudioSource>(); 

        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        float RainForce = particleSystem.forceOverLifetime.y.constant; // ���� �������� �� ��������� forceOverLifetime


        if (RainForce >= -150)
        {
            audioSource.clip = RainSoundLight;                                    // ���������� �� ��������� � ������ �� ����� �������� ���� ����� 
            audioSource.Play();
        }
        else if (RainForce >= -450)
        {
            audioSource.clip = RainSoundMedium;
            audioSource.Play();
        }
        else if (RainForce >= -850)
        {
            audioSource.clip = RainSoundHeavy;
            audioSource.Play();
        }
    }

}

