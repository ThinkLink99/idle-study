[System.Serializable]
public class BoughtUtencil
{
    public Utencil details;
    public int qty;

    public BoughtUtencil(Utencil details, int qty)
    {
        this.details = details;
        this.qty = qty;
    }
}
