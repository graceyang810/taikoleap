//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2013 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;
using System.Collections;


/// <summary>
/// Allows dragging of the specified target object by mouse or touch, optionally limiting it to be within the UIPanel's clipped rectangle.
/// </summary>

[AddComponentMenu("NGUI/Interaction/Drag Object")]
public class DragObject : IgnoreTimeScale
{
	public enum DragEffect
	{
		None,
		Momentum,
		MomentumAndSpring,
	}

	/// <summary>
	/// Target object that will be dragged.
	/// </summary>

	public Transform target;
	public  GameObject[] songs;
	public  GameObject targetPic;
	public int index;
	public int count;
	
	
	
	
	/// <summary>
	/// Scale value applied to the drag delta. Set X or Y to 0 to disallow dragging in that direction.
	/// </summary>

	public Vector3 scale = Vector3.one;

	/// <summary>
	/// Effect the scroll wheel will have on the momentum.
	/// </summary>

	public float scrollWheelFactor = 0f;

	/// <summary>
	/// Whether the dragging will be restricted to be within the parent panel's bounds.
	/// </summary>

	public bool restrictWithinPanel = false;

	/// <summary>
	/// Effect to apply when dragging.
	/// </summary>

	public DragEffect dragEffect = DragEffect.MomentumAndSpring;

	/// <summary>
	/// How much momentum gets applied when the press is released after dragging.
	/// </summary>

	public float momentumAmount = 35f;

	Plane mPlane;
	Vector3 mLastPos;
	UIPanel mPanel;
	bool mPressed = false;
	Vector3 mMomentum = Vector3.zero;
	float mScroll = 0f;
	Bounds mBounds;
	int [] order;
	int toward;
	
	//public Camera cam;
	public RaycastHit hit = new RaycastHit ();

	/// <summary>
	/// Find the panel responsible for this object.
	/// </summary>
	
	void Start () {
		//init the order
		order=new int[count];
		for(int n=0;n<count;n++)
			order[n]=n;
		bool i=true;
		//init the scale
		for(int m=0;m<count;m++)
		{
			songs[m].transform.localScale=new Vector3(0.003f,0.003f,0);
			TweenColor.Begin(songs[m], 0.2f, i ? Color.gray : Color.gray);
		
		}
		//speical in second songs ,scale bigger than other
		int p=order[1];
		songs[p].transform.localScale=new Vector3(0.0045f,0.0045f,0);
		TweenColor.Begin(songs[p], 0.2f, i ? Color.white : Color.white);
		
		
		//init the position
		for(int m=0;m<count;m++)
		{
			songs[m].transform.position=new Vector3(0.6f,(0.8f*(1-m)),0);
		}
		//init the alpha
		
	}
	void Update(){
		
//		Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
//		if(Input.GetMouseButtonDown(0)){
//			
//			if(Physics.Raycast(ray,out hit))
//			{	
//					if(hit.transform!=songs[0].transform && hit.transform!=songs[1].transform && hit.transform!=songs[2].transform)
//					{}
//					else{
//					int q0=order[0];
//					songs[q0].transform.Translate(0,-0.4f,0);
//					int q1=order[1];
//					songs[q1].transform.Translate(0,-0.4f,0);
//					//
//					int q2=order[2];
//					songs[q2].transform.Translate(0,0.8f,0);
//				   				
//					songs[q1].transform.localScale=new Vector3(0.003f,0.003f,0);
//					songs[q0].transform.localScale=new Vector3(0.0048f,0.0048f,0);
//					songs[q2].transform.localScale=new Vector3(0.003f,0.003f,0);		
//					for(int i=0;i<count;i++)
//					{
//						if(songs[i].transform==hit.transform )	
//						{
//						
//							int temp=order[count-1];	
//						 	for(int m=count-1;m>0;m--)
//							{						
//								order[m]=order[m-1]; 						
//														
//							}
//							order[0]=temp;	
//							break;
//						
//						}
//					
//					}
//				}				
//			}
//		}
		 
	}//nothing done
	
	
	void FindPanel ()
	{
		mPanel = (target != null) ? UIPanel.Find(target.transform, false) : null;
		if (mPanel == null) restrictWithinPanel = false;
	}

