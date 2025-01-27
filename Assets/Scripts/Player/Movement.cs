using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Joystick joystickMovement;
    [SerializeField] private int speed = 5;
    private float gravity = -9.8f;

    private void Update()
    {
        float xJoystick = joystickMovement.Horizontal;
        float zJoystick = joystickMovement.Vertical;

        Vector3 move = characterController.transform.right * xJoystick + characterController.transform.up * gravity + characterController.transform.forward * zJoystick;

        characterController.Move(move * Time.deltaTime * speed);
    }
}
