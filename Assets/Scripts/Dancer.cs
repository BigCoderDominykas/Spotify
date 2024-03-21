using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancer : MonoBehaviour
{
    public bool isBar, isReverseCube;
    public float barHeight = 9;

    private void Start()
    {
        Analyser.onVolumeChanged.AddListener(Dance);
    }

    public void Dance(float volume)
    {
        if (isBar)
        {
            //var scale = new Vector3(1, volume * 9, 1);
            transform.localScale = Vector3.Lerp(new Vector3(1, 1, 1), new Vector3(1, barHeight, 1), volume * 2);
        }
        else if (!isReverseCube)
        {
            transform.Rotate(0, 0, -0.1f + volume * 5);
            transform.position = Vector3.Lerp(new Vector3(0, 0.5f, 0), new Vector3(0, 1, 0), volume * 5);
        }
        else
        {
            transform.Rotate(0, 0, -0.1f + volume * 5);
            transform.position = Vector3.Lerp(new Vector3(0, -0.5f, 0), new Vector3(0, -1, 0), volume * 5);
        }
    }
}
