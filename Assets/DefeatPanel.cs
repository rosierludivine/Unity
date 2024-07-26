using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatPanel : MonoBehaviour
{
    public void RestartGame()
    {
        Debug.Log("RestartGame method called."); // Ajoutez ceci pour le débogage
        Time.timeScale = 1f; // Restaure le temps
        SceneManager.LoadScene("Jouer"); // Remplacez par le nom de votre scène de jeu
    }

    public void GoToMenu()
    {
        Debug.Log("GoToMenu method called."); // Ajoutez ceci pour le débogage
        Time.timeScale = 1f; // Restaure le temps
        SceneManager.LoadScene("Menu"); // Remplacez par le nom de votre scène de menu
    }
}
