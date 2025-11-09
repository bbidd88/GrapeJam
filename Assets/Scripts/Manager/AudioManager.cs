using System;
using UnityEngine;
using System.Collections.Generic;

public class AudioManager : YManager, YIManagerUpdate
{
    public override void OnAwake()
    {

    }

    public override void OnStart()
    {
       
    }
    public void OnUpdate()
    {

    }

    public void PlaySound(AudioClip InSound)
    {
        var audioSource = GameObject.Find("@Audio")?.GetComponent<AudioSource>();
        if (!audioSource)
            return;

        audioSource.Stop();
        audioSource.PlayOneShot(InSound);
    }
}
