using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour
{
	public Transform startTrs;
	public Transform endTrs;
	LineRenderer line;

	// Use this for initialization
	void Start ()
	{
		line = GetComponent<LineRenderer>();
		foreach (MeshRenderer r in GameObject.FindObjectsOfType(typeof(MeshRenderer)))
		{
			if (r.gameObject.layer == LayerMask.NameToLayer("Node") && r.sharedMaterial == line.sharedMaterial)
				Physics2D.IgnoreCollision(r.collider2D, collider2D, false);
			else
				Physics2D.IgnoreCollision(r.collider2D, collider2D, true);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector2 startToEnd = endTrs.position - startTrs.position;
		transform.position = (Vector2) startTrs.position + (startToEnd / 2);
		transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(startToEnd.y, startToEnd.x) * Mathf.Rad2Deg);
		line.SetPosition(0, startTrs.position);
		line.SetPosition(1, endTrs.position);
		GetComponent<BoxCollider2D>().size = new Vector2(Vector2.Distance(startTrs.position, endTrs.position), 1f);
		transform.Find("Trigger").GetComponent<BoxCollider2D>().size = new Vector2(Vector2.Distance(startTrs.position, endTrs.position) - 2.96f, .05f);
		float midpointX = (startTrs.position.x + endTrs.position.x) / 2;
		float midpointY = (startTrs.position.y + endTrs.position.y) / 2;
	}
}
