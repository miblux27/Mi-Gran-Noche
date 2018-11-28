using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientePidiendo : MonoBehaviour {

	public Transform Target;
	public bool aparece;
	private float posOriginal;

	void Start()
	{
		posOriginal = transform.position.x;
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		float pos = Target.position.x - transform.position.x;
		if(aparece) SetChildrenActive(true);
		else SetChildrenActive(false);
	}


	void SetChildrenActive(bool value)
	{
		foreach(Transform child in transform)
		{
			child.gameObject.SetActive(value);
		}
	}
}
