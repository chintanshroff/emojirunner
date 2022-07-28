using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runner_colliderScript : MonoBehaviour
{
   
     public runner myRunnerScript;
     public bool hasInteractedWithGates = false;

     void OnTriggerEnter(Collider c)
    {
        if (myRunnerScript.runnerCount == 0)
        {
            if (c.gameObject.tag == "Gate")
            {
                if (!hasInteractedWithGates)
                {
                    hasInteractedWithGates = true;
                    runner_gate runnerGate =  c.gameObject.GetComponentInParent<runner_gate>();
                    if (!runnerGate.myRunnerScript.isAttached)
                    {
                        runnerGate.AttachToRunner();
                        //runnerGate.myRunnerScript.isAttached = true;
                    }
                }
            }
            else if (c.gameObject.tag == "?")
            {
                Debug.Log("?");
                GameManager.Instance.platform_list[GameManager.Instance.platform_list.Count-1].GetRandomEmoji();
                hasInteractedWithGates = false;
            }       
            else if (c.gameObject.tag == "Coin")
            {
              StartCoroutine(MoveToPosition(c.transform, new Vector3(0f,5f,0f),0.5f));
            }    
        }
    }

    public IEnumerator MoveToPosition(Transform _transform, Vector3 position, float timeToMove)
    {
        Vector3 currentPos = _transform.position;
        float t = 0f;

        while (t < 1)
        {
            t += Time.deltaTime/timeToMove;
            _transform.position = Vector3.Lerp(currentPos, position,t);
            yield return null;
          
        }
        _transform.gameObject.SetActive(false);
        
         
    }
}
