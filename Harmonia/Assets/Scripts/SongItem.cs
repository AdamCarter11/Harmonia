using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongItem : MonoBehaviour
{
    public Song song;

    public void Set(Song incoming_song)
    {
        song = incoming_song;
    }

    public float getBPM()
    {
        return song.BPM;
    }

    public float getHighBPM()
    {
        return song.HIGH_BPM;
    }

    public float getLowBPM()
    {
        return song.LOW_BPM;
    }

    public string getName()
    {
        return song.song_name;
    }

    public string getGenre()
    {
        return song.genre;
    }

    public AudioClip getAudio()
    {
        return song.audio;
    }

    public TextAsset getText()
    {
        return song.notes;
    }

    public TextAsset getText2()
    {
        return song.sequence;
    }

    public float getBuffer()
    {
        return song.buffer;
    }

    public float getDamage()
    {
        return song.baseDamage;
    }

    public float getAmountOfNotes()
    {
        string[] notes = song.notes.text.Split('\n');
        return notes.Length;
    }
}