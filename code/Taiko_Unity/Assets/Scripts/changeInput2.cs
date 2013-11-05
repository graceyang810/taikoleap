using UnityEngine;
using System.Collections;

public class changeInput2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(sticks.leapIsEnabled == false)
			sticks.leapIsEnabled = true;
		//else
			//sticks.leapIsEnabled = true;
	
	}
}
