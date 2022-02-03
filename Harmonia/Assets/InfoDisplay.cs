using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
    public GameObject InfoDisplayUi;
    public GameObject CharactersParent;
    public Image DisplayImage;
    public Inventory invent;
    public Text name_text;
    public Text description;

    public void enableUI(int arrayVal)
    {
        InfoDisplayUi.SetActive(true);
        CharactersParent.SetActive(false);
        setUI(invent.characters[arrayVal]);
    }

    public void disableUI()
    {
        InfoDisplayUi.SetActive(false);
        CharactersParent.SetActive(true);
    }

    public void setUI(CharacterSO chara)
    {
        DisplayImage.overrideSprite = chara.icon;
        name_text.text = chara.name;
        description.text = chara.description;
    }
}
