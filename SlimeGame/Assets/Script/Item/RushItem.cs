using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushItem : MonoBehaviour
{


    [SerializeField]
    private GameObject rushEffect;


    void OnCollisionEnter2D(Collision2D collision)
    {

        UnityEngine.Debug.Log("Projectile Collision with " + collision.gameObject);

        if (collision.gameObject.CompareTag("Player"))
        {

            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            StartCoroutine(RushCoroutine());

            
        }
    }

    private IEnumerator RushCoroutine()
    {
        UnityEngine.Debug.Log("코루틴 시작");
        Player.instance.isInvinsible = true;
        rushEffect.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        UnityEngine.Debug.Log("달리기 끝");

        Player.instance.verticalSpeed = Player.instance.basicVerticalSpeed;
        Player.instance.isRush = false;
        Player.instance.isInvinsible = false;
        rushEffect.SetActive(false);

        Destroy(gameObject);
    }
}
