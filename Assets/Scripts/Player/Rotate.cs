using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Joystick joystickRotate;
    [SerializeField] private float sensitivity = 50;
    [SerializeField] private float upperVerticalRotationLimit = 90; 
    [SerializeField] private float lowerVerticalRotationLimit = 90; 

    private float xRotation;
    private float yRotation;

    private void Update()
    {
        float xJoystick = joystickRotate.Horizontal * Time.deltaTime * sensitivity; 
        float yJoystick = joystickRotate.Vertical * Time.deltaTime * sensitivity;

        xRotation -= yJoystick;
        xRotation = Mathf.Clamp(xRotation, -lowerVerticalRotationLimit, upperVerticalRotationLimit);

        yRotation += xJoystick;

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        player.transform.localRotation = Quaternion.Euler(0, yRotation, 0);
    }
}
