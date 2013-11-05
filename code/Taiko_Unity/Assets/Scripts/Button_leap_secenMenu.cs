using UnityEngine;
using System.Collections;

public class Button_leap_secenMenu : MonoBehaviour {
	public GameObject cursor;
	private float distanceX;
	private float distanceY;
	
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	if(sticks.leapIsEnabled)  
        { 
			cursor = GameObject.Find("stick");
			//Debug.Log("find stick in leapstate");
			leaphover();
			//Debug.LogError(pxsLeapInput.GetHandAxis("Vertical"));
		} else{
			cursor = GameObject.Find("stick");
			Debug.Log("find stick in mousestate");
		}
		
	}		

	void leaphover(){
		distanceX = Mathf.Abs(transform.position.x - pxsLeapInput.GetHandAxis("Horizontal")+0.1f) -0.2f;
		distanceY = Mathf.Abs(transform.position.y - pxsLeapInput.GetHandAxis("Depth")+ 0.1f)- 0.12f;
		
		if(distanceY <= 0.1f && distanceX <= 0.1f){
			//Debug.Log ("leap is hover");	
			transform.localScale = new Vector3(1.2f, 3.0f, 0);
		}
		else{
			transform.localScale = new Vector3(1.0f, 2.5f, 0);
		}
	}
}
