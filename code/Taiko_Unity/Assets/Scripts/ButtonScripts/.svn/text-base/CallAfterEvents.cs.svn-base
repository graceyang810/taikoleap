using UnityEngine;
using System.Collections;

public class CallAfterEvents : MonoBehaviour {
	
	public enum InputEvent{
		OnMouseOver,
		OnPress,
	}
	
	public InputEvent inputEvent = InputEvent.OnMouseOver;
	
	public GameObject eventReceiver;
	public string callAfterEvent;
	
	private bool eventReceived;

	/*
	private enum State{
		Idle,
		Hover,
		Pressed,
	}
	
	private State state;
	
	*/
	
	// Use this for initialization
	void Start () {
		
//		state = State.Idle;
		eventReceived = false;
		eventReceiver = null;
		callAfterEvent = null;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(eventReceived)
			// Notify the event listener target
			if (eventReceiver != null && !string.IsNullOrEmpty(callAfterEvent))
			{
				eventReceiver.SendMessage(callAfterEvent, this, SendMessageOptions.DontRequireReceiver);
			}

	
	}
	
	void OnClick() {
		if(inputEvent == InputEvent.OnPress){
//			state = State.Pressed;
			eventReceived = true;
		}
	}
	
	void OnHover() {
		if(inputEvent == InputEvent.OnMouseOver)
			eventReceived = true;
	}
}
