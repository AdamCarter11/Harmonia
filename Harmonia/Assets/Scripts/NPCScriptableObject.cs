using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/NPCObject")]
public class NPCScriptableObject : ScriptableObject
{
    public string NPCName;
    [TextArea(15,20)]
    public string[] dialogue;
    public string[] player_win_dialogue;
    public string[] player_lose_dialogue;
    public CharacterSO chara_so;

    public CharacterSO getCharaSO()
    {
        return chara_so;
    }
}
