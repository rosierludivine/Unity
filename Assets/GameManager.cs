using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Références aux éléments UI
    public TMP_Text timerText; // Pour afficher le temps restant
    public TMP_Text scoreText; // Pour afficher le score

    public float timeLimit = 60f;
    private float timeRemaining;
    private bool gameEnded = false;
    private int score = 0;

    void Awake()
    {
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
            EndGame(false);
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
            Debug.Log("Vous avez gagné !");
        }
        else
        {
            Debug.Log("Vous avez perdu !");
        }
    }

    public void CollectItem()
    {
        score += 10;
        UpdateScoreText();
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
