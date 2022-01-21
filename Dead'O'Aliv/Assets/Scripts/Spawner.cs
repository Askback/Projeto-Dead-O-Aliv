using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject [] RefMonstro;

    private GameObject MonstroSpawned;

    private int randomIndex;

    private int randomSide;

    [SerializeField]
    private Transform Esquerda,Direita;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()

    {
    while (true)
        {
        
        yield return new WaitForSeconds(Random.Range(1,5));

        randomIndex = Random.Range(0, RefMonstro.Length); // aleatorio de 0 até o total de monstros, .lenght para nao ultrapassar o limite de monstros contidos
        randomSide = Random.Range(0, 2); // lados aleatorios direita ou esquerda

        MonstroSpawned = Instantiate(RefMonstro[randomIndex]); // clona um dos monstros contidos com a aleatoriedade de randomIndex

        if (randomSide == 0) // vai ser esquerda
            {
            MonstroSpawned.transform.position = Esquerda.position;
            MonstroSpawned.GetComponent<Monstros>().velocidade = Random.Range(4,10);
            
            }
        else
            {
            MonstroSpawned.transform.position = Direita.position;
            MonstroSpawned.GetComponent<Monstros>().velocidade = -Random.Range(4,10);
            MonstroSpawned.transform.localScale = new Vector3(-1f,1f,1f);
            }
        }
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
}
