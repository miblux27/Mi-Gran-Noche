using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientePidiendo : MonoBehaviour {

	public Transform Target;
	public bool aparece;

	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 dir = Target.position - transform.position;
		if(!aparece) SetChildrenActive(false);

		
	}

	void SetChildrenActive(bool value)
	{
		foreach(Transform child in transform)
		{
			child.gameObject.SetActive(value);
		}
	}
}
