using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHandTrackingScript : MonoBehaviour {

	
	
	void Update () {
		
	}

    void MyGestureRecognitionMethod(GestureInfo detectedGesture){

        Debug.Log(detectedGesture);
    }


}
