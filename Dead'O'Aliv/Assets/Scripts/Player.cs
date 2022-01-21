using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] // torna visivel no painel de inspeção mesmo sendo privada
    private float ForcaPulo = 10f;

    [SerializeField]
    private float ForcaMove = 11f;
    private float movimentoX;
    private Rigidbody2D myBody;
    private SpriteRenderer SprRen;
    private Animator anim; 
    private string AndarAnim = "Andar"; 
    private string Chao_TAG = "Chao";
    private string Inimigo_TAG = "Inimigo";
    private bool EstaChao = false;

    private void Awake ()

    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        SprRen = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()

    {

    }

    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()

    {
        MovimentoTecl ();
        animarPlayer();
        playerPulo();
    }

    void MovimentoTecl ()

    {
         movimentoX = Input.GetAxisRaw("Horizontal"); // RAW = SEM INERCIA -1 PARA 1 INSTA
         transform.position += new Vector3(movimentoX,0f,0f) * Time.deltaTime * ForcaMove;
    }

    void animarPlayer()

    {
        // direita
        if (movimentoX > 0) 
        {
            anim.SetBool(AndarAnim, true);
            SprRen.flipX = false;
        }
        // esquerda
        else if (movimentoX < 0)
        {
            anim.SetBool(AndarAnim, true);
            SprRen.flipX = true;
        }
        else 
        {
            anim.SetBool(AndarAnim, false);
        }
    }

    void playerPulo ()

    {
        if (Input.GetButtonDown("Jump") && EstaChao == true) //GetButtonUP aciona quando solta a tecla, DOWN quando pressional, GetButton sozinho nas 2 ocasioes e permite segurar
        {
            EstaChao = false;
            myBody.AddForce(new Vector2(0f,ForcaPulo), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Chao_TAG))
        {
            EstaChao = true;
        }
        
        
        if (collision.gameObject.CompareTag(Inimigo_TAG))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // o corpo do fantasma é kinematic portanto nao tem colisão, entao precisa testar dessa forma
    {
        if (collision.CompareTag(Inimigo_TAG))
            Destroy(gameObject);
        
    }   
}
