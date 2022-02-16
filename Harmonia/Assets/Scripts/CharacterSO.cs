using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Characters")]
public class CharacterSO : ScriptableObject
{
    public string character_name = "Character";
    public Sprite icon = null;
    public Sprite normal_sprite;
    public Sprite hit_sprite;

    public bool isUsable;

    public float health;

    public Song Song1;
    public Song Song2;
    public Song Song3;
    public Song Song4;

    public string description;

    public float getHealth()
    {
        return health;
    }

    public Song getSong1()
    {
        return Song1;
    }
    public Song getSong2()
    {
        return Song2;
    }
    public Song getSong3()
    {
        return Song3;
    }
    public Song getSong4()
    {
        return Song4;
    }
}
