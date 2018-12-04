using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClienteAtendido : MonoBehaviour {
	public Transform Target;
    public bool aparece;

    // Update is called once per frame
    void Update () 
	{
		Vector3 dir = Target.position - transform.position;
		if(aparece)
		{
			foreach(Transform child in transform)
				if(Target.GetComponent<MovimientoCliente>().bebida == (int)Bebida.BebidaTipo.cocktail && child.CompareTag("Cocktail"))
				{
					child.gameObject.SetActive(true);
				}
				else if (Target.GetComponent<MovimientoCliente>().bebida == (int)Bebida.BebidaTipo.cerveza && child.CompareTag("Cerveza"))
				{
					child.gameObject.SetActive(true);
				}
				else if (Target.GetComponent<MovimientoCliente>().bebida == (int)Bebida.BebidaTipo.chupito && child.CompareTag("Chupito"))
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
