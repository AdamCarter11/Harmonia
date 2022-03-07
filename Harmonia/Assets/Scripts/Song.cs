using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Songs")]
public class Song : ScriptableObject
{
    public string song_name = "Song Name";
    public float BPM;
    public float HIGH_BPM;
    public float LOW_BPM;
    public string genre = "Genre";
    public AudioClip audio;
    public TextAsset notes;
    public TextAsset sequence;
    public string info;
    public float buffer;
    public float baseDamage;
    public float notes_length;

    public AudioClip getAudio()
    {
        return audio;
    }

    public float getDamage()
    {
        return baseDamage;
    }

    public TextAsset getText()
    {
        return notes;
    }

    public TextAsset getText2()
    {
        return sequence;
    }

    public float getBPM()
    {
        return BPM;
    }

    public float getBuffer()
    {
        return buffer;
    }

    public void set_length(float amt)
    {
        notes_length = amt;
    }

    public float get_length()
    {
        return notes_length;
    }
}
