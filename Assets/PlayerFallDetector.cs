using UnityEngine;

public class PlayerFallDetector : MonoBehaviour
{
    public float fallThreshold = -10f; // La position Y en dessous de laquelle le joueur est considéré comme tombé

    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            // Appelle la méthode EndGame du GameManager en cas de défaite
            if (GameManager.instance != null)
            {
                GameManager.instance.EndGame(false);
            }
        }
    }
}