using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClienteAtendido2 : MonoBehaviour {

	public Transform Target;
	public bool aparece;
	public Bebidas Cocktail;
	public Bebidas Cerveza;
	public Bebidas Chupito;
	// Update is called once per frame
	void Update () 
	{
		Vector3 dir = Target.position - transform.position;
		if(aparece)
		{
			foreach(Transform child in transform)
				if(Target.GetComponent<MovimientoCliente>().bebida == Cocktail && child.CompareTag("Cocktail"))
				{
					child.gameObject.SetActive(true);
				}
				else if (Target.GetComponent<MovimientoCliente>().bebida == Cerveza && child.CompareTag("Cerveza"))
				{
					child.gameObject.SetActive(true);
				}
				else if (Target.GetComponent<MovimientoCliente>().bebida == Chupito && child.CompareTag("Chupito"))
				{
					child.gameObject.SetActive(true);
				}
		} 
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
