using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private void Awake()
    {
        instance = this;
    }

    public List<CharacterSO> characters = new List<CharacterSO>();
    public void Add (CharacterSO character)
    {
        characters.Add(character);
    }

    public void Remove (CharacterSO character)
    {
        characters.Remove(character);
    }
}
