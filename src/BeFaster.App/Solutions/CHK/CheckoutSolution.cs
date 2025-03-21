﻿using System.Formats.Asn1;
using System.Runtime.CompilerServices;
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
            Dictionary<char,int> groupOffer = new Dictionary<char, int>();
            int Price = 0;
            int FreeBee = 0;
            int FreeM = 0;
            int FreeQ = 0;
            int GroupofferItems = 0;


            prices.Add('A',50);
            prices.Add('B',30);
            prices.Add('C',20);
            prices.Add('D',15);
            prices.Add('E',40);
            prices.Add('F',10);
            prices.Add('G',20);
            prices.Add('H',10);
            prices.Add('I',35);
            prices.Add('J',60);
            prices.Add('K',70);
            prices.Add('L',90);
            prices.Add('M',15);
            prices.Add('N',40);
            prices.Add('O',10);
            prices.Add('P',50);
            prices.Add('Q',30);
            prices.Add('R',50);
            prices.Add('S',20);
            prices.Add('T',20);
            prices.Add('U',40);
            prices.Add('V',50);
            prices.Add('W',20);
            prices.Add('X',17);
            prices.Add('Y',20);
            prices.Add('Z',21);

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
                    if(skus[i] == 'N' && Amount[skus[i]] % 3 == 0)
                    {
                        FreeM +=1;
                    }
                    if(skus[i] == 'R' && Amount[skus[i]] % 3 == 0)
                    {
                        FreeQ +=1;
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
                else if(item.Key == 'V')
                {
                     count = item.Value / 3;
                     remainder = item.Value % 3;
                     whatsleft = remainder % 2;

                    Price+= (count*130)  + ((remainder / 2)* 90) + (whatsleft *50);
                }
                else if(item.Key == 'H')
                {
                     count = item.Value / 10; 
                     remainder = item.Value % 10;
                     whatsleft = remainder % 5;

                    Price+= (count*80)  + ((remainder / 5)* 45) + (whatsleft *10);
                }
                else if(item.Key == 'B')
                {
                    
                    count = (item.Value - FreeBee) /2;
                    remainder = (item.Value - FreeBee) %2;
                    Price+= (count*45) + (remainder *30);
                }
                
                else if(item.Key == 'M')
                {
                    
                    count = item.Value - FreeM;
                    if(count <0)
                    {
                        count = 0;
                    }
                    Price+= count*15;
                }
                else if(item.Key == 'K')
                {
                    
                    count = item.Value  /2;
                    remainder = item.Value  %2;
                    Price+= (count*120) + (remainder *prices[item.Key]);
                }
                else if(item.Key == 'F')
                {
                    count = item.Value - (item.Value / 3);
                    Price+= (count*10) ; 
                }
                else if(item.Key == 'U')
                {
                    count = item.Value - (item.Value / 4);
                    Price+= (count*40) ; 
                }
                else if(item.Key == 'P')
                {
                    count = item.Value /5;
                    remainder = item.Value %5;
                    Price+= (count * 200) + (remainder * 50);
                }
                else if(item.Key == 'Q')
                {
                    count = (item.Value - FreeQ) /3;
                    remainder = (item.Value - FreeQ) %3;
                    Price+= (count * 80) + (remainder * 30);
                }
                else if(item.Key == 'S' || item.Key == 'T' || item.Key == 'X' || item.Key == 'Y' || item.Key == 'Z' )
                {
                    groupOffer.Add(item.Key, item.Value);
                }
                else{
                    Price+= (item.Value * prices[item.Key]);
                }
            }
                groupOffer = groupOffer.OrderByDescending(entry => prices[entry.Key]).ToDictionary(entry => entry.Key , entry => entry.Value); 
            foreach(var item in groupOffer)
            {
                GroupofferItems += item.Value;
                    if(GroupofferItems %3 == 0)
                    {
                        Price+=45;
                        GroupofferItems =0;
                    }
                    else if(GroupofferItems > 3 && GroupofferItems %3 !=0)
                    {
                        Price+=45;
                        GroupofferItems-=3;
                    }
                }
                foreach(var entry in groupOffer.TakeLast(GroupofferItems))
                {
                    Price+= prices[entry.Key];
                }
            


     return Price;
}
    }
}




