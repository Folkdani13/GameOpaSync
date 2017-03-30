using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KubelController : MonoBehaviour {

    public Camera cam;
    public Rigidbody2D kubel;
    public Renderer rend;
    private float maxWidth;
    private bool moving;

	// Use this for initialization
	void Start ()
    {
        moving = false;
        kubel = GetComponent<Rigidbody2D>();
        rend = GetComponent<Renderer>();

        if (cam == null)
        {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float KubelWidth = rend.bounds.extents.x;
        maxWidth = targetWidth.x - KubelWidth;
    }
	
	// Update is called once per physics timestamp
	void FixedUpdate ()
    {
        if (moving)
        {
            Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 targetPosition = new Vector3(rawPosition.x, 0.0f, 0.0f);
            float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
            targetPosition = new Vector3(targetWidth, targetPosition.y, targetPosition.z);
            kubel.MovePosition(targetPosition);
        }

	}

    public void MoveControl(bool toggle)
    {
        moving = toggle;
    }
}
