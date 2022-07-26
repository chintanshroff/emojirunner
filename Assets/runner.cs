using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runner : MonoBehaviour
{
  

   public Renderer my_rend;
public int runnerCount;

 public bool isAttached = false;

   public float smoothSpeed = 0.05f;

   private Transform target;
   
 private void LateUpdate() 
   {
        if (GameManager.Instance.isCorrect)
        {
            if (isAttached)
            {
                if (runnerCount>0)
                {
                   
                    target =  GameManager.Instance.myRunner_container.myRunners[runnerCount-1].transform;
                    Vector3 desiredPos = target.position;
                    Vector3 smoothedPos = Vector3.Lerp (transform.position, desiredPos, smoothSpeed);
                    transform.position = new Vector3(smoothedPos.x, transform.position.y,  transform.position.z ) ;
                }
            }
        }
   }
   
     public IEnumerator MoveToPosition(float timeToMove, float distanceToMove)
    {
        Vector3 currentPos = transform.localPosition;
        Vector3 targetPos = currentPos+new Vector3(0,0,distanceToMove);
        float t = 0f;

        while (t < 1)
        {
            t += Time.deltaTime/timeToMove;
            transform.localPosition = Vector3.Lerp(currentPos, targetPos,t);
            yield return null;
          
        }
         
    }

    public void MoveStepBackwards()
    {
        StartCoroutine(MoveToPosition(0.5f, 0.02f));
    }

     public void MoveStepForward()
    {
        StartCoroutine(MoveToPosition(0.5f, -0.02f));
    }
}
   

  