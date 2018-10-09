using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Action))]
public class Behaviour : MonoBehaviour {

    Action action;
	// Use this for initialization
	void Start () {
        action = GetComponent<Action>();	
	}
	
    // Update is called once per frame
    void Update()
    {
        
    }
}
