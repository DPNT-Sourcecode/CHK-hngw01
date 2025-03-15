using System.Formats.Asn1;
using Apache.NMS;
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
            int FreeBee = 0;
            int FreeF = 0;

            prices.Add('A',50);
            prices.Add('B',30);
            prices.Add('C',20);
            prices.Add('D',15);
            prices.Add('E',40);
            prices.Add('F',10);

            for(int i = 0; i<skus.Length; i++)
            {
                if(!prices.ContainsKey(skus[i]))
                {
                    return -1;
                } 
                if(Amount.ContainsKey(skus[i]))
                {
                    Amount[skus[i]] = Amount[skus[i]] + 1;
                    if(skus[i] == 'E' && Amount[skus[i]] % 2 == 0)
                    {
                        FreeBee +=1;
                    }
                    if(skus[i] == 'F' && Amount[skus[i]] % 2 == 0)
                    {
                        FreeF +=1;
                    }
                } 
                else{
                    Amount.Add(skus[i], 1);
                }  

            }

            foreach(var item in Amount)
            {
                int count;
                int remainder;
                int whatsleft;
                if(item.Key == 'A')
                {
                     count = item.Value / 5;
                     remainder = item.Value % 5;
                     whatsleft = remainder % 3;

                    Price+= (count*200)  + ((remainder / 3)* 130) + (whatsleft *50);
                }
                else if(item.Key == 'B')
                {
                    
                    count = (item.Value - FreeBee) /2;
                    remainder = (item.Value - FreeBee) %2;
                    Price+= (count*45) + (remainder *30);
                }
                else if(item.Key == 'F')
                {
                    count = (item.Value - FreeF) /2;
                    remainder = (item.Value-FreeF) %2;
                    Price+= 
                }
                else{
                    Price+= (item.Value * prices[item.Key]);
                }
            }


     return Price;
}
    }
}







