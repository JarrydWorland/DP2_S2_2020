using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_clearscreen : Item
{
    
    //Private Fields---------------------------------------------------------------------------------------------------------------------------------
    [SerializeField] private GameObject explosion;
    //Serialized Fields----------------------------------------------------------------------------

    //Non-Serialized Fields------------------------------------------------------------------------

    //Public Properties------------------------------------------------------------------------------------------------------------------------------

    //Basic Public Properties----------------------------------------------------------------------
    
    //Complex Public Properties--------------------------------------------------------------------

    //Initialization Methods-------------------------------------------------------------------------------------------------------------------------
    
    public item_clearscreen(int itemCharges, string itemName, string itemDescription) : base(itemCharges, itemName, itemDescription)
    {
    }
    
    //Triggered Methods------------------------------------------------------------------------------------------------------------------------------
    public override void UseItem()
    {
        base.UseItem();
        Instantiate(explosion);
    }
}
