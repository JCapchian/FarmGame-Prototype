using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public PlayerInventory playerInventory;

    #region ItemsGUI
    
    public TMP_Text amountDurazno;
    public TMP_Text amountTrigo;
    
    #endregion

    #region ToolsGUI
    
    public Image toolSlot;
    [SerializeField]
    private Sprite AxeIcon;
    [SerializeField]
    private Sprite HoeIcon;
    [SerializeField]
    private Sprite WateringCanIcon;
    
    #endregion
    private void Awake() 
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
    }

    public void UpdateItemsGUI(string itemGround)
    {
        switch(itemGround)
        {
            case "Coin":
                playerInventory.obteinedMoney += 1;
                
            break;
            case "Durazno":
                playerInventory.amountDurazno += 1;
                amountDurazno.text = "x" + playerInventory.amountDurazno;
            break;
            case "Trigo":
                playerInventory.amountTrigo += 1;
                amountTrigo.text = "x" + playerInventory.amountTrigo;
            break;
        }
    }

    public void UpdateToolsGUI(int toolNumber)
    {
        switch (toolNumber)
        {
            case 1:
                toolSlot.sprite = HoeIcon;
            break;
            case 2:
                toolSlot.sprite = AxeIcon;
            break;
            case 3:
                toolSlot.sprite = WateringCanIcon;
            break;
        }
        
    }
}
