using UnityEngine;
using System.Collections;

public class changeInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(sticks.leapIsEnabled == true)
			sticks.leapIsEnabled = false;
		//else
			//sticks.leapIsEnabled = true;
	
	}
}
