using System;
					
public class Program
{	
	public static void Main()
	{
		double totalCP = 0;
		double totalVol = 0;
		double totalSP = 0;
		double totalSellVol = 0;
		double avgCost = 0;
		double avgSell = 0;
		
		// Enter total volume and avg price as first values, or enter all buy orders details
		double[] costPrice = {100,50};
		double[] volumes = {200, 50};
		
		// Enter the sell order details
		double[] sellPrice = {40};
		double[] sellVolumes = {50};
				
		// Optimise this value to eqalize Recovery Price and Expected sell price
		double optimalPercentage = 110;
		
		for(int i = 0; i < costPrice.Length; i++ ){
			totalCP += costPrice[i] * volumes[i];
			totalVol += volumes[i];
		}
		for(int i = 0; i < sellPrice.Length; i++ ){
			totalSP += sellPrice[i] * sellVolumes[i];
			totalSellVol += sellVolumes[i];
		}
		avgSell = totalSP/totalSellVol;
		avgCost = totalCP/totalVol;
		
		Console.WriteLine("\n------------------------------ Invested ------------------------------");
		Console.WriteLine("Total Cost Price: " + totalCP);
		Console.WriteLine("Total Volume: " + totalVol);
		Console.WriteLine("Avg Cost Price: " + avgCost);
		
		double saleAmount = totalSP;
		double expsaleAmount = avgCost * totalSellVol;
		
		totalVol = totalVol - totalSellVol;
		totalCP = totalCP - saleAmount;
		double loss = expsaleAmount - saleAmount;
		
		double actualRecoveryPrice = totalCP/totalVol;
		double taxOnProfit =  ((actualRecoveryPrice - avgCost)/100)*35;
		
		double recoveryPrice = (actualRecoveryPrice/100)*optimalPercentage ;
		double taxOnrecoveryPrice = ((recoveryPrice-avgCost)/100)*35;
		
		Console.WriteLine("\n------------------------- Loss Making Sale ---------------------------");
		Console.WriteLine("Vol Sold: " + totalSellVol  + "	Sale Price each: " + avgSell );
		Console.WriteLine("Cost Price total: " + expsaleAmount  + "	Sale Price total: " + saleAmount + "	Loss: " + loss + "\n\nAmount to be recovered: " + totalCP);
		Console.WriteLine("\n------------------------- Actuals (Total CP) -------------------------");
		Console.WriteLine("Recovery Price: " + actualRecoveryPrice);
		Console.WriteLine("Tax:" + taxOnProfit + "	Price after tax: " + (actualRecoveryPrice -taxOnProfit));
		Console.WriteLine("\nNET PROFIT (Profit per unit * Volume): " + (actualRecoveryPrice -taxOnProfit - actualRecoveryPrice)*totalVol);
		Console.WriteLine("\n--------------------- Expected (Total CP + Tax) ----------------------");
		Console.WriteLine("\nMinimum Selling Price to save investment: " + recoveryPrice);
		
		Console.WriteLine("Tax: " + taxOnrecoveryPrice +"	Price after tax: " + (recoveryPrice -taxOnrecoveryPrice));
		double NETNET = (recoveryPrice -taxOnrecoveryPrice-actualRecoveryPrice)*totalVol;
		Console.WriteLine("\nNET PROFIT (Profit per unit * Volume): " + NETNET + " ("+ (int)((NETNET/totalCP)*100)+ "%)");
	}
}
