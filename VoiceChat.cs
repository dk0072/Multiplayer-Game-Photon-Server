using Photon.Voice.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceChat : MonoBehaviour
{
    Recorder recorder;

    private void Start()
    {
        recorder = GetComponent<Recorder>();
        recorder.Init(new VoiceConnection());
        
    }
}
