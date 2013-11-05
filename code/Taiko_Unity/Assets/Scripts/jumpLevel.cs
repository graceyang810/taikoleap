using UnityEngine;
using System.Collections;

public class jumpLevel : MonoBehaviour {
	private float heightOK;
	public string levelName;
	public float distanceX;
	public float distanceY;
	public int	time = 0;
	public static float currentX = 0.0f;
	public static float currentY = 0.0f;
	public string currentObject = null;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(sticks.leapIsEnabled)  
        { 	
			distanceX = Mathf.Abs(transform.position.x - pxsLeapInput.GetHandAxis("Horizontal")+0.1f) -0.2f;
			distanceY = Mathf.Abs(transform.position.y - pxsLeapInput.GetHandAxis("Depth")+ 0.1f)- 0.12f;
			if(distanceY <= 0.1f && distanceX <= 0.1f){
			heightOK = pxsLeapInput.GetHandAxis("Vertical");
			Debug.Log(heightOK + gameObject.name);	
			time++;
			Debug.Log(time);
			}				
			if(time > 100){
				Debug.Log(heightOK);		
				Application.LoadLevel(levelName);
				currentX = pxsLeapInput.GetHandAxis("Horizontal")*1.8f;
				currentY = pxsLeapInput.GetHandAxis("Depth");
				}
		}
	
	}
}
