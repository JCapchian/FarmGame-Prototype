using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header ("Inventory of the player")]
    private PlayerControls playerControls;
    private CircleCollider2D pickUpZone;
    [SerializeField]
    private int obteinedMoney;    
    public bool gotHacha;
    public bool gotAzada;
    public bool gotRegadera;
    [SerializeField]
    private List<GameObject> inventario = new List<GameObject>();

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
}
