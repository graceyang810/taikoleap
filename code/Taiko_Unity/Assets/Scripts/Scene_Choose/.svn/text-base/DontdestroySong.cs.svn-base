using UnityEngine;
using System.Collections;

public class DontdestroySong : MonoBehaviour {

	public enum Trigger
	{
		OnClick,
		OnMouseOver,
		OnMouseOut,
		OnPress,
		OnRelease,
	}

	public string levelName;
	public AudioSource s1;
	public Trigger trigger = Trigger.OnClick;
	public float volume = 1f;
	public float pitch = 1f;
	public bool isDo=false;
	void Update(){
		if(isDo==true && !s1.isPlaying )
		{
			Application.LoadLevel(levelName);	
		}
		
		 
	}
	
	void OnHover (bool isOver)
	{
		if (enabled && ((isOver && trigger == Trigger.OnMouseOver) || (!isOver && trigger == Trigger.OnMouseOut)))
		{
		
			s1.Play();
		}
	}

	void OnPress (bool isPressed)
	{
		if (enabled && ((isPressed && trigger == Trigger.OnPress) || (!isPressed && trigger == Trigger.OnRelease)))
		{
			s1.Play();
		}
	}

	void OnClick ()
	{
		if (enabled && trigger == Trigger.OnClick)
		{
			s1.Play();
			isDo=true;
		}
	}
}
