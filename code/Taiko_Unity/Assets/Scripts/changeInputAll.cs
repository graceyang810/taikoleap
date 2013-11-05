using UnityEngine;
using System.Collections;

public class changeInputAll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(sticks.leapIsEnabled == false)
			sticks.leapIsEnabled = true;
		else
			sticks.leapIsEnabled = false;
	
	}
}
