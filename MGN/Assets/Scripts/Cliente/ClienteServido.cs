﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClienteServido : MonoBehaviour {

	public Transform Target;
	public bool aparece;

    // Update is called once per frame
    void Update () 
	{
		Vector3 dir = Target.position - transform.position;
		if(aparece) SetChildrenActive(true);
		else  SetChildrenActive(false);
		//if(transform.localScale.x < 1) this.GetComponent<MovimientoCliente>().flip();
	}

	void SetChildrenActive(bool value)
	{
		foreach(Transform child in transform)
		{
			child.gameObject.SetActive(value);
		}
	}
}
