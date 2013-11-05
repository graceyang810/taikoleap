//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2013 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Plays the specified sound.
/// </summary>

[AddComponentMenu("NGUI/Interaction/Button Sound")]
public class Letgo : MonoBehaviour
{
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
	public AudioSource s2;
	public Trigger trigger = Trigger.OnClick;
	public float volume = 1f;
	public float pitch = 1f;
	public bool isDo=false;
	void Update(){
		if(isDo==true && !s1.isPlaying && !s2.isPlaying)
		{
			Application.LoadLevel(levelName);	
		}
		
		 
	}
	
	void OnHover (bool isOver)
	{
		if (enabled && ((isOver && trigger == Trigger.OnMouseOver) || (!isOver && trigger == Trigger.OnMouseOut)))
		{
		
			s1.Play();
			s2.Play();
		}
	}

	void OnPress (bool isPressed)
	{
		if (enabled && ((isPressed && trigger == Trigger.OnPress) || (!isPressed && trigger == Trigger.OnRelease)))
		{
			s1.Play();
			s2.Play();
		}
	}

	void OnClick ()
	{
		if (enabled && trigger == Trigger.OnClick)
		{
			s1.Play();
			s2.Play();
			isDo=true;
		}
	}
}