using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colletor : MonoBehaviour
{
    private string Jogador_TAG = "Player";
    private string Inimigo_TAG = "Inimigo";
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Inimigo_TAG) || collision.CompareTag(Jogador_TAG) )
        Destroy(collision.gameObject);
    }
}
