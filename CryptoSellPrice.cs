using System;
					
public class Program
{	
	public static void Main()
	{
		double[] costPrice = {100,50};
		double[] volumes = {100, 30};
		double totalCP = 0;
		double totalVol = 0;
		double avgCost = 0;
		
		for(int i = 0; i < 2; i++ ){
			totalCP += costPrice[i] * volumes[i];
			totalVol += volumes[i];
		}
		avgCost = totalCP/totalVol;
		Console.WriteLine("Total Cost Price: " + totalCP);
		Console.WriteLine("Total Volume: " + totalVol);
		Console.WriteLine("Avg Cost Price: " + avgCost);
		
		// selling few items
		double saleVol = 10;
		double salePrice = 40;
		
		// Optimise this value to eqalize Recovery Price and Expected sell price
		double optimalPercentage = 102.5;
		
		double saleAmount = salePrice * saleVol;
		double expsaleAmount = avgCost * saleVol;
		
		totalVol = totalVol - saleVol;
		totalCP = totalCP - saleAmount;
		double loss = expsaleAmount - saleAmount;
		
		double actualRecoveryPrice = totalCP/totalVol;
		double profit = actualRecoveryPrice - avgCost;
		double taxOnProfit =  ((actualRecoveryPrice - avgCost)/100)*35;
		
		double recoveryPrice = (actualRecoveryPrice/100)*optimalPercentage ;
		double taxOnrecoveryPrice = ((recoveryPrice-avgCost)/100)*35;
		
		Console.WriteLine("\n----------------------- Sale ------------------------");
		Console.WriteLine("\nVol Sold: " + saleVol  + "	Sale Price each: " + salePrice );
		Console.WriteLine("Cost Price total: " + expsaleAmount  + "	Sale Price total: " + saleAmount + "	Loss: " + loss + "\n\nAmount to be recovered: " + totalCP);
		Console.WriteLine("\n---------------------- Actuals ----------------------");
		Console.WriteLine("Recovery Price: " + actualRecoveryPrice);
		Console.WriteLine("Profit: " + profit + "	Tax:" + taxOnProfit);
		Console.WriteLine("\n--------------------- Expected ----------------------");
		Console.WriteLine("\nSelling Price to save investment: " + recoveryPrice);
		//Console.WriteLine("\nPercent Profit to sell at: " + ((recoveryPrice-avgCost)/avgCost)*100);
		
		Console.WriteLine("Tax: " + taxOnrecoveryPrice +"	Recovery Price after tax: " + (recoveryPrice -taxOnrecoveryPrice));
		Console.WriteLine("\n				NET PROFIT: " + (recoveryPrice -taxOnrecoveryPrice-actualRecoveryPrice)*totalVol);
	}
}
