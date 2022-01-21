using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstros : MonoBehaviour
{

    public float velocidade;
    private Rigidbody2D myBody;


    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();       
    }

    void FixedUpdate()
    {
        myBody.velocity = new Vector2(velocidade,myBody.velocity.y);
    }
}
