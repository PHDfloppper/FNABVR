using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float sensibilité = 2f;
    [SerializeField] private float vitesse = 5f;
    //[SerializeField] private CharacterController controller;
    [SerializeField] private Transform cameraTransform;

    private Vector2 inputDeplacement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //DeplacerJoueur();
    }

    public void CameraRotation(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        float rotationHorizontale = input.x * sensibilité;

        playerTransform.Rotate(Vector3.up, rotationHorizontale, Space.World);
    }

    public void CameraHauteur(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        float hauteurDelta = input.y * sensibilité;

        Vector3 positionCamera = cameraTransform.localPosition;
        positionCamera.y = Mathf.Clamp(positionCamera.y + hauteurDelta * Time.deltaTime, 0.0f, 3f);
        cameraTransform.localPosition = positionCamera;
    }

    //public void CameraJoueurMove(InputAction.CallbackContext context)
    //{
    //    inputDeplacement = context.ReadValue<Vector2>();
    //    UnityEngine.Debug.LogWarning("BOUGE!!!!!");
    //}

    //private void DeplacerJoueur()
    //{
    //    // Calculer la direction selon l'orientation de la caméra
    //    Vector3 directionAvant = playerTransform.right;
    //    Vector3 directionDroite = -playerTransform.forward;

    //    directionAvant.y = 0f;
    //    directionDroite.y = 0f;
    //    directionAvant.Normalize();
    //    directionDroite.Normalize();

    //    Vector3 direction = directionAvant * inputDeplacement.y + directionDroite * inputDeplacement.x;

    //    // Déplacer le joueur avec collisions
    //    controller.Move(direction * vitesse * Time.deltaTime);
    //}
}
