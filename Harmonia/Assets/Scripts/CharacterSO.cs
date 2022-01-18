using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Characters")]
public class CharacterSO : ScriptableObject
{
    public string character_name = "Character";
    public Sprite icon = null;

    public bool isUsable;

    public float heatlth;

    public GameObject Song1;
    public GameObject Song2;
    public GameObject Song3;
    public GameObject Song4;

}
