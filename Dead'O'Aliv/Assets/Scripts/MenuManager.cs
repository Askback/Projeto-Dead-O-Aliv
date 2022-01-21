using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instancia;
    [SerializeField]
    private GameObject[] Personagens;

    private int _PersoIndex;

    public int PersoIndex 
    {
        get { return _PersoIndex; }
        set { _PersoIndex = value; }
    }

    private void Awake ()
    {
        if ( instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

        private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Jogo")
        {
            Instantiate(Personagens[PersoIndex]);
        }
    }

}
