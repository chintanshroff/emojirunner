using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runner_gate : MonoBehaviour
{
    public bool isCorrect;
    public Renderer gate_rend;

    public runner myTpose;

    public Vector3 offset;
   public float smoothSpeed = 0.125f;

   public bool isAttached = false;

   private void LateUpdate() 
   {
       if (isAttached)
    {
         Vector3 desiredPos = GameManager.Instance.myRunner.myRunners[0].transform.position + offset;
            Vector3 smoothedPos = Vector3.Lerp (transform.position, desiredPos, smoothSpeed);
            transform.position = new Vector3(smoothedPos.x, transform.position.y,  transform.position.z ) ;
            
    }

           
       
   }
    public void AttachToRunner()
    {
        if(isCorrect)
        {
            GameManager.Instance.myRunner.followerPos.localPosition = new Vector3(0 ,0,GameManager.Instance.myRunner.followerPos.localPosition.z+0.02f);
             Debug.Log("Attach");
             transform.parent = GameManager.Instance.myRunner.transform;
             transform.position = GameManager.Instance.myRunner.followerPos.position;
             transform.rotation =  GameManager.Instance.myRunner.followerPos.rotation;
             GameManager.Instance.myRunner.myRunners.Add(myTpose);
             isAttached = true;
        }
        else if(!isCorrect)
        {
            Debug.Log("incorrect");
            GameManager.Instance.isCorrect = false;
        } 
    }
}

