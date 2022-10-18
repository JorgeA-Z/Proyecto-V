using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    #region Variables Camara
    [SerializeField]
    private Transform Player, PlayerCamera, FocusPoint;
    [SerializeField]
    private float CameraHeight = 0;

    #endregion

    #region Variables Zoom
    [SerializeField]
    private float Zoom = -5, ZoomSpeed = 8;
    [SerializeField]
    private float ZoomMin = -8f, ZoomMax = 0f;
    #endregion

    #region Variables rotacion
    [SerializeField]
    private float CamRotX, CamRotY;
    [SerializeField]
    private float CameraVelocity = 2;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        #region Asignar Parentesco
        FocusPoint.SetParent(Player.gameObject.transform);
        PlayerCamera.SetParent(FocusPoint);
        #endregion

        #region Asignar Posición, Rotación, Escala
        FocusPoint.localPosition = new Vector3(0, CameraHeight, 0);
        FocusPoint.localRotation = Quaternion.Euler(0, 0, 0);
        FocusPoint.localScale = new Vector3(1, 1, 1);

        PlayerCamera.localPosition = new Vector3(0, 0, Zoom);
        PlayerCamera.LookAt(Player);
        PlayerCamera.localScale = new Vector3(1, 1, 1);

        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        #region Zoom Camara
        Zoom += Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;

        Zoom = Mathf.Clamp(Zoom, ZoomMin, ZoomMax);

        PlayerCamera.localPosition = new Vector3(0, 0, Zoom);
        PlayerCamera.LookAt(Player);
        #endregion


        #region rotacion camara
        CamRotX += Input.GetAxis("Mouse X") * CameraVelocity;
        CamRotY += Input.GetAxis("Mouse Y") * CameraVelocity;
        CamRotY = Mathf.Clamp(CamRotY, -45f, 90f);
        FocusPoint.localRotation = Quaternion.Euler(CamRotY, 0, 0);

        Player.localRotation = Quaternion.Euler(0, CamRotX, 0);
       
        #endregion


        #region Actualizar  Camara

        PlayerCamera.localPosition = new Vector3(0, 0, Zoom);
        PlayerCamera.LookAt(Player);
        #endregion
    }
}
