using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //transform du gameobject du joueur
    [SerializeField] private Transform playerTransform;
    //sensibili� dans la cam�ra
    [SerializeField] private float sensibilit� = 2f;
    //transform de la camera du joueur (pas le joueur au complet, vraiment juste sa cam�ra)
    [SerializeField] private Transform cameraTransform;


    //g�re la rotation de la cam�ra avec les joysticks
    public void CameraRotation(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        float rotationHorizontale = input.x * sensibilit�;

        playerTransform.Rotate(Vector3.up, rotationHorizontale, Space.World);
    }

    //g�re la hauteur de la cam�ra avec les joysticks
    public void CameraHauteur(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        float hauteurDelta = input.y * sensibilit�;

        Vector3 positionCamera = cameraTransform.localPosition;
        positionCamera.y = Mathf.Clamp(positionCamera.y + hauteurDelta * Time.deltaTime, 0.0f, 3f);
        cameraTransform.localPosition = positionCamera;
    }
}
