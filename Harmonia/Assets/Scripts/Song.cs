using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Songs")]
public class Song : ScriptableObject
{
    public string song_name = "Song Name";
    public float BPM;
    public string genre = "Genre";
    public AudioClip audio;
    public TextAsset notes;
    public TextAsset sequence;
}
