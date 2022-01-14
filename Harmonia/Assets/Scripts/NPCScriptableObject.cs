using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/NPCObject")]
public class NPCScriptableObject : ScriptableObject
{
    public string NPCName;
    [TextArea(15,20)]
    public string[] dialogue;
}
