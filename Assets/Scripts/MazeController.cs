using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class MazeController : MonoBehaviour
{
   
    private PlayerInputActions playerInputActions;
    public Transform target;

    //Rotation Limitations
    float rotationSpeed = 10;
    float maxRotX = 30f;
    float minRotX = -30f;
    float maxRotZ = 30f;
    float minRotZ = -30f;

    Vector3 currentEulerAngles;
    Quaternion currentRotation;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Maze.Enable();
    }
    
    private void FixedUpdate()
    {
        //Using the new Input System
        Vector2 inputVector = playerInputActions.Maze.Tilting.ReadValue<Vector2>();

        //Adjusting arrow key values
        Vector3 relativeRotation = new Vector3(inputVector.y, 0, -inputVector.x);

        //Updating EulerAngles
        currentEulerAngles += relativeRotation * Time.deltaTime * rotationSpeed;

        //moving the value of the Vector3 into Quanternion.eulerAngle format
        currentRotation.eulerAngles = currentEulerAngles;

        //apply the Quaternion.eulerAngles change to the gameObject
        transform.rotation = currentRotation;

        LimitRotation();

    }

    private void LimitRotation()
    {
        Vector3 mazeEulerAngle = transform.rotation.eulerAngles;

        mazeEulerAngle.x = (mazeEulerAngle.x > 180) ? mazeEulerAngle.x - 360 : mazeEulerAngle.x;
        mazeEulerAngle.x = Mathf.Clamp(mazeEulerAngle.x, minRotX, maxRotX);

        mazeEulerAngle.z = (mazeEulerAngle.z > 180) ? mazeEulerAngle.z - 360 : mazeEulerAngle.z;
        mazeEulerAngle.z = Mathf.Clamp(mazeEulerAngle.z, minRotZ, maxRotZ);

        transform.rotation = Quaternion.Euler(mazeEulerAngle);

    }    

}
