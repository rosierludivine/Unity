using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void ClickPlay()
        {
            SceneManager.LoadScene("Jouer");
        }

    public void GoToCredit()
    {
        Debug.Log("GoToMenu method called."); // Ajoutez ceci pour le débogage
        Time.timeScale = 1f; // Restaure le temps
        SceneManager.LoadScene("Credit"); // Remplacez par le nom de votre scène de menu
    }

    public void Exit()
    {
        #if UNITY_EDITOR
        // Si nous sommes dans l'éditeur Unity, stoppons la lecture
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

}
