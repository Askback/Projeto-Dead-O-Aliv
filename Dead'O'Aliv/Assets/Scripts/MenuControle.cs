using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // bota isso pra troca de cena

public class MenuControle : MonoBehaviour
{
    public void Play()
    {
        int selecionado =
        int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        MenuManager.instancia.PersoIndex = selecionado;
        SceneManager.LoadScene("Jogo");
    }
} //class
