using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public float volumeThreshold;
    public GameObject leftParticles;
    public GameObject rightParticles;

    private void Start()
    {
        Analyser.onVolumeChanged.AddListener(Spawn);
    }

    public void Spawn(float volume)
    {
        if (volume >= volumeThreshold)
        {
            Instantiate(leftParticles);
            Instantiate(rightParticles);
        }
    }
}
