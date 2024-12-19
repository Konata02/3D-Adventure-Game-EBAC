using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Singleton;
using Cinemachine;

public class Shaker : Singleton<Shaker>
{
    public CinemachineVirtualCamera cinemachineVirtual;
    public float shakerTime = 0f;
    private CinemachineBasicMultiChannelPerlin c;

    [NaughtyAttributes.Button]
    public void Shake()
    {
        Shake(5, 5, 0.5f);
    }

    public void Shake(float amplitude, float frequency, float time)
    {
        c = cinemachineVirtual.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        
        if (c != null) // Verifica se 'c' não é nulo
        {
            c.m_AmplitudeGain = amplitude;
            c.m_FrequencyGain = frequency;
            shakerTime = time;
        }
        else
        {
            Debug.LogError("CinemachineBasicMultiChannelPerlin component not found!");
        }
    }

    void Update()
    {
        if (shakerTime > 0)
        {
            shakerTime -= Time.deltaTime;
        }
        else if (c != null) // Verifica se 'c' não é nulo
        {
            c.m_AmplitudeGain = 0f;
            c.m_FrequencyGain = 0f;
        }
    }
}
