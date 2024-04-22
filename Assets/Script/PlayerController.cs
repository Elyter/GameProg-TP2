using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public LayerMask groundLayer;

    private bool isGrounded;
    private int jumpsRemaining;

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, 1f, groundLayer);

        if (isGrounded)
        {
            jumpsRemaining = 1; // Réinitialise le nombre de sauts disponibles lorsque le joueur est au sol.

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
        else
        {
            if (jumpsRemaining > 0 && Input.GetButtonDown("Jump"))
            {
                Jump();
                jumpsRemaining--;
            }
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpForce);
    }
}
