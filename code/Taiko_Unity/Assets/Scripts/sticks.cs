using UnityEngine;
using System.Collections;

public class sticks : MonoBehaviour {
    public bool leapIsEnabled = false;  
	public float positionX;
	public float positionY;
	//public Transform target;
	

	// Use this for initialization
	//void Start () {
	//	Screen.showCursor = false;	
	//}
	
	void Update () {
		//var screenPos = camera.WorldToScreenPoint (target.position);  
		//print ("target is " + screenPos.x + " pixels from the left");  
		if(leapIsEnabled)  
        { 
			positionX = pxsLeapInput.GetHandAxis("Horizontal")*1.8f;
			positionY = pxsLeapInput.GetHandAxis("Depth")-0.5f;			
			Debug.Log (pxsLeapInput.GetHandAxis("Depth"));
			transform.position = new Vector3(positionX, positionY, 0);
		}
		else{
			Vector3 pos = Input.mousePosition;
			
			pos.x = Mathf.Clamp01(pos.x / Screen.width)*5.0f;
			pos.y = Mathf.Clamp01(pos.y / Screen.height)*2.0f;
			
			positionX= pos.x -2.5f;
			positionY= pos.y-1.0f;
			transform.position = new Vector3(positionX, positionY, 0);
		}
	}
}
