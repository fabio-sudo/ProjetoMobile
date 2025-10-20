using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Movimentação")]
    [Range(0,10)]
    public float speed = 3f;
    public float maxSpeed = 3f;
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
    }

    private void Movimentacao()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Controlar a velocidade do cubo
        if (rb.linearVelocity.magnitude < maxSpeed) { 
        
        Vector3 moveDirection = 
                new Vector3 (horizontalInput, 0, verticalInput)*speed;

            rb.linearVelocity = 
                new Vector3(moveDirection.x, rb.linearVelocity.y,moveDirection.z);

        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
    }
}
