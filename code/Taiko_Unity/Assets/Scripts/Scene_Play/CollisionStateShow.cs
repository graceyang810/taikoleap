using UnityEngine;
using System.Collections;

public class CollisionStateShow : MonoBehaviour {
	
	public enum CollisionState{
		init,
		perfect,
		cool,
		miss,
	}
	
	public static CollisionState collisionState;
	
	private Vector3 scale1;// init scale 
	private Vector3 scale2;//final scale
	private float positionY1;
	private float positionY2;
	private float transparency1;
	private float transparency2;
	
	private Vector3 tempScale;
	private float tempPositionY;
	private float tempTransparency;
	
	private int animationTime;
	private int tempTime;
	private bool animationState;
	
	private Vector3 speedScale;
	private float speedPosition;
	private float speedTransparency;
	
	private UISprite stateShow;
	
		
	// Use this for initialization
	void Start () {
		
		stateShow = gameObject.GetComponent<UISprite>();
		
		//define the time of animation
		animationTime = 30;
		tempTime = 0;
		
		//define the range of changes
		scale1 = new Vector3(0.1f , 0.1f , 0.1f);
		positionY1 = gameObject.transform.localPosition.y;
		transparency1 = 1.0f;
		
		scale2 = new Vector3(100.0f , 100.0f , 100.0f);
		positionY2 = positionY1 + 0.2f;
		transparency2 = 0.0f;
		
		tempScale = scale1;
		tempPositionY = positionY1;
		tempTransparency = transparency1;
		
		//define the speed of change
		speedScale = (scale2 - scale1) / animationTime;
		speedPosition = (positionY2 - positionY1) / animationTime;
		speedTransparency = (transparency2 - transparency1) / animationTime;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		setSprite();
		
		if(collisionState != CollisionState.init){
			
			animationState = true;
//			collisionState = CollisionState.init;
		}
/*		
		if(tempScale < scale2){
			tempScale += new Vector3(speedScale*Time.deltaTime , speedScale*Time.deltaTime , speedScale*Time.deltaTime);
			gameObject.transform.localScale = tempScale;
		}
		
*/
		if(animationState){
			Debug.Log(collisionState);
			
			if(tempTime < animationTime){
				//scale
				tempScale += speedScale * Time.deltaTime;
				gameObject.transform.localScale = tempScale;
				//position
//				tempPositionY += speedPosition*Time.deltaTime;
				gameObject.transform.Translate(new Vector3(0 , speedPosition*Time.deltaTime , 0));
				//tranparency
				tempTransparency += speedTransparency *Time.deltaTime;
				stateShow.alpha = tempTransparency;
				
				tempTime++;
			}
			else{
				animationState = false;
				collisionState = CollisionState.init;
				resetTemp();
			}
		}
	}
	
	void setSprite() {
		switch(collisionState){
		case CollisionState.perfect:
			stateShow.spriteName = "perfect";
			break;
		case CollisionState.cool:
			stateShow.spriteName = "cool";
			break;
		case CollisionState.miss:
			stateShow.spriteName = "miss";
			break;
		default:
			stateShow.spriteName = "empty";
			break;
		}
	}
	
	void resetTemp() {
		tempTime = 0;
		tempScale = scale1;
		tempPositionY = positionY1;
		tempTransparency = transparency1;
	}
}
















