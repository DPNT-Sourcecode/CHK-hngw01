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
            int Price = 0;

            prices.Add("A",50);
            prices.Add("B",30);
            prices.Add("C",20);
            prices.Add("D",15);

            for(int i = 0; i<items.Length; i++)
            {
                if(Amount.ContainsKey(items[i]))
                {
                    Amount[items[i]] ++;
                    if(items[i] == "A" && Amount[items[i]] % 3 == 0)
                    {
                        Price = Price + 30;
                    }
                    else{
                       Price = Price + prices[items[i]]; 
                    }
                    if(items[i] == "B" && Amount[items[i]] % 2 == 0)
                    {
                        Price = Price + 15;
                    }
                                        else{
                       Price = Price + prices[items[i]]; 
                    }

                }
                else{
                    Amount.Add(items[i], 1);
                    Price = Price + prices[items[i]];
                }
            }
            return Price;

        }
    }
}

