using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    InventoryManager _inventoryManager;
    public GameObject amountTextObject;
    public TMP_Text amountText;
    public int amountStack;
    
    private void Awake() 
    {
        _inventoryManager = FindObjectOfType<InventoryManager>();
        amountTextObject = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        amountText = amountTextObject.GetComponent<TMP_Text>();

        if(amountStack == 0)
        {
            amountTextObject.active = false;
        }
        else
            amountText.text = "x" + amountStack;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
