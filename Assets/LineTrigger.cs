using UnityEngine;
using System.Collections;

public class LineTrigger : MonoBehaviour
{
	static int lineCollisions = -1;

	// Use this for initialization
	void Start ()
	{
		Debug.Log(lineCollisions);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (lineCollisions <= 1)
		{
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Line") && other.transform.gameObject != transform.parent.gameObject)
			lineCollisions ++;
		if (lineCollisions == 0)
			lineCollisions = 1;
		Debug.Log(lineCollisions);
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Line") && other.transform.gameObject != transform.parent.gameObject)
			lineCollisions --;
		Debug.Log(lineCollisions);
	}
}
