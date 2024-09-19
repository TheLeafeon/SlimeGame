using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitUI : MonoBehaviour
{
    public void ClosePanel(GameObject PanelName)
    {
        PanelName.SetActive(false);
        Player.instance.PlayerMove();
    }
}
