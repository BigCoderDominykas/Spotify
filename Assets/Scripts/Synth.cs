using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synth : MonoBehaviour
{
    public float frequency;
    public int clipLengthSeconds;

    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();

        var clip = AudioClip.Create("Sin", 44100 * clipLengthSeconds, 1, 44100, false);
        var samples = new float[44100 * clipLengthSeconds];
        for (int i = 0; i < samples.Length; i++)
        {
            /*if (i % 44100 > 22500)
            {
                samples[i] = 0;
                continue;
            }*/

            //samples[i] = Mathf.Sin(i / 44100f * Mathf.PI * 2f * frequency) + Mathf.Sin(i / 44100f * Mathf.PI * 2f * 960);
            //samples[i] /= 2f;
            //samples[i] *= Mathf.Sin(i / 44100f * Mathf.PI * 2f * 0.25f);

            samples[i] = Mathf.Sin(i / 44100f * Mathf.PI * 2f * frequency * Mathf.Abs(Mathf.Sin(i / 44100f * Mathf.PI * 2f * 0.2f)));
        }

        clip.SetData(samples, 0);

        source.clip = clip;
        source.Play();
    }
}
