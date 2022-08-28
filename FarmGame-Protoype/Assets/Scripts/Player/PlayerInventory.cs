using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //[Header ("Propiedades")]
    private PlayerControls playerControls;
    private CircleCollider2D pickUpZone;
     
    [Header ("Herramientas")]   
    public bool gotHacha;
    public bool gotAzada;
    public bool gotRegadera;
    [Header ("Items")]
    public int obteinedMoney;
    public int amountTrigo;
    public int amountDurazno;

    // Start is called before the first frame update
    void Start()
    {
        playerControls = new PlayerControls();
        pickUpZone = this.gameObject.transform.GetChild(1).GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    #region Tools Region
    public void GetTool(string toolGround)
    {
        switch (toolGround)
        {
            case "Hacha":
                gotHacha = true;
            break;
            case "Azada":
                gotAzada = true;
            break;
            case "Regadera":
                gotRegadera = true;
            break;

        }
    }

    public void SetTool()
    {

    }

    #endregion

    #region Items Region

    #endregion 
}
