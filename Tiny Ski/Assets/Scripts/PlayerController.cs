using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5.5f;

    private Rigidbody2D rb;

    public ParticleSystem particleSystem;

    public ParticleSystem snowBurstL;
    public ParticleSystem snowBurstR;

    private float prevDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        ParticleSystem.MainModule mainModule = particleSystem.main;
        mainModule.simulationSpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //ScreenBordersMovement();
        FingerMovement();






        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(-speed * Time.deltaTime, 0, 0);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Finish"))
        {
            Destroy(collider.gameObject);
        }
    }

    private void FingerMovement()
    {
        // Comprueba si el jugador toca la pantalla
        if (Input.touchCount > 0)
        {
            float fingerMovementX = Input.touches[0].deltaPosition.x;

            // Movimiento (transform)
            transform.Translate(fingerMovementX * speed * Time.deltaTime, 0, 0);

            // Movimiento (Rigidbody)
            //rb.linearVelocityX = fingerMovementX * speed;

            // Burst de partículas de nieve si hay cambio de dirección
            if ((prevDirection <= 0) && (fingerMovementX > 0))
            {
                // Mov. derecha
                snowBurstL.Play();
                prevDirection = fingerMovementX;
            }
            else if ((prevDirection > 0) && (fingerMovementX < 0))
            {
                // Mov. izquierda
                snowBurstR.Play();
                prevDirection = fingerMovementX;
            }
        }
        else
        {
            // Detener movimiento (Rigidbody)
            //rb.linearVelocityX = 0;
            prevDirection = 0;
        }
    }

    private void ScreenBordersMovement()
    {
        // Comprueba si el jugador toca la pantalla
        if (Input.touchCount > 0)
        {
            float touchScreenPositionX = Input.touches[0].position.x;
            float screenCenterX = Screen.width / 2;

            if (touchScreenPositionX > screenCenterX)
            {
                // Movimiento derecha (transform)
                transform.Translate(speed * Time.deltaTime, 0, 0);

                // Movimiento derecha (Rigidbody)
                //rb.linearVelocityX = speed;
            }
            else
            {
                // Movimiento izquierda (transform)
                transform.Translate(-speed * Time.deltaTime, 0, 0);

                // Movimiento izquierda (Rigidbody)
                //rb.linearVelocityX = -speed;
            }
        }
        else
        {
            // Detener movimiento (Rigidbody)
            rb.linearVelocityX = 0;
        }
    }
}
