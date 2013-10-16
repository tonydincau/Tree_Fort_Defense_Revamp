    using UnityEngine;
    using System.Collections;
     
    public class CameraZoom : MonoBehaviour
    {
        private float speed = 0.2f;
        public Camera selectedCamera;
        private float MINSCALE = 2.0F;
        private float MAXSCALE = 5.0F;
        private float varianceInDistances = 5.0F;
        private float touchDelta = 0.0F;
        private Vector2 prevDist = new Vector2(0,0);
        private Vector2 curDist = new Vector2(0,0);
        private float startAngleBetweenTouches = 0.0F;
        private int vertOrHorzOrientation = 0; //this tells if the two fingers to each other are oriented horizontally or vertically, 1 for vertical and -1 for horizontal
        private Vector2 midPoint = new Vector2(0,0); //store and use midpoint to check if fingers exceed a limit defined by midpoint for oriantation of fingers
       
        void Update ()
        {
            if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Began && Input.GetTouch(1).phase == TouchPhase.Began)
            {
               
            }
           
            if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved){
			
            	midPoint = new Vector2(((Input.GetTouch(0).position.x + Input.GetTouch(1).position.x)/2), ((Input.GetTouch(0).position.y - Input.GetTouch(1).position.y)/2));
            	curDist = Input.GetTouch(0).position - Input.GetTouch(1).position;
            	prevDist = ((Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition) - (Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition));
            	touchDelta = curDist.magnitude - prevDist.magnitude;
               
                if ((Input.GetTouch(0).position.x - Input.GetTouch(1).position.x) > (Input.GetTouch(0).position.y - Input.GetTouch(1).position.y)){
                    vertOrHorzOrientation = -1;
                }
                if ((Input.GetTouch(0).position.x - Input.GetTouch(1).position.x) < (Input.GetTouch(0).position.y - Input.GetTouch(1).position.y)){
                    vertOrHorzOrientation = 1;
                }
               
                if ((touchDelta < 0)){
                	selectedCamera.fieldOfView = Mathf.Clamp(selectedCamera.fieldOfView + (1f * speed),13f,20f);
                }
               
                if ((touchDelta > 0)){
                    selectedCamera.fieldOfView = Mathf.Clamp(selectedCamera.fieldOfView - (1f * speed),13f,20f);
                }
                         
            }      
        }
    }