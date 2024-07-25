using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ramasser : MonoBehaviour
{    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.CollectItem();
            Destroy(gameObject);
        }
    }
}
