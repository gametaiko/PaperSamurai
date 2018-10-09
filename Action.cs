using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum DISTANCE {far, almost, near}
public enum EMOTION  {normal, scare, hurt, careful, angry, crazy, happy}
public enum HEALTH   {normal, lostarm,lostfoot,losthead}

public class Action : MonoBehaviour {

    [Range(0, 10)]
    public float Near = 1;
    [Range(0, 10)]
    public float Almost = 2;
    public NavMeshAgent agent;
    public DISTANCE distance;
    public EMOTION emotion;
    public HEALTH health;
    public Transform target;
    // Use this for initialization
	void Start () {
        StartCoroutine(Check());
	}
	
    IEnumerator Check()
    {
        while(true)
        {
            distance = DISTANCE.far;
            if (Vector3.Distance(target.position, transform.position) < Almost) distance = DISTANCE.almost;
            if (Vector3.Distance(target.position, transform.position) < Near) distance = DISTANCE.near;

            GetComponent<Animator>().SetInteger("distance", (int)distance);
            GetComponent<Animator>().SetInteger("emotion",  (int)emotion);
            GetComponent<Animator>().SetInteger("health",   (int)health);

            yield return new WaitForSeconds(1);
        }
    }

    public void ChangeEmotion()
    {
        emotion = (EMOTION)Random.Range(0, System.Enum.GetValues(typeof(EMOTION)).Length);
    }

    public void Move()
    {
        agent.isStopped = false;
    }

    public void Stop()
    {
        agent.isStopped = true;
    }

    void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.yellow;
        UnityEditor.Handles.DrawWireDisc(transform.position, transform.up, Near);
        UnityEditor.Handles.color = Color.green;
        UnityEditor.Handles.DrawWireDisc(transform.position, transform.up, Almost);
        UnityEditor.Handles.Label(transform.position + transform.forward * Near, "NEAR LINE");
        UnityEditor.Handles.Label(transform.position + transform.forward * Almost, "ALMOST LINE");
    }

}
