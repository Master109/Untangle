using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour
{
	bool dragging;
	public Collider2D colliderBeingDragged;
	public int speed;
	public int maxSpeed;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
			dragging = true;
		else if (Input.GetMouseButtonUp(0) || Input.touchCount == 0)
		{
			dragging = false;
			colliderBeingDragged = null;
		}
		transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (colliderBeingDragged != null && colliderBeingDragged.rigidbody2D && colliderBeingDragged.rigidbody2D.velocity.magnitude < maxSpeed)
			colliderBeingDragged.rigidbody2D.AddForce(new Vector2(Input.touches[0].deltaPosition.x + Input.GetAxis("Mouse X"), Input.touches[0].deltaPosition.y + Input.GetAxis("Mouse Y")) * speed);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Node") && dragging && colliderBeingDragged == null)
			colliderBeingDragged = other;
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Node") && dragging && colliderBeingDragged == null)
			colliderBeingDragged = other;
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Node") && dragging && colliderBeingDragged == null)
			colliderBeingDragged = other;
	}
}