	/// <summary>
	/// Create a plane on which we will be performing the dragging.
	/// </summary>
	void OnPress (bool pressed)
	{
		
		if (enabled && NGUITools.GetActive(gameObject) && target != null)
		{
			mPressed = pressed;

			if (pressed)
			{
				if (restrictWithinPanel && mPanel == null) FindPanel();

				// Calculate the bounds
				if (restrictWithinPanel) mBounds = NGUIMath.CalculateRelativeWidgetBounds(mPanel.cachedTransform, target);

				// Remove all momentum on press
				mMomentum = Vector3.zero;
				mScroll = 0f;

				// Disable the spring movement
				SpringPosition sp = target.GetComponent<SpringPosition>();
				if (sp != null) sp.enabled = false;

				// Remember the hit position
				mLastPos = UICamera.lastHit.point;

				// Create the plane to drag along
				Transform trans = UICamera.currentCamera.transform;
				mPlane = new Plane((mPanel != null ? mPanel.cachedTransform.rotation : trans.rotation) * Vector3.back, mLastPos);
			}
			else if (restrictWithinPanel && mPanel.clipping != UIDrawCall.Clipping.None && dragEffect == DragEffect.MomentumAndSpring)
			{
				
				mPanel.ConstrainTargetToBounds(target, ref mBounds, false);
				
			}
			else
			{
					turnChanges(toward);//whether change the order or not
					formatPosition();	//put in right position
					formatScale();	//fit in rotation
					formatAlpha();		//fit in alpha
					showMessagePic();   //show the second songs Picture message
				
				
			}
		}
	}
	
	/// <summary>
	/// Drag the object along the plane.
	/// </summary>

