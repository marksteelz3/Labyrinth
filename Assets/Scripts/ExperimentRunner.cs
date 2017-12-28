using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//we have been asked to create a cognitive psycology app for a professor here at Duke
//it will follow the common experiment paradigm of 
//  1) user gets exposed to stimulus [denser scene with several objects moving/rotating]
//  2) user responds (presses key) or timeout occurs
//  3) a simple centering / fixation object is shown (could be a simple sphere)

// to use this stub script
//   create an empty gameobject
//   add this outline script to the gameobject
//   decide how you want to reference other objects in your scene (PLD or GameObject.Find)

public class ExperimentRunner : MonoBehaviour {
	int state=0;
	double accumulatedTime=0.0;

        //if doing PLD (public lock drag) method of object reference
        //public GameObject stimulus1; //ect

	// Use this for initialization
	void Start () {
		
	}
		
	// Update is called once per frame
	void Update () {
		accumulatedTime += Time.deltaTime;

		if (state == 0) { //stimulus exposure state

			//update stimulus objects here
                        //e.g. stimulus1.Rotate(....

			//(or you could alternatively have updates as scripts on individual stimulus objects)
			   //some possible options we should know how to do:
			   //hide-show (blink)
			   //rotate [could be constant or stopping/starting]
			   //translate [could be constant or stopping/starting]
			   //(maybe you can figure out scale?)

			//watch for users key press (keydown) or if timer excedes 10 seconds
			   //setup world for next state 
                             //hide stimulus objects, 
                             //show fixation object (could be a simple sphere)
			   //reset timer
                           //advance to results state
		}
		if (state == 1) {  //centering state
			//wait for time to expire
			   //setup world for next state (hide centering/fixation object, show stimulus objects)
		           //reset timer
			   //advance to stimulus exposure state
		}
	}
}
