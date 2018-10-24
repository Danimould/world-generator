/*
 * Manages resources within city by acting as a centre point for all classes that effect resources
 * Also maintains list of all resources currently available within city
 * 
 * Must establish all resources produced here on instantiation in order to facilitate @lProduces and @lResourceQuantity coordination
 * 
 * EResources enumeration is as follows:
 * food = 0
 * length = 1
 * 
 */
using System.Collections.Generic;

public class ResourceModel : PopulationBased
{
    private ConsumptionController conMan;
    private ProductionController proMan;
    private TradeController traMan;

    //List of resources that the city can produce
    private List<bool> lProduces;

    //Quantity of resources that the city holds at any given time
    private List<int> lResourceQuantity;

    private int people;

    public ResourceModel(int population)
    {
        SetPeople(population);
        InstantiateManagers();
        InstantiateLists();
        ProduceProducts();
    }

    private void InstantiateManagers()
    {
        conMan = new ConsumptionController();
        proMan = new ProductionController();
        traMan = new TradeController();
    }

    private void InstantiateLists()
    {
        lProduces = new List<bool>();
        lResourceQuantity = new List<int>();
        for (int i = 0; i < (int)Resources.length; i++)
        {
            //All resources are produced in all cities (for the time being
            lProduces.Add(true);

            //All resource quantities are set to zero by default
            lResourceQuantity.Add(0);
        }
    }

    private void ProduceProducts()
    {
        int[] products = proMan.Produce(people, lProduces);
        UpdateProductLedger(products);
    }

    private void UpdateProductLedger(int[] products)
    {
        int i = 0;
        foreach(int prod in products)
        {
            lResourceQuantity[i] = lResourceQuantity[i] + prod;
            System.Diagnostics.Debug.Print("Resource produced: " + lResourceQuantity[i].ToString());
            i++;
        }
    }

    //***** Setters and Getters etc *****
    private void SetPeople(int x)
    {
        people = x;
    }

    private int GetPeople()
    {
        return people;
    }

    public void UpdatePeople(int y)
    {
        people = y;
    }
}

