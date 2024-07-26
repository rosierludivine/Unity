using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Références aux éléments UI
    public TMP_Text timerText; // Pour afficher le temps restant
    public TMP_Text scoreText; // Pour afficher le score
    public AudioSource collectSound; // Référence à l'AudioSource pour le bruit de collecte

    public float timeLimit = 60f; // Temps limite en secondes
    private float timeRemaining;
    private bool gameEnded = false;
    private int score = 0;
    private int totalItems = 9; // Nombre total de pièces à collecter
    private int collectedItems = 0; // Nombre de pièces collectées

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Ne pas détruire ce GameObject entre les scènes
        }
        else
        {
            Destroy(gameObject); // Assurer qu'il n'y ait qu'une seule instance
        }
    }

    void Start()
    {
        timeRemaining = timeLimit;
        UpdateTimerText(); // Initialisation du chronomètre
        UpdateScoreText(); // Initialisation du score
    }

    void Update()
    {
        if (gameEnded) return;

        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            if (collectedItems >= totalItems)
            {
                EndGame(true); // Gagner
            }
            else
            {
                EndGame(false); // Perdre
            }
        }
        UpdateTimerText(); // Mise à jour du chronomètre
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
            SceneManager.LoadScene("Gagner"); // Charger la scène de victoire
        }
        else
        {
            SceneManager.LoadScene("GameOver"); // Charger la scène de défaite
        }
    }

    public void CollectItem()
    {
        score += 10;
        collectedItems++;
        UpdateScoreText();
        
        // Jouer le bruit de collecte uniquement lors de la collecte
        if (collectSound != null)
        {
            collectSound.Play();
        }

        // Vérifier si toutes les pièces sont collectées
        if (collectedItems >= totalItems)
        {
            if (timeRemaining > 0) // Assurez-vous que le temps n'est pas écoulé
            {
                EndGame(true); // Gagner
            }
        }
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

    public void SetTotalItems(int count)
    {
        totalItems = count;
    }
}
