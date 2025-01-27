using UnityEngine;

public class jump : MonoBehaviour
{
    // Variables
    public float jumpForce = 5f; 
    public float groundCheckDistance = 0.6f; 
    public LayerMask groundLayer; 

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
    }

    void Update()
    {
        Debug.Log(isGrounded);
        
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);

        
        Debug.DrawRay(transform.position, Vector3.down * groundCheckDistance, Color.red);

        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Apply upward force to the Rigidbody
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
