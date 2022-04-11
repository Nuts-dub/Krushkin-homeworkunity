using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    public AudioMixer _masterAudio;

    public void SetGeneralLvl(float genLvl)
    {
        _masterAudio.SetFloat ("generalVol", genLvl);
    }

    public void SetFxLvl(float fxLvl)
    {
        _masterAudio.SetFloat ("fxVol", fxLvl);
    }

    public void SetMusicLvl(float musicLvl)
    {
        _masterAudio.SetFloat ("musicVol", musicLvl);
    }
}
