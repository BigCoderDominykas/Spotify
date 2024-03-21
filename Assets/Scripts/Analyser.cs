using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Analyser : MonoBehaviour
{
    AudioSource source;

    public static UnityEvent<float> onVolumeChanged = new();

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float[] samples = new float[735];
        source.clip.GetData(samples, source.timeSamples);

        float avg = 0;
        foreach (var sample in samples)
        {
            avg += Mathf.Abs(sample);
        }

        avg /= samples.Length;

        onVolumeChanged.Invoke(avg);
    }
}
