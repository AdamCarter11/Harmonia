using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    CharacterSO character;
    public Button thisButton;

    public void AddCharacter (CharacterSO newCharacter)
    {
        character = newCharacter;

        icon.sprite = character.icon;
        icon.enabled = true;
        thisButton.enabled = true;
    }

    public void ClearSlot()
    {
        character = null;

        icon.sprite = null;
        icon.enabled = false;
        thisButton.enabled = false;
    }
}
