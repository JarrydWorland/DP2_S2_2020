﻿using System.Collections;
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

	[SerializeField] private int itemCharges;
	[SerializeField] private string itemName;
	[SerializeField] private string itemDescription;
	

	//Non-Serialized Fields------------------------------------------------------------------------

	//Public Properties------------------------------------------------------------------------------------------------------------------------------

	//Basic Public Properties----------------------------------------------------------------------

	public int GetItemCharges()
	{
		return itemCharges;
	}
	public string GetItemName()
	{
		return itemName;
	}
	public string GetItemDescription()
	{
		return itemDescription;
	}
	
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
	public void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			//TODO Create new copy in players inventory
			Destroy(gameObject);
		}
	}
}