	void OnDrag (Vector2 delta)
	{	
		
		if (enabled && NGUITools.GetActive(gameObject) && target != null)
		{
			UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;

			Ray ray = UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos);
			float dist = 0f;

			if (mPlane.Raycast(ray, out dist))
			{
				Vector3 currentPos = ray.GetPoint(dist);
				Vector3 offset = currentPos - mLastPos;
				mLastPos = currentPos;

				if (offset.x != 0f || offset.y != 0f)
				{
					offset = target.InverseTransformDirection(offset);
					offset.Scale(scale);
					offset = target.TransformDirection(offset);
				}

				// Adjust the momentum
				if (dragEffect != DragEffect.None) mMomentum = Vector3.Lerp(mMomentum, mMomentum + offset * (0.01f * momentumAmount), 0.67f);

				// We want to constrain the UI to be within bounds
				if (restrictWithinPanel)
				{
					// Adjust the position and bounds
					Vector3 localPos = target.localPosition;
					target.position += offset;
					mBounds.center = mBounds.center + (target.localPosition - localPos);

					// Constrain the UI to the bounds, and if done so, eliminate the momentum
					if (dragEffect != DragEffect.MomentumAndSpring && mPanel.clipping != UIDrawCall.Clipping.None &&
						mPanel.ConstrainTargetToBounds(target, ref mBounds, true))
					{
						mMomentum = Vector3.zero;
						mScroll = 0f;
					}
				}
				else
				{
					// Adjust the position	
					//target.position += offset;
					
				//	target.position +=new Vector3(0,offset.y,0);	
					offset.y=Rnd(offset.y,100);
												
					//songs follow the mouse moveing 
					if(offset.y>0)//toward up
					{
						toward=1;
						for(int k=count-1;k>-1;k--)
						{
							int p=order[k];							
						
							songs[p].transform.position+=new Vector3(0,offset.y,0);	
							
						//	TweenScale.Begin(songs[p],0.2f,new Vector3(offset.y*10+0.003f,offset.y*10+0.003f,0));
						}
												
					}
					else//toward down
					{
						toward=-1;
						for(int k=0;k<count;k++)
						{
							int p=order[k];	
					
							songs[p].transform.position+=new Vector3(0,offset.y,0);							
							
							
						}
									
					}
					
									
				}
			}
		}
		
		
	}
	void turnChanges(int flag)//change the order
	{
		if(flag==-1)//toward down	
		{
			int temp=order[count-1];	
			for(int m=count-1;m>0;m--)
			{						
				order[m]=order[m-1]; 						
														
			}
			order[0]=temp;	
		}
		else if(flag==1)//toward up
		{
			int temp=order[0];	
			for(int m=0;m<count-1;m++)
			{						
				order[m]=order[m+1]; 						
														
			}
			order[count-1]=temp;
		}
		else
		{			
		}
		toward=0;	//avoid when click the panel, change the order			
	}
	void formatPosition()
	{
//		float t=tar.localPosition.y;
		//tar.position
//		if(tar.position.y<-0.4f || (tar.position.y>-0.4f && tar.position.y<-0.25f))
//			tar.position=new Vector3(target.position.x,-0.4f,0);
//			tar.localPosition=new Vector3(tar.position.x,-0.4f,0);
//		else if(tar.position.y>0.4f || tar.position.y<0.4f && tar.position.y>0.25f)
//			tar.position=new Vector3(tar.position.x,0.4f,0);
//		else
//			tar.position=new Vector3(tar.position.x,0.0f,0);
//		Debug.Log(target.position.y);
		
		for(int m=0;m<count;m++)
		{
			int t=order[m];
			float a=Rnd(0.5f*(1-m),10);
			songs[t].transform.position=new Vector3(songs[t].transform.position.x,a,0);
			
		}// in order, in his right position
		
		
	}
	void formatScale()//fit in Scale
	{
		for(int m=0;m<count;m++)
		{
			int t=order[m];
			songs[t].transform.localScale=new Vector3(0.003f,0.003f,0);	
		}	
		int q=order[1];
		songs[q].transform.localScale=new Vector3(0.0045f,0.0045f,0);	
		//TweenScale.Begin(songs[1],0.2f,new Vector3(0.0045f,0.0045f,0));
		

	}
	void formatAlpha()//fit in rotation
	{
		bool i=true;
		for(int m=0;m<count;m++)
		{
			int t=order[m];
			
			TweenColor.Begin(songs[t], 0.2f, i ? Color.gray : Color.gray);//all songs set gray			
		}
		int q=order[1];	
		Color mColor;
		UIWidget widget = songs[q].GetComponent<UIWidget>();		
		if (widget != null)
		{
			mColor = widget.color;
		}
		mColor=new Color(1f,1f,1f,1f);
		TweenColor.Begin(songs[q], 0.2f, i ? mColor : Color.gray);//the second songs is lighter
	}
	void showMessagePic()//show the second songs Picture message
	{
		int p=order[1];
	//	songs[p].
	//	targetPic.GetComponent<UISprite>().spriteName="";
		UISprite sprite = targetPic.GetComponent<UISprite>();
		if(songs[p].name=="ChristSongs")
		sprite.spriteName = "songDescription3";
		if(songs[p].name=="hungSongs")
		sprite.spriteName = "songDescription39";
		if(songs[p].name=="silentSongs")
		sprite.spriteName = "songDescription4";
		
	}
	 float Rnd(float f,int bei)//seve the dot in n number(10^n=bei)
    {
        float temp = f - (int)f;
        temp *= bei;
        int tempInt = (int)temp;
        return (int)f + (float)tempInt / bei;
    }
	/// <summary>
	/// Apply the dragging momentum.
	/// </summary>

	void LateUpdate ()
	{
		float delta = UpdateRealTimeDelta();
		if (target == null) return;

		if (mPressed)
		{
			// Disable the spring movement
			SpringPosition sp = target.GetComponent<SpringPosition>();
			if (sp != null) sp.enabled = false;
			mScroll = 0f;
		}
		else
		{
			mMomentum += scale * (-mScroll * 0.05f);
			mScroll = NGUIMath.SpringLerp(mScroll, 0f, 20f, delta);

			if (mMomentum.magnitude > 0.0001f)
			{
				// Apply the momentum
				if (mPanel == null) FindPanel();

				if (mPanel != null)
				{
					//target.position += NGUIMath.SpringDampen(ref mMomentum, 9f, delta);
					target.position += new Vector3(0,NGUIMath.SpringDampen(ref mMomentum, 9f, delta).y,0);

					if (restrictWithinPanel && mPanel.clipping != UIDrawCall.Clipping.None)
					{
						mBounds = NGUIMath.CalculateRelativeWidgetBounds(mPanel.cachedTransform, target);
						
						if (!mPanel.ConstrainTargetToBounds(target, ref mBounds, dragEffect == DragEffect.None))
						{
							SpringPosition sp = target.GetComponent<SpringPosition>();
							if (sp != null) sp.enabled = false;
						}
					}
					return;
				}
			}
			else mScroll = 0f;
		}

		// Dampen the momentum
		NGUIMath.SpringDampen(ref mMomentum, 9f, delta);
	}

	/// <summary>
	/// If the object should support the scroll wheel, do it.
	/// </summary>

	void OnScroll (float delta)
	{
		if (enabled && NGUITools.GetActive(gameObject))
		{
			if (Mathf.Sign(mScroll) != Mathf.Sign(delta)) mScroll = 0f;
			mScroll += delta * scrollWheelFactor;
			Debug.Log("hha");
		}
	}
}