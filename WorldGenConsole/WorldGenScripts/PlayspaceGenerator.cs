using System;
using System.Collections.Generic;

public class PlayspaceGenerator
{
    private const int CITIES = 30;
    private const int REGION_AREA = 50000; //measured in miles

    // Use this for initialization
    public void Start()
    {
        EstablishCities(EstablishArea(REGION_AREA), CITIES);
    }

    //Creates list of city locations, skewed to ensure none are within ONE DAY'S TRAVEL of each other
    private void EstablishCities(int[] worldArea, int numCities)
    {
        int xWorldDim = worldArea[0];
        int yWorldDim = worldArea[1];

        //Locations
        List<int[]> lCityLocations = new List<int[]>();
        for (int i = 0; i < numCities; i++)
        {
            int[] coordinates = new int[2];
            Random rand = new Random();


            for (int j = 0; j < 2; j++)
            {
                coordinates[j] = rand.Next(xWorldDim, yWorldDim + 1);
            }

            lCityLocations.Add(coordinates);
        }

        //Names
        List<string> lCityNames = new List<string>() { "London", "York", "Bristol", "Coventry", "Norwich", "Lincoln", "Salisbury", "King's Lynn", "Colchester", "Bolton", "Beverley", "Newcastle", "Canterbury", "Bury St Edmunds", "Oxford", "Glouster", "Leicester", "Shrewsbury", "Great Yarmouth", "Hereford", "Cambridge", "Ely", "Plymouth", "Exeter", "Hull", "Worcester", "Ipswich", "Northampton", "Nottingham", "Winchester" };
        //Populations
        List<int> lCityPopulations = new List<int>() { 23314, 7248, 6345, 4817, 3952, 3569, 3226, 3217, 2955, 2871, 2663, 2647, 2574, 2445, 2357, 2239, 2101, 2083, 1941, 1903, 1902, 1772, 1700, 1560, 1557, 1557, 1507, 1477, 1447, 1440 };

        for (int i = 0; i < 30; i++)
        {
            City city = new City(lCityNames[i], lCityLocations[i], lCityPopulations[i]);
        }
    }

    //Randomly assigns dimensions for world space (ie is space tall and thin or short and fat?)
    //Currently world space is rectangular and entirely landmass (no water). Ocean and lakes to be added later.
    private int[] EstablishArea(int surfaceArea)
    {
        //The smallest/largest any one dimension can be
        const int minX = 70;
        const int maxX = 701;

        //x * y = surfaceArea
        //Randomly selects x dimension
        Random rand = new Random();
        int x = rand.Next(minX, maxX + 1);
        int y = surfaceArea / x;

        int[] dimensions = { x, y };

        System.Diagnostics.Debug.Print("X: " + dimensions[0] + "\nY: " + dimensions[1] + "\nArea: " + (dimensions[0] * dimensions[1]).ToString());

        return dimensions;
    }
}
