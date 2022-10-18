using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update

    #region Variables Movimiento
    //[HideInInspector]
    //public int varPub;

    private Rigidbody PlayerRB;
    
    [SerializeField]
    private float speed;
    [SerializeField]
    private float MaxSpeed = 5f;
    [SerializeField]
    private float horizontalInput, fowardInput, runInput;
    [SerializeField]
    private bool isRunning;
    #endregion

    #region Variables de Brinco
    [SerializeField]
    private bool JumpRequest = false;
    [SerializeField]
    private float JumpForce = 5f;
    [SerializeField]
    private int AvilableJumps = 0, MaxJump = 1;
    #endregion

    #region Animacion
    [SerializeField]
    private PlayerAnimation PAtor;
    #endregion
    void Start()
    {
        #region RidgidBody
        PlayerRB = GetComponent<Rigidbody>();
        #endregion


        PAtor = GetComponent<PlayerAnimation>();

        if (PAtor == null) 
        {
            Debug.LogWarning("El jugador no tiene script");
        }
        speed = MaxSpeed;
        isRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        runInput = Input.GetAxis("Walk");
        
        #region Movimiento
        horizontalInput = Input.GetAxis("Horizontal"); // AD Izquierda Derecha
        
        fowardInput = Input.GetAxis("Vertical"); //WS Arriba Abajo
        
        float velocity = Mathf.Max(Mathf.Abs(horizontalInput), Mathf.Abs(fowardInput) * speed / MaxSpeed);

        PAtor.setSpeed(velocity);

        Vector3 movement = new Vector3(horizontalInput, 0, fowardInput);
        
        transform.Translate(movement*speed*Time.deltaTime);
        #endregion

        #region Salto
        if (Input.GetKeyDown(KeyCode.Space) && AvilableJumps > 0) 
        {
            JumpRequest = true;
        }

        #endregion
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = !isRunning;
            if (isRunning)
            {
                speed = MaxSpeed;
            }
            else
            {
                speed = MaxSpeed / 3;
            }
        }


    }

    private void FixedUpdate()
    {
        if (JumpRequest) 
        {
            PlayerRB.velocity = Vector3.up*JumpForce;
            AvilableJumps--;
            JumpRequest = false;
        }
        
  

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            AvilableJumps = MaxJump;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            Debug.Log("Se encontró objeto");
            
            Interactable interacted = collision.GetComponent<Interactable>();
            if (interacted != null)
            {
                interacted.Interact();
            }
            else
            {
                Debug.Log("pero el objeto no tiene script para interactuar");
            }
            

        }


    }

}
