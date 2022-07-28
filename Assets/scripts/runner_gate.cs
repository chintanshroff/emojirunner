using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runner_gate : MonoBehaviour
{
    public bool isCorrectGate;
    

    public runner myTpose;

    private Transform target;
   public float smoothSpeed = 0.05f;

   public bool isAttached = false;
   

   public runner myRunnerScript;

   public GameObject myGateCollider;

   private GameObject LastKickedRunner;

private void Awake() 
{
   myRunnerScript = this.GetComponent<runner>(); 
}
   private void LateUpdate() 
   {
        if (GameManager.Instance.isCorrect)
        {
            if (isAttached)
            {
                if (myRunnerScript.runnerCount>0)
                {
                    
                    target =  GameManager.Instance.myRunner_container.myRunners[myRunnerScript.runnerCount-1].transform;
                    Vector3 desiredPos = target.position;
                    Vector3 smoothedPos = Vector3.Lerp (transform.position, desiredPos, smoothSpeed);
                    transform.position = new Vector3(smoothedPos.x, transform.position.y,  transform.position.z ) ;
                }
            }
        }
   }
    public void AttachToRunner()
    {
        if(isCorrectGate)
        {
            isAttached = true;
            myGateCollider.SetActive(false);
            GameManager.Instance.myRunner_container.followerPos.localPosition = new Vector3(GameManager.Instance.myRunner_container.myRunners[0].transform.localPosition.x ,GameManager.Instance.myRunner_container.myRunners[0].transform.localPosition.y, GameManager.Instance.myRunner_container.followerPos.localPosition.z+0.02f);
            Vector3 targetPos = GameManager.Instance.myRunner_container.followerPos.position;
            StartCoroutine(MoveToPosition_add(transform, targetPos,0.5f));
            
            //transform.position = GameManager.Instance.myRunner.followerPos.position;

        }
        else if(!isCorrectGate)
        {
            Debug.Log("incorrect");
           Transform firstRunner =  GameManager.Instance.myRunner_container.myRunners[0].transform;
           StartCoroutine(MoveToPosition_remove(firstRunner, new Vector3(0f,15f,0f),0.5f));

            GameManager.Instance.myRunner_container.followerPos.localPosition = new Vector3(GameManager.Instance.myRunner_container.myRunners[0].transform.localPosition.x ,GameManager.Instance.myRunner_container.myRunners[0].transform.localPosition.y, GameManager.Instance.myRunner_container.followerPos.localPosition.z-0.02f);
           
            
            for (int i = 0; i < GameManager.Instance.myRunner_container.myRunners.Count; i++)
            {
                GameManager.Instance.myRunner_container.myRunners[i].runnerCount -= 1;
            }
            //LastKickedRunner = GameManager.Instance.myRunner_container.myRunners[0].GetComponent<GameObject>();
            GameManager.Instance.myRunner_container.myRunners.RemoveAt(0);
            
           
            if ( GameManager.Instance.myRunner_container.myRunners.Count == 0)
            {
                GameManager.Instance.isCorrect = false;
                GameManager.Instance.GameOverPanel.SetActive(true); 
            }

            for (int i = 0; i < GameManager.Instance.myRunner_container.myRunners.Count; i++)
            {
               GameManager.Instance.myRunner_container.myRunners[i].MoveStepBackwards();
            }
            


        } 
    }

    

    public IEnumerator MoveToPosition_add(Transform _transform, Vector3 position, float timeToMove)
    {
        
        

        //yield return new WaitForSeconds(.2f);
       
        Debug.Log("Attach");
        transform.parent = GameManager.Instance.myRunner_container.transform;
        transform.rotation =  GameManager.Instance.myRunner_container.followerPos.rotation;
        GameManager.Instance.myRunner_container.myRunners.Add(myTpose);
        myRunnerScript.runnerCount =  GameManager.Instance.myRunner_container.myRunners.Count-1;

        Vector3 currentPos = _transform.position;
        float t = 0f;

        while (t < 1)
        {
            t += Time.deltaTime/timeToMove;
            _transform.position = Vector3.Lerp(currentPos, position,t);
            yield return null;
          
        }
        
        
         
    }

     public IEnumerator MoveToPosition_remove(Transform _transform, Vector3 position, float timeToMove)
    {
        

        Vector3 currentPos = _transform.position;
        float t = 0f;

        while (t < 1)
        {
            t += Time.deltaTime/timeToMove;
            _transform.position = Vector3.Lerp(currentPos, position,t);
            yield return null;
          
        }
        
        
         
    }
}

