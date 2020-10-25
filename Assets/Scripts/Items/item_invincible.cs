public class item_invincible : Item
{
    public item_invincible(int itemCharges, string itemName, string itemDescription) : base(itemCharges, itemName,
        itemDescription) { }
    
    public override void UseItem()
    {
        base.UseItem();
        PlayerHealthController.Instance.Health.SetInvincible(5);
    }
}