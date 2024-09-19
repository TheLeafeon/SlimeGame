using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldView : MonoBehaviour
{
    public TMP_Text nowGold;


    private void Update()
    {
        nowGold.text = Player.instance.getGold.ToString();
    }
}
