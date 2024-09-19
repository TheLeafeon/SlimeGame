using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Spike : MonoBehaviour
{
    public GameObject playerCharacter;
    public float orbitRadius = 2.0f;
    public float orbitSpeed = 2.0f;
    public int spikePower = 10;
    private float angle = 0f;

    private void Start()
    {

    }
    void Update()
    {
       
        Vector2 centerPosition = playerCharacter.transform.position;

        angle += orbitSpeed * Time.deltaTime;

        float x = centerPosition.x + Mathf.Cos(angle) * orbitRadius;
        float y = centerPosition.y + Mathf.Sin(angle) * orbitRadius;

        transform.position = new Vector2(x, y);

        transform.Rotate(Vector3.back * orbitSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            MonsterTakeDamage monsters = collision.gameObject.GetComponent<MonsterTakeDamage>();

            if (monsters != null)
            {

                monsters.TakeDamage(spikePower);

            }

        }
    }
}
