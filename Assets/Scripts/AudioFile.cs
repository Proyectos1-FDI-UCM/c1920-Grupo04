using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//Para verlo en el editor
[System.Serializable] 
public class AudioFile
{
    //Parametros Públicos:
    public string audioName;
    public AudioClip audioClip;

    [Range(0f, 1f)]
    public float volume;

    [HideInInspector] // este no se verá en el inspector
    public AudioSource source;

    public bool isLooping;
    public bool playOnAwake;
}
