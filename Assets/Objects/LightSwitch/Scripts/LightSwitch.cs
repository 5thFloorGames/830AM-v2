//LightSwitch Script
//IMPORTANT: PLEASE READ
//......................
// IN ORDER FOR THIS SCRIPT
// TO RUN, YOU MUST ADD A
// BOX COLLIDER TO YOUR 
//LIGHTSWITCH!
//.......................
//THIS SCRIPT IS TRIGGERED
//BY CLICKING THE LIGHTSWITCH
//BOX COLLIDER
//......................


using UnityEngine;
using System.Collections;

	// If you change the name of your script, change the public
	// class below from LightSwitch to what you named the script.
public class LightSwitch : MonoBehaviour {

	// Declares the light game object as "DragYourLightHere".
	// Do not try to drag your light from unity into the actual script.
	// It is named like this so that the Unity editor will display where to
	// drag your light.
	public Light DragYourLightHere;

	// Declares the two states for the lightswitch: on or off.
	private enum State {
		on,
		off
	}

	// Declares the State as state.
	private State state;

	// Initializes the lightswitch so that the script knows the lights are on to
	// start with.
	void Start () {
		state = LightSwitch.State.on;

	}

	// On the mouse up event, the state changes to off if it was on before clicked, and
	// the state changes to on if it was off before clicked.
	public void OnMouseUp() {
		if (state == LightSwitch.State.on)
						TurnOff ();
				else
						TurnOn ();
	}

	// Turn on subprocedure: plays the TurnOn Animation, sets the state to on, and enables
	// the light.
	private void TurnOn() {
		GetComponent<Animation>().Play ("TurnOnAnimation");
		state = LightSwitch.State.on;
		DragYourLightHere.enabled = true;

}

	//Turn off subprocedure: plays the TurnOff Animation, sets the state to off, and
	// disables the light.
	private void TurnOff() {
		GetComponent<Animation>().Play ("TurnOffAnimation");
		state = LightSwitch.State.off;
		DragYourLightHere.enabled = false;

}
}

