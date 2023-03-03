using System.Threading;
using UnityEngine;

public class DisplacementChange : MonoBehaviour
{
    public float time = 240f;
    private float timer;

    private Renderer rend;
    private float displacement;
    private RaftController raftController;

    void Start()
    {
        raftController = FindObjectOfType<RaftController>();
        float timert = timer;
        rend = GetComponent<Renderer>();
        timer = time;
    }

    void Update()
    {
        time = time - Time.deltaTime;
        if (time > time * 0.7f)
        {
            displacement = 0.3f;
            rend.material.SetFloat("_Displacement", displacement);
            // ��� ������� ������ ������ �������� 1
        }
        else if (time > time * 0.4)
        {
            displacement = 0.4f;
            rend.material.SetFloat("_Displacement", displacement);
            // ��� ������� ������ ����.
        }
        else if (time > 0)
        {
            displacement = 0.6f;
            rend.material.SetFloat("_Displacement", displacement);
            // ������ ��������, ��� ��� ����� ������� ������
        }
        if (time <= 0)
        {
            time = timer;
        }
    }
}
