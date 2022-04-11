using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerController : MonoBehaviour
{
    [SerializeField] private AudioReverbZone _reverbZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            (_reverbZone as AudioReverbZone).enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            (_reverbZone as AudioReverbZone).enabled = false;
    }
}