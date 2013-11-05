using UnityEngine;
using System.Collections;

public class DotsCollision : MonoBehaviour {
	
	private bool collisionHandled;//one dot 
	
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
			
		distance = gameObject.transform.position.x - target.transform.position.x;
		
		if(DrumBeaten.beatenYellow){
			drumBeatenEvent = DrumBeatenEvent.YellowBeaten;
			DrumBeaten.beatenHandled = true;}
		else if(DrumBeaten.beatenRed){
			drumBeatenEvent = DrumBeatenEvent.RedBeaten;
			DrumBeaten.beatenHandled = true;}
		
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
		
			
		switch(collisionState){
			case CollisionState.perfect:
				DrumBeaten.HitCount++;
				gameObject.GetComponent<UISprite>().spriteName = "empty";
				ResultData.Count_Perfect++;
				CollisionStateShow.collisionState = CollisionStateShow.CollisionState.perfect;
				break;
			case CollisionState.cool:
				DrumBeaten.HitCount++;
				gameObject.GetComponent<UISprite>().spriteName = "empty";
				ResultData.Count_Cool++;
				CollisionStateShow.collisionState = CollisionStateShow.CollisionState.cool;
				break;
			case CollisionState.miss:
				if(DrumBeaten.HitCount > ResultData.MaxCombo)
					ResultData.MaxCombo = DrumBeaten.HitCount;
				DrumBeaten.HitCount = 0;
				ResultData.Count_Miss++;
				CollisionStateShow.collisionState = CollisionStateShow.CollisionState.miss;
				break;
			default:
				CollisionStateShow.collisionState = CollisionStateShow.CollisionState.init;
				break;
			}
		
		if(collisionState != CollisionState.init){
				
			collisionHandled = true;
		}
				
		drumBeatenEvent = DrumBeatenEvent.Idle;
		collisionState = CollisionState.init;
		
		}
	}
}





















