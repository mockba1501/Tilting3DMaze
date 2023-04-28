using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MazeController : MonoBehaviour
{
    private Rigidbody mazeRigidBody;


    private void Awake()
    {
        mazeRigidBody = GetComponent<Rigidbody>();
    }
    public void TiltRight() 
    {
        Debug.Log("Tilting Right Side");
    }

    public void Tilting(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Tilting " + context);
            
            Vector2 inputVector = context.ReadValue<Vector2>();
            float speed = 5f;
            mazeRigidBody.AddForce(new Vector3(inputVector.x,0,inputVector.y) * speed, ForceMode.Impulse);
        }
    }

        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
