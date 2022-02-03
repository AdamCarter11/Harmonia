using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Characters")]
public class CharacterSO : ScriptableObject
{
    public string character_name = "Character";
    public Sprite icon = null;
    public Sprite normal_sprite;
    public Sprite hit_sprite;

    public bool isUsable;

    public float heatlth;

    public ScriptableObject Song1;
    public ScriptableObject Song2;
    public ScriptableObject Song3;
    public ScriptableObject Song4;

    public string description;
}
