using System;
using UnityEngine;

[AddComponentMenu("Camera-Control/Smooth Follow")]
public class SmoothFollow : MonoBehaviour
{
	// the camera controller script, which is oddly clean compared to everything else in the game
	// i cant really be bothered commenting this one but if you want to, go ahead
	
	public SmoothFollow()
	{
		this.distance = 10f;
		this.height = 5f;
		this.heightDamping = 2f;
		this.rotationDamping = 3f;
	}

	public void LateUpdate()
	{
		if (this.target)
		{
			float y = this.target.eulerAngles.y;
			float to = this.target.position.y + this.height;
			float num = this.transform.eulerAngles.y;
			float num2 = this.transform.position.y;
			num = Mathf.LerpAngle(num, y, this.rotationDamping * Time.deltaTime);
			num2 = Mathf.Lerp(num2, to, this.heightDamping * Time.deltaTime);
			Quaternion rotation = Quaternion.Euler((float)0, num, (float)0);
			this.transform.position = this.target.position;
			this.transform.position = this.transform.position - rotation * Vector3.forward * this.distance;
			float y2 = num2;
			Vector3 position = this.transform.position;
			float num3 = position.y = y2;
			Vector3 vector = this.transform.position = position;
			this.transform.LookAt(this.target);
		}
	}

	public Transform target;
	public float distance;
	public float height;
	public float heightDamping;
	public float rotationDamping;
}
