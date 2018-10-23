
//Manages food production, receiving updates whenever population changes
public class Food {

    private int population;

    public Food (int consumers)
    {
        SetPopulation(consumers);
    }

    public void SetPopulation(int x)
    {
        population = x;
    }
}
