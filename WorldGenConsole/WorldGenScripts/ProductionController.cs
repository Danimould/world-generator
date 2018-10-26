//Calculate how much is produced
//using information such as population, city quality, local geography etc

/*
 * Food mass in 200litre drum = 800 * 200 = 160000g = 160kg
 * Calories in 160kg ‘food’ = 1500 * 160 = 240,000 calories
 * Feeding a total of: 240,000 / 3000 calories = 80 people
 * Largest city would require 23,314 / 80 = 291.425 ≈ 292 barrels of food per day to survive
 * Food barrel value = 80 * 0.5 = 40gp
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ProductionController
{
    //Percentage of food produced to feed population
    //Currently set at 100% efficiency
    private double foodEfficieny = 1.0;
    private const double MEALS_IN_BARREL = 80;

    //Returns quantites of produce in an int array
    public int[] Produce(int population, List<bool> lCanProduce)
    {
        int food;

        if (lCanProduce[(int)Resources.food])
        {
            food = ProduceFood(population);
        }
        else
        {
            food = 0;
        }

        int[] products = { food };

        return products;
    }

    private int ProduceFood(int population)
    {
        //Produces enough barrels of food for the day for population * efficiency
        double dFoodQuant = population / MEALS_IN_BARREL * foodEfficieny;

        //Rounds up to nearest integer value
        double foodQuant = Math.Ceiling(dFoodQuant);

        Debug.Print("Food produced: " + foodQuant.ToString());
        return (int)foodQuant;
    }
}
