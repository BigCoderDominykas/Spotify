using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDancer : MonoBehaviour
{
    public GameObject prefab;
    [Range(1, 50)] public int count = 10;
    [Range(1f, 15f)] public float radius = 5;
    [Range(0f, 1f)] public float minScale = 0.2f;
    [Range(-100, 100)] public float rotateSpeed = 10;
    [Range(0f, 10f)] public float sensitivity = 1;
    [Range(0f, 5f)] public float boost = 1;

    private void Start()
    {
        for (int i = 0; i < count; i++)
        {
            var angle = (float)i / count * Mathf.PI * 2f;
            var pos = new Vector3();
            pos.x = Mathf.Cos(angle);
            pos.y = Mathf.Sin(angle);
            pos *= radius;

            var obj = Instantiate(prefab, pos, Quaternion.identity, transform);
            obj.transform.LookAt(transform.position);
        }

        Analyser.onVolumeChanged.AddListener(Dance);
    }

    void Dance(float volume)
    {
        transform.Rotate(0, 0, Mathf.Pow(volume * boost, sensitivity) * rotateSpeed);
        transform.localScale = Vector3.one * (volume + minScale);
    }
}
