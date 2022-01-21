using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUiControler : MonoBehaviour
{
    public void Restart()
    {
        //SceneManager.LoadScene("Jogo");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Home()
    {
        SceneManager.LoadScene("HUB");
    }
}
