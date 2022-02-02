using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    CharacterSO character;

    public void AddCharacter (CharacterSO newCharacter)
    {
        character = newCharacter;

        icon.sprite = character.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        character = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
