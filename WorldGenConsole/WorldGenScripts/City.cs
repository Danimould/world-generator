
public class City
{
    //Location in the world space
    private int[] location;
    //Title of the city (currently 30 largest cities in England, during the 14th Century)
    private string title;
    //Population of the city (currently 30 largest cities in England, during the 14th Century)
    private int population;


    public City(string name, int[] coordinates, int inhabitants)
    {
        SetLocation(coordinates);
        SetTitle(name);
        SetPopulation(inhabitants);

        System.Diagnostics.Debug.Print(title + ": " + location[0].ToString() + ", " + location[1] + "; " + population.ToString());

        InitialseProduction(population);
    }

    private void InitialseProduction(int pop)
    {
        ResourceModel rm = new ResourceModel(pop);
    }

    private void SetLocation(int[] x)
    {
        location = x;
    }

    private void SetTitle(string y)
    {
        title = y;
    }

    private void SetPopulation(int z)
    {
        population = z;
    }
}