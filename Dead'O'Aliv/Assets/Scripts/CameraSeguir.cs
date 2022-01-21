using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguir : MonoBehaviour
{

    private Transform player;
    private Vector3 PosTemp;

    [SerializeField]
    private float minX, maxX;
    private string Jogador_TAG = "Player"; // a tag no inspector

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(Jogador_TAG).transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if(!player) // if(player == null) é a mesma coisa
        return; // nao executa o codigo abaixo

        PosTemp = transform.position; // posição atual da camera

        PosTemp.x = player.position.x;      // envia a camera pra posição do alvo

        if(PosTemp.x < minX)
            PosTemp.x = minX;
            
        if(PosTemp.x > maxX)
            PosTemp.x = maxX;
        
        transform.position = PosTemp;       // envia a camera pra posição do alvo
    }
}
