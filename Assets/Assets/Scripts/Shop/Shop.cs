using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public int currentSelectedItem;
    public int currentItemCost;
    private Player _player;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            _player = other.GetComponent<Player>();
            if(_player != null)
            {
                UIManager.Instance.OpenShop(_player.diamonds);
            }
            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false); 
        }
    }

    public void SelectItem(int item) 
    { 
        // 0 = flame sword
        // 1 = boots of flight
        // 2 = key to castle
        Debug.Log("SelectItem() : " + item); 

        // Switch between item.
        switch(item)
        {
            case 0: // Flame Sword
                UIManager.Instance.UpdateShopSelection(62);
                currentSelectedItem = 0;
                currentItemCost = 200;
                break;
            case 1: // Boots
                UIManager.Instance.UpdateShopSelection(-41);
                currentSelectedItem = 1;
                currentItemCost = 400;
                break;
            case 2: // Key
                UIManager.Instance.UpdateShopSelection(-153);
                currentSelectedItem = 2;
                currentItemCost = 100;
                break;
        }
    }

    public void BuyItem()
    {
        if(_player.diamonds >= currentItemCost)
        {
            // Award item
            if(currentSelectedItem == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }
            _player.diamonds -= currentItemCost;
            Debug.Log("Purchased " + currentSelectedItem);
            Debug.Log("Remaining gems: " + _player.diamonds);
            shopPanel.SetActive(false); 
        }
        else
        {
            Debug.Log("You do not have enough gems. Closing Shop. ");
            shopPanel.SetActive(false);
        }
        
    }
    
}
