using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogManager : MonoBehaviour
{
    private static DialogManager Instancia;

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
            return;
        }
        
    }

    #region Componentes
    [SerializeField]
    private GameObject DialogPnl;
    
    [SerializeField]
    private Button nextButton;
    
    [SerializeField]
    private TextMeshProUGUI dialogText, nameText, nextText;

    #endregion

    #region Variables NPC
    [SerializeField]
    private string nombre;
    
    [SerializeField]
    private List<string> dialogList;
    
    [SerializeField]
    private int IDx;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        #region GetDialogPanel

        if (DialogPnl == null)
        {
            Debug.LogError("No se asigno un panel de dialogo");
        }
        else 
        {
            // Hijos por indicie
            dialogText = DialogPnl.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
            //Primer hijo

            //dialogText = DialogPnl.GetComponentInChildren<TextMeshProUGUI>();
            if (dialogText == null) 
            {
                Debug.LogError("No se Encontró un panel de dialogos");
            }
            else
            {
                dialogText.text = "Dialogos inicializados";
            }
            
            //Buscar al segundo hijo
            nameText = DialogPnl.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();

            if (nameText == null)
            {
                Debug.LogError("No se Encontró un panel de nombre");
            }
            else
            {
                nameText.text = "Nombre Inicializado";
            }
            //Buscar al boton del tercer hijo

            nextButton = DialogPnl.transform.GetChild(2).GetComponent<Button>();
            if (nextButton == null)
            {
                Debug.LogError("No se Encontró un boton");
            }
            else 
            {
                nextButton.onClick.AddListener(delegate { nextDialoge();  });

                nextText = nextButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

                if (nextText == null)
                {
                    Debug.LogError("No se Encontró el texto del boton");
                }
                else
                {
                    nextText.text = "Continuar";
                }
            }
        }

        #endregion

        DialogPnl.SetActive(false);

    }

    // Update is called once per frame
    void Update() 
    {
        
    }

    public void SetDialogue(string nameNPC, string[] DialogueNPC) 
    {
        nombre = nameNPC;
        dialogList = new List<string>(DialogueNPC.Length);
        
        dialogList.AddRange(DialogueNPC);
        IDx = 0;
        
        nameText.text = nombre;
        dialogText.text = dialogList[IDx];

        nextText.text = "E";
        DialogPnl.SetActive(true);

    }

    private void nextDialoge() 
    {
        int tam = dialogList.Count - 1;
        
        Debug.Log(IDx);
        
        if (IDx < tam) 
        { 
            IDx++;
            dialogText.text = dialogList[IDx];
        }else 
        {
            DialogPnl.SetActive(false);
        }
    }


}
