using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public Slider hpBar;

    float uiMaxHp = 0;
    float uiNowHp = 0;

    private void Start()
    {
        HpCheck();  
    }

    public void HpCheck()
    {
        uiMaxHp = Player.instance.maxHp;
        uiNowHp = Player.instance.nowHp;
        if (hpBar != null)
        {
            UnityEngine.Debug.Log("HP¹Ù °»½Å");
            hpBar.value = uiNowHp / uiMaxHp;
        }
    }
}
