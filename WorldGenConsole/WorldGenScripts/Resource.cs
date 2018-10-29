using System;

public class Resource
{
    private bool canProduce = false;
    //As defined by EResources enum
    private readonly EResources resourcesEnum;
    private int quantity = 0;

    public Resource(EResources value)
    {
        resourcesEnum = value;
    }

    //========== Getters/Setters ==========
    public int GetQuantity()
    {
        return quantity;
    }

    public void UpdateQuantity(int change)
    {
        quantity += change;
    }

    public bool CanProduce()
    {
        return canProduce;
    }
}

