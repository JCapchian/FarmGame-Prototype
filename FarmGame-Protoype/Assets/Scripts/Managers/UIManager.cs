using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public PlayerInventory playerInventory;

    #region ItemsUI
    
    public TMP_Text amountDurazno;
    public TMP_Text amountTrigo;
    
    #endregion

    private void Awake() 
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
    }

    public void UpdateUI(string itemGround)
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
}
