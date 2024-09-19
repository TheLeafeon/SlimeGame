using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public TMP_Text nowGold;
    public int itemValue = 0;

    private void Update()
    {
        nowGold.text = itemValue.ToString();
    }
}
