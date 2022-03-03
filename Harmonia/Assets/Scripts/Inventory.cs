using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int space = 12;
    private int amt_of_characters;

    public GameObject InventoryUI;
    private bool inventoryActive = false;
    public GameObject InfoDisplay;

    public InfoDisplay info;

    public AudioSource sfx_s;
    public AudioClip openBag;
    public AudioClip closeBag;

    public List<CharacterSO> characters;
    public Transform charactersParent;
    InventorySlot[] slots;

    private void Start()
    {
        slots = charactersParent.GetComponentsInChildren<InventorySlot>();
        characters = persistantManager.Instance.getCharacters();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            characters = persistantManager.Instance.getCharacters();
            UpdateUI();
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


    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < characters.Count)
            {
                slots[i].AddCharacter(characters[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
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
        sfx_s.Stop();
        sfx_s.clip = closeBag;
        sfx_s.Play();
    }
}
