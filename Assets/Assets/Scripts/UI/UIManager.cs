using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Hey UI manager = null, please add one");
            }
            return _instance;
        }
    }

    public Text playerGemCountText;
    public Image selectionImage;

    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = "" + gemCount + "G"; 
    }

    public void UpdateShopSelection(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    void Awake() 
    {
        _instance = this; 
    }

}
