using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class ToolPickUp : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public string toolType;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Puedes agarrar: " + this.name);
            playerInventory = other.gameObject.GetComponent<PlayerInventory>();
        }            
    }


    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            if(Keyboard.current.eKey.isPressed)
                PickedUpPlayer();
        }
    }
    

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("No puedes agarrar: " + this.name);
        }
                 
    }

    private void PickedUpPlayer()
    {
        playerInventory.GetTool(toolType);
        Debug.Log("Agarro herramienta: " + toolType);
        Destroy(this.gameObject);
    }
}
