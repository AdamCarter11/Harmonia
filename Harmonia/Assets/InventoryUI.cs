using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform charactersParent;

    InventorySlot[] slots;

    Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        /*inventory = Inventory.instance;
        inventory.onCharacterChangedCallback += UpdateUI;

        slots = charactersParent.GetComponentsInChildren<InventorySlot>();
        UpdateUI();*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
