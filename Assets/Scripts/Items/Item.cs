using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

/// <summary>
/// A Parent Item component for item child extensions.
/// </summary>
public class Item : MonoBehaviour
{
	//Private Fields---------------------------------------------------------------------------------------------------------------------------------

	//Serialized Fields----------------------------------------------------------------------------

    [SerializeField] private EItem type;
	[SerializeField] private int itemCharges;
	[SerializeField] private string itemName;
	[SerializeField] private string itemDescription;
	

	//Non-Serialized Fields------------------------------------------------------------------------

	//Public Properties------------------------------------------------------------------------------------------------------------------------------

	//Basic Public Properties----------------------------------------------------------------------

	public int Charges { get => itemCharges; }
	public string Description { get => itemDescription; }
	public string Name { get => itemName; }
    public EItem Type { get => type; }
	
    //Complex Public Properties--------------------------------------------------------------------

    //Initialization Methods-------------------------------------------------------------------------------------------------------------------------
    public Item(int itemCharges, string itemName, string itemDescription)
    {
	    this.itemCharges = itemCharges;
	    this.itemName = itemName;
	    this.itemDescription = itemDescription;
    }

	//Triggered Methods------------------------------------------------------------------------------------------------------------------------------

	/// <summary>
	/// Uses Item.
	/// </summary>
	public virtual void UseItem()
	{
		Debug.Log("Item Used");
	}

	/// <summary>
	/// Creates a copy of the item in the players inventory then destroys itself.
	/// </summary>
	public void OnTriggerEnter2D(Collider2D other)
	{
        //Debug.Log("Item.OnTriggerEnter2D()");

		if (other.CompareTag("Player"))
		{
            //TODO Create new copy in players inventory instead of immediately using the item.
            UseItem();
			ItemFactory.Instance.Destroy(this, type);
		}
	}
}
