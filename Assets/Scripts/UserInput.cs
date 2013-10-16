using UnityEngine;
using System.Collections;

public class UserInput : MonoBehaviour {
	
	public static Vector2 touch1StartPosition;
	public static Vector2 touch1CurrentPosition;
	public static Vector2 touch1DeltaPosition;
	
	public static Vector2 touch2StartPosition;
	public static Vector2 touch2CurrentPosition;
	public static Vector2 touch2DeltaPosition;
	
	public static Vector2 curTouch;
	public static float curTouchDistance;
	public static float startTouchDistance;
	public static int curTouchCount;
	
	// Update is called once per frame
	void Update () {
		
		curTouchCount = Input.touchCount;
				
		if(curTouchCount > 0){
			
			touch1CurrentPosition = Input.touches[0].position;
			touch1DeltaPosition = Input.touches[0].deltaPosition;
			
			if(Input.touches[0].phase == TouchPhase.Began){
				touch1StartPosition = Input.touches[0].position;
			}
			
			if(Input.touches[0].phase == TouchPhase.Ended){
				touch1CurrentPosition = touch1DeltaPosition;
				touch1DeltaPosition = Vector2.zero;
			}
		}
		
		if(curTouchCount > 1){
			
			if(Input.touches[1].phase == TouchPhase.Began){
				touch2StartPosition = Input.touches[1].position;
				touch2CurrentPosition = Input.touches[1].position;
				startTouchDistance = Vector2.Distance(touch1CurrentPosition, touch2CurrentPosition);
			}
			
			if(Input.touches[1].phase == TouchPhase.Moved){
				touch2DeltaPosition = Input.touches[1].deltaPosition;
				touch2CurrentPosition = Input.touches[1].position;
				curTouchDistance = Vector2.Distance(touch1CurrentPosition, touch2CurrentPosition);
			}
			
			if(Input.touches[0].phase == TouchPhase.Ended){
				
			}
		}
	}
}
