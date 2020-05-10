using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioFile[] audioFiles;
    public AudioMixerGroup audioMaster;

    private void Awake()
    {
        //Un único AudioManager:
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        //Prepara todos los audios (previamente configurados desde el editor):
        foreach (var s in audioFiles)
        {
            //Para cada audio crea su propio AudioSource
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.outputAudioMixerGroup = audioMaster; //AudioMixer configurado por Slider
            s.source.clip = s.audioClip;
            s.source.volume = s.volume;
            s.source.loop = s.isLooping;
            if (s.playOnAwake)
            {
                s.source.Play();
            }
        }
    }

    private void Start()
    {
        GameManager.instance.SetAudioManager(this);
    }

    //Para reproducir sonidos sueltos.
    public void PlaySound(string name, string action)
    {
        int i = 0;
        //Busca el audio en el array:
        while(i < audioFiles.Length && audioFiles[i].audioName != name)
        {
            i++;
        }
        //Si puede lo reproduce
        try
        {
            switch (action)
            {
                case "play":
                    audioFiles[i].source.Play();
                    break;
                case "stop":
                    audioFiles[i].source.Stop();
                    break;
                case "pause":
                    audioFiles[i].source.Pause();
                    break;
                case "unPause":
                    audioFiles[i].source.UnPause();
                    break;
            }            
        }
        //Sino, informa del error
        catch
        {
            Debug.LogWarning("El audio a reproducir " + name + "." +
                "\nNo se encuentra disponible / No se puede reproducir." +
                "\nRevise su configuración.");
        }
    }
}
