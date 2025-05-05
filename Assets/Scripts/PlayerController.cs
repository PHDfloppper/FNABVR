using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //transform du gameobject du joueur
    [SerializeField] private Transform playerTransform;
    //sensibilié dans la caméra
    [SerializeField] private float sensibilité = 2f;
    //transform de la camera du joueur (pas le joueur au complet, vraiment juste sa caméra)
    [SerializeField] private Transform cameraTransform;


    //gère la rotation de la caméra avec les joysticks
    public void CameraRotation(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        float rotationHorizontale = input.x * sensibilité;

        playerTransform.Rotate(Vector3.up, rotationHorizontale, Space.World);
    }

    //gère la hauteur de la caméra avec les joysticks
    public void CameraHauteur(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        float hauteurDelta = input.y * sensibilité;

        Vector3 positionCamera = cameraTransform.localPosition;
        positionCamera.y = Mathf.Clamp(positionCamera.y + hauteurDelta * Time.deltaTime, 0.0f, 3f);
        cameraTransform.localPosition = positionCamera;
    }
}
