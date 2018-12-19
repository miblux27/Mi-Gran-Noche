using Cinemachine;
using UnityEngine;

public class CameraShakeCM : MonoBehaviour
{

    
    [SerializeField] private CinemachineVirtualCamera vcam;

    private static float timeDuration = 0f;
    private static CinemachineBasicMultiChannelPerlin noise;
    private const byte zero = 0;

    void Start()
    {
        noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
        if (timeDuration > zero)
        {
            timeDuration -= Time.fixedDeltaTime;
        }
        else if (noise.m_AmplitudeGain != zero)
        {
            noise.m_AmplitudeGain = zero;
            noise.m_FrequencyGain = zero;
        }
    }

    public static void Temblor(float amplitudeGain, float frequencyGain, float duration)
    {
        noise.m_AmplitudeGain = amplitudeGain;
        noise.m_FrequencyGain = frequencyGain;
        timeDuration = duration;
    }
}
