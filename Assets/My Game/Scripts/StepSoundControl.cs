using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSoundControl : MonoBehaviour
{
    private AudioSource _source;

    [SerializeField] private AudioClip[] _footsteps;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void Step()
    {
        var stepSound = _footsteps[Random.Range(0, _footsteps.Length)];

        _source.PlayOneShot(stepSound);
    }
}
