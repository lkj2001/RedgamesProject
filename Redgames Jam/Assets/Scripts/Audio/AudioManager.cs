using UnityEngine;
using UnityEngine.Audio;
using System;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds, sfx;
    public AudioSource audioSource, sfxSource;
    //public AudioMixer audioMixer;
    //public AudioSettings audioSettings;
    public static AudioManager instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        playMusic("BGM");
        //playMusic("inGameBGM");
    }
    public void playMusic(string name)
    {
        Sounds s = Array.Find(sounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Music not found");
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            audioSource.clip = s.clip;
            audioSource.Play();
        }
    }

    public void stopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void musicVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void playSFX(string name)
    {
        Sounds s = Array.Find(sfx, x => x.name == name);

        if (s == null)
        {
            Debug.Log("SFX not found");

        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void sfxVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    public void playLoopingSFX(string name)
    {
        Sounds s = Array.Find(sfx, x => x.name == name);

        if (s == null)
        {
            Debug.Log("SFX not found");

        }
        else
        {
            sfxSource.clip = s.clip;
            sfxSource.loop = true;
            sfxSource.Play();
        }
    }

    public void stopLoopingSFX(string name)
    {
        Sounds s = Array.Find(sfx, x => x.name == name);

        if (s == null)
        {
            Debug.Log("SFX not found");
        }
        else if (sfxSource.clip == s.clip && sfxSource.loop)
        {
            sfxSource.Stop();
            sfxSource.clip = null;
            sfxSource.loop = false;
        }
    }


    //public void Awake()
    //{
    //    if(instance == null)
    //        instance = this;
    //    else
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }

    //    DontDestroyOnLoad(this);

    //    foreach (Sound s in sounds) //this copy the componenet from the audio source component
    //    {
    //        s.source = gameObject.AddComponent<AudioSource>();
    //        s.source.clip = s.clip;
    //        s.source.volume = s.volume;
    //        s.source.loop = s.loop;
    //    }
    //}

    //public void Play(String name)
    //{
    //    Sound s = Array.Find(sounds, sound => sound.name == name);
    //    s.source.Play();
    //    audioSettings.setVolume();
    //}

    //public void stopPlaying(String name)
    //{
    //    Sound s = Array.Find(sounds, sound => sound.name == name);
    //    s.source.Stop();
    //    audioSettings.setVolume();
    //}
}
