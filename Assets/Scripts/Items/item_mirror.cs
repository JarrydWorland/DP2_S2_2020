public class item_mirror : Item
{
    public item_mirror(int itemCharges, string itemName, string itemDescription) : base(itemCharges, itemName,
        itemDescription) { }
    
    public override void UseItem()
    {
        base.UseItem();
        CloneController.Instance.Enable(5);
    }
}