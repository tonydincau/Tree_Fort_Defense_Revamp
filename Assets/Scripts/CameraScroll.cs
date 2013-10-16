using UnityEngine;
using System.Collections;

public class CameraScroll : MonoBehaviour {
	
	//NUMBERS//
	private float scrollXSpeed = 0.035f;
	private float scrollYSpeed = 0.06f;
	private int screenWidth;
	private int screenHeight;

	//BOOLS//
	public bool oneTouch = false;
	public bool twoTouch = false;
	public bool scrolling = false;
	
	//GAMEOBJECTS//
	public GameObject cameraTarget;
	public GameObject mainController;
	private UserInput UserInputRef;
	
	private float minFOV = 13f;
	private float maxFOV = 20f;
	private float zoomPercentage = 0.0f;
	
	//RAYS//
	private Ray shootRay;
	private RaycastHit hitRay;
    
	void Start(){
		
		//Create reference to the UserInput script
		UserInputRef = mainController.GetComponent<UserInput>() as UserInput;
		
		//Store the screen width and height in corresponding variables
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		
		//Move the camera target to the camera's location to prevent popping
		cameraTarget.transform.position = transform.position;
		
		//Set the standardized scroll speed based on screen size
		scrollXSpeed = screenWidth*scrollXSpeed;
		scrollYSpeed = screenHeight*scrollYSpeed;
	}
	
	void Update(){
		zoomPercentage = ((Camera.main.fieldOfView-minFOV) / (maxFOV-minFOV)*100);
		Debug.Log (zoomPercentage);
		cameraTarget.transform.Translate (new Vector2(UserInput.touch1DeltaPosition.x/scrollXSpeed, -UserInput.touch1DeltaPosition.y/scrollYSpeed));
		transform.position = Vector3.Lerp( transform.position, cameraTarget.transform.position, Time.deltaTime * 8.0f );
		
		//Lock the camera x and y positions
		cameraTarget.transform.position = new Vector3(Mathf.Clamp(cameraTarget.transform.position.x, -2f, 2f), Mathf.Clamp(cameraTarget.transform.position.y, -1f, 0f), 9.5f);
		//transform.position = new Vector3(Mathf.Clamp(transform.position.x, rightCameraLimitZoomedOut-(currentRightLimit*zoomLevel), leftCameraLimitZoomedOut+(currentLeftLimit*zoomLevel)), Mathf.Clamp(transform.position.y, -1f, 0f), 9.5f);
	}
}
