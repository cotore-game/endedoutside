using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameSystem : MonoBehaviour
{
    [SerializeField] private GameObject Volume;
    private Volume vol;

    [SerializeField] private float cnt = 0.15f;

    private void Start()
    {
        vol = Volume.GetComponent<Volume>();
    }

    private void Update()
    {
        vol.weight = (1 - cnt) + cnt * Mathf.Sin(Time.realtimeSinceStartup);
    }
}
