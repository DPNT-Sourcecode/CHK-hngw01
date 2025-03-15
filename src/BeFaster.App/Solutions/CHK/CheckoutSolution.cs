using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int ComputePrice(string? skus)
        {
            string [] items = skus.Split(',');
            Dictionary<string,int> prices = new Dictionary<string, int>();
            Dictionary<string,int> Amount = new Dictionary<string, int>();

            prices.Add("A",50);
            prices.Add("B",30);
            prices.Add("C",20);
            prices.Add("D",15);

            for(int i = 0; i<items.Length; i++)
            {
                if()
            }

        }
    }
}
