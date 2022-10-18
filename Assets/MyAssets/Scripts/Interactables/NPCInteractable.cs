using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : Interactable
{
    #region Variables NPC
    [SerializeField]
    private string nombre = "Soledad";

    [SerializeField]

    private string[] dialogos;
    
    private DialogManager dialogManager;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>(); //Para Singeltongs
        if (dialogManager == null) 
        { 
            Debug.LogError("No se encontró el manejador de dialogos"); 
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        Debug.Log("Interactuando con un NPC " + nombre);
        //Enviar los dialogos
        dialogManager.SetDialogue(nombre, dialogos); //Enviar los dialogos y el nombre
    }


}
