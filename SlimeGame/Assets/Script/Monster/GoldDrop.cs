using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldDrop : MonoBehaviour
{
    public int goldDropPercent = 0;
    public GameObject goldPrefab;

    public void Drop(Vector3 deadPosition, Quaternion deadRotation)
    {
        int percent = Random.Range(0, 101);
        if(percent < goldDropPercent )
        {
            //�̋� ��� �����
            Instantiate(goldPrefab, deadPosition, deadRotation);
        }
    }
}
