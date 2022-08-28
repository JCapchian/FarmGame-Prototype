using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public UIManager _uiManager;
    public string typeItem;

    private void Awake() {
        //Assing player inventory
        _uiManager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            //Call the fuction that save the intem in the inventory
            _uiManager.UpdateUI(typeItem);
            
            Destroy(this.gameObject);

        }
    }
}
