using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/MoveObject")]
public class MoveObject : ScriptableObject
{
    public string nameOfSong;
    public string genre;
    public int BPM;
    //we probably also need a damage/effect that the move itself can do and then a way to pick the correct song to play
}
