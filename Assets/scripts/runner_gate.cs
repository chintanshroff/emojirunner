using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runner_gate : MonoBehaviour
{
    public bool isCorrectGate;
    

    public runner myTpose;

    
  
  
   

   public runner myRunnerScript;

   public GameObject myGateCollider;

   private GameObject LastKickedRunner;

private void Awake() 
{
   myRunnerScript = this.GetComponent<runner>(); 
}
  
    public void AttachToRunner()
    {
        if(isCorrectGate)
        {
            GameManager.Instance.myRunner_container.myRunners[0].isAttached = true; 
            //myRunnerScript.isAttached = true;
            myGateCollider.SetActive(false);
            GameManager.Instance.myRunner_container.followerPos.localPosition = new Vector3(GameManager.Instance.myRunner_container.myRunners[0].transform.localPosition.x ,GameManager.Instance.myRunner_container.myRunners[0].transform.localPosition.y, GameManager.Instance.myRunner_container.followerPos.localPosition.z+0.02f);
             Debug.Log("Attach");
            transform.parent = GameManager.Instance.myRunner_container.transform;
            transform.rotation =  GameManager.Instance.myRunner_container.followerPos.rotation;
            Vector3 targetPos = GameManager.Instance.myRunner_container.myRunners[0].transform.position;
            GameManager.Instance.myRunner_container.myRunners.Insert(0,myTpose);
            //myRunnerScript.runnerCount =  GameManager.Instance.myRunner_container.myRunners.Count-1;
            
            
            //Vector3 targetPos = GameManager.Instance.myRunner_container.followerPos.position;
           
            StartCoroutine(MoveToPosition_add(transform, targetPos,0.5f));

            for (int i = 0; i < GameManager.Instance.myRunner_container.myRunners.Count; i++)
            {
                GameManager.Instance.myRunner_container.myRunners[i].runnerCount = i;
                if (GameManager.Instance.myRunner_container.myRunners[i].runnerCount > 0)
                {
                    GameManager.Instance.myRunner_container.myRunners[i].MoveStepBackwards();
                }
               
            }
            
            //transform.position = GameManager.Instance.myRunner.followerPos.position;

        }
        else if(!isCorrectGate)
        {
            Debug.Log("incorrect");
           Transform firstRunner =  GameManager.Instance.myRunner_container.myRunners[0].transform;
           StartCoroutine(MoveToPosition_remove(firstRunner, new Vector3(0f,15f,0f),2f));

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
               GameManager.Instance.myRunner_container.myRunners[i].MoveStepForward();
            }
            


        } 
    }

    

    public IEnumerator MoveToPosition_add(Transform _transform, Vector3 position, float timeToMove)
    {
        
        

        //yield return new WaitForSeconds(.2f);
       
       

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

