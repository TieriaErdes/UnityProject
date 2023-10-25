using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public Sound[] Music, SoundEffects;
    //public AudioSource musicSource, soundEffectsSource;

    public static MusicManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(this.gameObject);

        foreach (Sound s in Music)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        /*//foreach (Sound effects in SoundEffects)
        //{
        //    soundEffectsSource.clip = effects.clip;
        //
        //    soundEffectsSource.volume = effects.volume;
        //    soundEffectsSource.pitch = effects.pitch;
        //    soundEffectsSource.loop = effects.loop;
        //}*/

    }

    public void PlayMusic(string name)
    {
        Sound music = Array.Find(Music, sound => sound.name == name);
        if (music == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        //foreach (Sound s in Music)
        //{
        //    s.source = gameObject.GetComponent<AudioSource>();

        //    if (s.source.name != name)
        //    {
        //        Debug.Log("Sound " + s.name + " stop playing");
        //        s.source.Stop();
        //    }
        //    else 
        //        s.source.Play();
        //}
        //music.source.Play();
        foreach (var item in Music)
        {
            item.source = gameObject.GetComponent<AudioSource>();
            if (item.isPlaying)
                item.source.clip = null;
        }

        music.source.clip = music.clip;

        music.source.volume = music.volume;
        music.source.pitch = music.pitch;
        music.source.loop = music.loop;

        music.isPlaying = true;
        music.source.Play();
    }

    //public void PlaySoundEffects(string name)
    //{
    //    Sound effects = Array.Find(SoundEffects, sound => sound.name == name);
    //    if (effects == null)
    //    {
    //        Debug.LogWarning("Sound: " + name + " not found!");
    //        return;
    //    }
    //    //soundEffectsSource.Play();
    //    soundEffectsSource.PlayScheduled(effects.clip.length);
    //}
}
