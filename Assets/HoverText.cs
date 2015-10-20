using UnityEngine;
using System.Collections;

public class HoverText : MonoBehaviour {

    public GameObject objectToFollow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
        if (objectToFollow != null)
        {
            Transform transform = GetComponent<Transform>();
            Transform objectTransform = objectToFollow.GetComponent<Transform>();

            transform.position = objectTransform.position;

        }

	}
}
