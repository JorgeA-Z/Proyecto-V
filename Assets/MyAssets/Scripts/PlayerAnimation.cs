using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    #region Variables de Animaccion
    [SerializeField]
    private Animator PlayerAnimator;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimator = GetComponentInChildren<Animator>();

        if (PlayerAnimator == null)
        {
            Debug.LogWarning("El jugador no tiene un animador");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSpeed(float speed) 
    {
        PlayerAnimator.SetFloat("Speed", speed);
    }
}
