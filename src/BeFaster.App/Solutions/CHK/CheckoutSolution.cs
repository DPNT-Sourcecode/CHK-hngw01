using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int ComputePrice(string? skus)
        {
            Dictionary<char,int> prices = new Dictionary<char, int>();
            Dictionary<char,int> Amount = new Dictionary<char, int>();
            int Price = 0;

            prices.Add('A',50);
            prices.Add('B',30);
            prices.Add('C',20);
            prices.Add('D',15);

            for(int i = 0; i<skus.Length; i++)
            {
                if(!prices.ContainsKey(skus[i]))
                {
                    return -1;
                }
                if(Amount.ContainsKey(skus[i]))
                {
                    Amount[skus[i]] ++;
                    if(skus[i] == 'A' && Amount[skus[i]] % 3 == 0)
                    {
                        Price = Price + 30;
                    }
                    else{
                       Price = Price + prices[skus[i]]; 
                    }
                    if(skus[i] == 'B' && Amount[skus[i]] % 2 == 0)
                    {
                        Price = Price + 15;
                    }
                        else{
                       Price = Price + prices[skus[i]]; 
                    }

                }
                else{
                    Amount.Add(skus[i], 1);
                    Price = Price + prices[skus[i]];
                }
            }
            return Price;

        }
    }
}



