using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Singleton;
public class AudioManager : Singleton<AudioManager>
{
    public List<MusicSetup> musicSetups;
    public List<SFX_Setup> sfxSetups;


    public void MusicPlayByType(MusicType musicType, AudioSource musicSource)
    {
        var music = GetMusicByType(musicType);
        musicSource.clip = music.audioClip;
        musicSource.Play();
    }

    public void SFXPlayByType(SFXType musicType, AudioSource musicSource)
    {
        var music = GetSfxByType(musicType);
        musicSource.clip = music.audioClip;

        musicSource.Play();
    }

    public MusicSetup GetMusicByType(MusicType musicType)
    {
        return musicSetups.Find(i => i.musicType == musicType);
    }

    public SFX_Setup GetSfxByType(SFXType typeSFX)
    {
        return sfxSetups.Find(i => i.sfxType == typeSFX);
    }




}

public enum MusicType
{
    TYPE_AMBIENCE
}

[System.Serializable]
public class MusicSetup
{
    public MusicType musicType;
    public AudioClip audioClip;

}

public enum SFXType
{
    TYPE_WALK,
    TYPE_SHOOTING,
    TYPE_COIN
}

[System.Serializable]
public class SFX_Setup
{
    public SFXType sfxType;
    public AudioClip audioClip;

}