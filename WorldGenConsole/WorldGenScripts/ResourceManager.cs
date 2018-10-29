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

public class ResourceManager : PopulationBased
{
    private ConsumptionController consumptionController;
    private ProductionController productionController;
    private TradeController tradeController;

    //List of resources that the city can produce
    private List<bool> lProduces;

    //Quantity of resources that the city holds at any given time
    private List<int> lResourceQuantity;

    private int people;

    // Class entry point
    // Initialise population, managers, resource lists and produces the first batch of products
    public ResourceManager(int population)
    {
        // MUST DO FIRST
        SetPeople(population);

        InstantiateManagers();
        InstantiateLists();
        ProduceProducts();
    }

    private void InstantiateManagers()
    {
        consumptionController = new ConsumptionController();
        productionController = new ProductionController();
        tradeController = new TradeController();
    }

    // Sets up collects of resources
    private void InstantiateLists()
    {
        lProduces = new List<bool>();
        lResourceQuantity = new List<int>();
        for (int i = 0; i < (int)Resources.length; i++)
        {
            //All resources are produced in all cities (for the time being)
            lProduces.Add(true);

            //All resource quantities are set to zero by default
            lResourceQuantity.Add(0);
        }
    }

    private void ProduceProducts()
    {
        int[] products = productionController.Produce(people, lProduces);
        UpdateProductLedger(products);
    }

    private void UpdateProductLedger(int[] products)
    {
        int i = 0;
        foreach(int product in products)
        {
            lResourceQuantity[i] = lResourceQuantity[i] + product;
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

