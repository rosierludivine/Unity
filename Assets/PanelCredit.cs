using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelCredit : MonoBehaviour
{
   public void GoToMenu()
    {
        Debug.Log("GoToMenu method called."); // Ajoutez ceci pour le débogage
        Time.timeScale = 1f; // Restaure le temps
        SceneManager.LoadScene("Menu"); // Remplacez par le nom de votre scène de menu
    }
}
