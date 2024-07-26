using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ramasser : MonoBehaviour
{    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Piece collectée"); // Pour vérifier que la méthode est appelée
            if (GameManager.instance != null)
            {
                GameManager.instance.CollectItem();
                Destroy(gameObject); // Détruire la pièce après la collecte
            }
        }
    }
}
