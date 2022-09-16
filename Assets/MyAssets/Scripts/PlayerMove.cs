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
    private float speed = 5f;

    private float horizontalInput, fowardInput;
    #endregion

    #region Variables de Brinco
    [SerializeField]
    private bool JumpRequest = false;
    [SerializeField]
    private float JumpForce = 5f;
    [SerializeField]
    private int AvilableJumps = 0, MaxJump = 1;
    #endregion

    void Start()
    {
        #region RidgidBody
        PlayerRB = GetComponent<Rigidbody>();
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        #region Movimiento
        horizontalInput = Input.GetAxis("Horizontal"); // AD Izquierda Derecha
        
        fowardInput = Input.GetAxis("Vertical"); //WS Arriba Abajo

        Vector3 movement = new Vector3(horizontalInput, 0, fowardInput);
        
        transform.Translate(movement*speed*Time.deltaTime);
        #endregion

        #region Salto
        if (Input.GetKeyDown(KeyCode.Space) && AvilableJumps > 0) 
        {
            JumpRequest = true;
        }

        #endregion

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
}
