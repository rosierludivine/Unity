using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    // Références aux éléments UI
    public TMP_Text timerText; // Pour afficher le temps restant
    public TMP_Text scoreText; // Pour afficher le score
    
    public float timeLimit = 60f; // Temps limite en secondes
    private float timeRemaining;
    private bool gameEnded = false;
    private int score = 0; 

    void Awake()
    {
        // Assurez-vous qu'il n'y a qu'une seule instance de GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        timeRemaining = timeLimit;
        UpdateTimerText(); // Met à jour le texte du chronomètre au début
        UpdateScoreText(); // Met à jour le texte du score au début
    }

    void Update()
    {
        if (gameEnded) return;

        timeRemaining -= Time.deltaTime; // Réduit le temps restant
        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            EndGame(false); // Termine le jeu si le temps est écoulé
        }
        UpdateTimerText(); // Met à jour le texte du chronomètre
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = "Temps restant : " + Mathf.Ceil(timeRemaining).ToString();
        }
        else
        {
            Debug.LogWarning("Timer Text is not assigned!");
        }
    }

    public void EndGame(bool won)
    {
        gameEnded = true;
        if (won)
        {
            // Logique pour victoire
            Debug.Log("Vous avez gagné !");
        }
        else
        {
            // Logique pour défaite
            Debug.Log("Vous avez perdu !");
        }
    }

    public void CollectItem()
    {
        // Ajouter des points lorsqu'un objet est collecté
        score += 10; // Ajoute 10 points (modifiez cette valeur selon vos besoins)
        UpdateScoreText(); // Met à jour le texte du score
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogWarning("Score Text is not assigned!");
        }
    }
}
