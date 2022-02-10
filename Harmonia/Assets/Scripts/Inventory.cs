using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnCharacterAdded();
    public OnCharacterAdded onCharacterChangedCallback;

    public static Inventory instance;
    public int space = 12;

    public GameObject InventoryUI;
    private bool inventoryActive = false;
    public GameObject InfoDisplay;

    public InfoDisplay info;

    public AudioSource sfx_s;
    public AudioClip openBag;
    public AudioClip closeBag;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryActive = !inventoryActive;
            info.disableUI();
            InventoryUI.SetActive(inventoryActive);
            InfoDisplay.SetActive(false);

            if (inventoryActive == true)
            {
                sfx_s.Stop();
                sfx_s.clip = openBag;
                sfx_s.Play();
            }
            else if (inventoryActive == false)
            {
                sfx_s.Stop();
                sfx_s.clip = closeBag;
                sfx_s.Play();
            }
        }
    }

    public List<CharacterSO> characters;
    public bool Add(CharacterSO character)
    {
        if (characters.Count >= space)
        {
            return false;
        }
        characters.Add(character);
        if (onCharacterChangedCallback != null)
        {
            onCharacterChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove(CharacterSO character)
    {
        characters.Remove(character);
    }

    public bool getActive()
    {
        return inventoryActive;
    }

    public void exitInventory()
    {
        inventoryActive = !inventoryActive;
        info.disableUI();
        InventoryUI.SetActive(inventoryActive);
        InfoDisplay.SetActive(false);
    }
}
