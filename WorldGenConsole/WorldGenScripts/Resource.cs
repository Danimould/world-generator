using System;

public class Resource
{
    private bool canProduce = false;
    private int quantity = 0;

    public Resource()
    {

    }

    //========== Getters/Setters ==========
    public int GetQuantity()
    {
        return quantity;
    }

    public bool CanProduce()
    {
        return canProduce;
    }


}

