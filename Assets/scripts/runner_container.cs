using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runner_container : MonoBehaviour
{
     
    public float playerSpeed = 2f;
    public float Keyboard_MovementSpeed = 1.5f;
   public float Touch_MovementSpeed = 2f;
    

    // public Renderer runner_rend;

    public Transform followerPos;

    
    public List<runner> myRunners = new List<runner>();

   // public VariableJoystick variableJoystick;


     private Vector3 velocity = Vector3.zero;
    
 
    void FixedUpdate ()
    {
        if (GameManager.Instance.isCorrect)
        {
            Vector2 touchDeltaPosition = Vector2.zero;
        
            //touch movement
            if (Input.touchCount > 0)
            {
                // Get movement of the finger since last frame
                touchDeltaPosition = Input.GetTouch(0).deltaPosition * Touch_MovementSpeed;
            }
            Vector3 actualPosition = myRunners[0].transform.position;
            Vector3 target = new Vector3(actualPosition.x + touchDeltaPosition.x, actualPosition.y, actualPosition.z);
            myRunners[0].transform.position = Vector3.SmoothDamp(actualPosition, target, ref velocity, 1);

            MovementControls();

            //clamp
            if (myRunners[0].transform.position.x < -1.25f)
            {
                
                myRunners[0].transform.position = new Vector3(-1.25f,  myRunners[0].transform.position.y,  myRunners[0].transform.position.z);
               
            }
            if ( myRunners[0].transform.position.x > 1.25f)
            {
                myRunners[0].transform.position = new Vector3(1.25f,  myRunners[0].transform.position.y,  myRunners[0].transform.position.z);
            }
        }
    }




    private void MovementControls()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
                myRunners[0].transform.position -= new Vector3(1f, 0, 0) * Time.deltaTime * Touch_MovementSpeed;
                if (myRunners[0].transform.position.x < -1.25f)
                {
                    myRunners[0].transform.position = new Vector3(-1.25f,  myRunners[0].transform.position.y,  myRunners[0].transform.position.z);
                }
        }
        if (Input.GetKey(KeyCode.D))
        {
                myRunners[0].transform.position += new Vector3(1f, 0, 0) * Time.deltaTime * Touch_MovementSpeed;
                if ( myRunners[0].transform.position.x > 1.25f)
                {
                 myRunners[0].transform.position = new Vector3(1.25f,  myRunners[0].transform.position.y,  myRunners[0].transform.position.z);
                }
        }
    }

    
}
