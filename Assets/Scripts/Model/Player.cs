public class Player
{

    private int cash;
    public int Cash { get { return this.cash; } set { this.cash = value; } }

    public Player()
    {
        this.cash = 5000;
    }

    public bool hasEnoughCash(int value)
    {
        if ((cash - value) >= 0)
        {
            cash -= value;
            return true;
        }
        else
        {
            return false;
        }
    }
}