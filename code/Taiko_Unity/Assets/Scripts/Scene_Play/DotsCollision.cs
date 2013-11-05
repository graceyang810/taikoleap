using UnityEngine;
using System.Collections;

public class DotsCollision : MonoBehaviour {
	
	public bool collisionHandled;//one dot 
	
	public enum DotType{
		yellow,
		red,
		bothColor,
	}
	
	public enum DrumBeatenEvent{
		Idle,
		YellowBeaten,
		RedBeaten,
	}
	
	public enum CollisionState{
		init,
		cool,
		perfect,
		miss,
	}
	
//	private float BoundaryOut;
	private float BoundaryCool_right;
	private float BoundaryPerfect_right;
	private float BoundaryPerfect_left;
	private float BoundaryCool_left;
//	private float BoundaryMiss;
		
	public GameObject  target;
	public DotType dotType;
	
	public DrumBeatenEvent drumBeatenEvent;
		
	private float distance;
	private CollisionState collisionState;
	
	// Use this for initialization
	void Start () {
		
		target = GameObject.Find("Dots_Target");
		drumBeatenEvent = DrumBeatenEvent.Idle;
		collisionState = CollisionState.init;
			
//		BoundaryOut = 50.0f;
		BoundaryCool_right = 0.15f;
		BoundaryPerfect_right = 0.05f;
		BoundaryPerfect_left = -0.05f;
		BoundaryCool_left = -0.15f;
//		BoundaryMiss = -50.0f;
		
		collisionHandled = false;
		
		
		
	}
	
	// Update is called once per frame
	void Update () {			
		if(!collisionHandled){//the dot has not been handled
			Debug.LogError(gameObject.GetComponent<UISprite>().spriteName+ ":"+ gameObject.transform.position.x);			
			distance = gameObject.transform.position.x - target.transform.position.x;
			Debug.LogError(gameObject.GetComponent<UISprite>().spriteName+ " distance:"+ distance);
		
			if(DrumBeaten.beatenYellow){
				drumBeatenEvent = DrumBeatenEvent.YellowBeaten;
				Debug.Log("beat yellow");
				}
			if(DrumBeaten.beatenRed){
				drumBeatenEvent = DrumBeatenEvent.RedBeaten;
				Debug.Log("beat red");
				}
			
		if((dotType == DotType.yellow) && (drumBeatenEvent == DrumBeatenEvent.YellowBeaten))
		{
			if((distance < BoundaryCool_right) && (distance > BoundaryPerfect_right))
				collisionState = CollisionState.cool;
			else if((distance < BoundaryPerfect_right) && (distance > BoundaryPerfect_left))
				collisionState = CollisionState.perfect;
			else if((distance < BoundaryPerfect_left) && (distance > BoundaryCool_left))
				collisionState = CollisionState.cool;
				
		}
		else if((dotType == DotType.red) && (drumBeatenEvent == DrumBeatenEvent.RedBeaten))
		{
			if((distance < BoundaryCool_right) && (distance > BoundaryPerfect_right))
				collisionState = CollisionState.cool;
			else if((distance < BoundaryPerfect_right) && (distance > BoundaryPerfect_left))
				collisionState = CollisionState.perfect;
			else if((distance < BoundaryPerfect_left) && (distance > BoundaryCool_left))
				collisionState = CollisionState.cool;
			
		}
		
		if(distance < BoundaryCool_left)
			collisionState = CollisionState.miss;
		
		if(collisionState != CollisionState.init && collisionState != CollisionState.miss){
			
			DrumBeaten.HitCount++;
			gameObject.GetComponent<UISprite>().spriteName = "empty";
			
			collisionHandled = true;
		}
		
		if(collisionState == CollisionState.miss){
				
			collisionHandled = true;
	//		DrumBeaten.HitCount = 0;
		}
		
		if(drumBeatenEvent != DrumBeatenEvent.Idle){
//			Debug.Log(drumBeatenEvent);
//			Debug.Log(distance);
//			Debug.Log(collisionState);
		}
		
		
		drumBeatenEvent = DrumBeatenEvent.Idle;
		collisionState = CollisionState.init;
		DrumBeaten.beatenHandled = true;
		
		}
	}
}





















