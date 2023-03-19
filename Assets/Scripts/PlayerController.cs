using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public int desiredLane = 1;
    public float laneDistance = 4;
    void Start()
    {

        controller = GetComponent<CharacterController>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane++;
            if (desiredLane == -1)
                desiredLane = 0;

        }

        // Calcualat ewhere we  should be in the future

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;

        }else if ( desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;

        }
         
        transform.position = targetPosition;

        
    }

    void FixedUpdate()
    {

        controller.Move(direction * Time.fixedDeltaTime);
    }
}
