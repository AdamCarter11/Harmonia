using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/NPCObject")]
public class NPCScriptableObject : ScriptableObject
{
    public string NPCName;
    [TextArea(15,20)]
    public string[] dialogue;
    [TextArea(15,20)]
    public string[] player_win_dialogue;
    [TextArea(15,20)]
    public string[] player_lose_dialogue;
    [TextArea(15,20)]
    public string[] intro_dialogue;
    public CharacterSO chara_so;

    public CharacterSO getCharaSO()
    {
        return chara_so;
    }
}
