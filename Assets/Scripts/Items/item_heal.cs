using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_heal : Item
{
    //Private Fields---------------------------------------------------------------------------------------------------------------------------------

    [SerializeField] private float healthIncrease;

    //Serialized Fields----------------------------------------------------------------------------

    //Non-Serialized Fields------------------------------------------------------------------------

    //Public Properties------------------------------------------------------------------------------------------------------------------------------

    //Basic Public Properties----------------------------------------------------------------------
    
    //Complex Public Properties--------------------------------------------------------------------

    //Initialization Methods-------------------------------------------------------------------------------------------------------------------------
    
    public item_heal(int itemCharges, string itemName, string itemDescription) : base(itemCharges, itemName, itemDescription)
    {
    }
    
    //Triggered Methods------------------------------------------------------------------------------------------------------------------------------
    public override void UseItem()
    {
        base.UseItem();
        PlayerHealthController.Instance.Health.Heal(healthIncrease);
    }
}