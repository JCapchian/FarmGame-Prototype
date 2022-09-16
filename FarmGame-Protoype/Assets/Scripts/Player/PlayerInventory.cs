using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //[Header ("Propiedades")]
    private PlayerControls _playerControls;
    private Animator _playerAnimator;
    private UIManager _uiManager;
    private CircleCollider2D _pickUpZone;

    [Header ("Player Input")]
    public bool interacted;
    public bool usingTool;
     
    [Header ("Herramientas")]   
    public int activeTool;
    public bool gotAxe;
    public bool gotHoe;
    public bool gotWateringCan;


    [Header ("Items")]
    public int obteinedMoney;
    public int amountTrigo;
    public int amountDurazno;

    // Start is called before the first frame update
    void Start()
    {
        _playerControls = new PlayerControls();
        _playerControls.Enable();
        _pickUpZone = this.gameObject.transform.GetChild(1).GetComponent<CircleCollider2D>();
        _uiManager = FindObjectOfType<UIManager>();
        // Define the animator
        _playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();

        if(usingTool)
            StartCoroutine(UseTool());
        /*else
        {
            usingTool = false;
            _playerAnimator.SetBool("UsingTool",false);
        }
        */
            
    }

    #region PlayersInput

    public void PlayerInput()
    {
        //Player press tools numbers

        //Player press interaction button
        _playerControls.Player.Interact.performed += i => interacted = true;
        _playerControls.Player.Interact.canceled += i => interacted = false;

        //Player using the tool
        _playerControls.Player.UseTool.performed += i => usingTool = true;
        _playerControls.Player.UseTool.canceled += i => usingTool = false;
    }

    #endregion
    
    #region Tools Region
    public void GetTool(string toolGround)
    {
        switch (toolGround)
        {
            case "Axe":
                gotAxe = true;
                activeTool = 2;
                _uiManager.UpdateToolsGUI(activeTool);
                _playerAnimator.SetInteger("ToolNumber", activeTool);
            break;
            case "Hoe":
                gotHoe = true;
                activeTool = 1;
                _uiManager.UpdateToolsGUI(activeTool);
                _playerAnimator.SetInteger("ToolNumber", activeTool);
            break;
            case "WateringCan":
                gotWateringCan = true;
                activeTool = 3;
                _uiManager.UpdateToolsGUI(activeTool);
                _playerAnimator.SetInteger("ToolNumber", activeTool);
            break;
        }
    }

    public void SwitchTool()
    {

    }

    public IEnumerator UseTool()
    {
        Debug.Log("Uso Herramienta");

        usingTool = true;
        _playerAnimator.SetBool("UsingTool", usingTool);

        yield return new WaitForSeconds(0.6f); 

        usingTool = false;
        _playerAnimator.SetBool("UsingTool", usingTool);

        Debug.Log("Dejo de usarla");
    }



    #endregion

    #region Items Region

    #endregion 
}
