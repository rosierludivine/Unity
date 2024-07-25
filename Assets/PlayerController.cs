using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Pour 3D
        // rb = GetComponent<Rigidbody2D>(); // Pour 2D
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime; // Pour 3D
        // Vector2 move = new Vector2(horizontal, vertical) * moveSpeed * Time.deltaTime; // Pour 2D

        rb.MovePosition(transform.position + move); // Pour 3D
        // rb.MovePosition(rb.position + move); // Pour 2D
    }
}
