using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.Experimental;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

public class SoundManager : MonoBehaviour
{
    public enum Sound
    {
        OroVoice,
        KyleVoice,
        BackgroundHospital,
        BackgroundStreet,
        FootSteps,
        Desinfection,
        OpenWindow,
        OpenDoor
    }
    

    private static GameObject oneShotGameObject;
    private static AudioSource oneShotAudioSource;

    private static Dictionary<Sound, float> soundTimerDictionary;

    public SoundAudioClip[] soundAudioClipArray;

    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;

    }

    // Get AudioClip from Manager
    private AudioClip GetAudioClip(Sound sound)
    {
        foreach (SoundAudioClip soundAudioClip in soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound" + sound + "not found!!!");
        return null;
    }
    
    // Play 2D Sound
    public void PlaySound(Sound sound) {
        if (CanPlaySound(sound))
        {
            if (oneShotGameObject == null)
            {
                oneShotGameObject = new GameObject("One Shot Sound");
                oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
            }
            oneShotAudioSource.PlayOneShot(GetAudioClip(sound));  
        }

    }
    
    // Play 3D sound based on object position
    public void PlaySound(Sound sound, Vector3 position) {
        if (CanPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            soundGameObject.transform.position = position;
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = GetAudioClip(sound);
            audioSource.Play();
            
            Object.Destroy(soundGameObject, audioSource.clip.length);
        }

    }
    
    // If sound is called at runtime check if sound already plays
    private static bool CanPlaySound(Sound sound)
    {
        switch(sound)
        {
            default:
                return true;
            case Sound.FootSteps:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float movemtTimeMax = 0.05f;
                    if (lastTimePlayed + movemtTimeMax < Time.time)
                    {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
        }
    }
    
    // play Voice Recording
    public void PlayVoice(String name, String clipNum,  Vector3 position)
    {
        String filename = clipNum + "_" + name + ".mp3";
        GameObject soundGameObject = new GameObject("Sound");
        soundGameObject.transform.position = position;
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot((AudioClip)Resources.Load(filename));
        
        Object.Destroy(soundGameObject, audioSource.clip.length);

    }
}
