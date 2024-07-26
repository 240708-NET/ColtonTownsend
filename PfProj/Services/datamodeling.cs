/* Filename: datamodeling.cs
 * Author: Colton Townsend
 * Date: Created 7/11/2024
 * Procedures:
 * main - Calls functions like printstats and covar.
 * printstats - Aggregate procedure to call sumVector, meanVector, medianVector, and rangeVector.
 * printVector - Debug procedure to print the whole vector.
 * sumVector - Returns sum of a vector.
 * meanVector - Returns mean of a vector.
 * medianVector - Returns median of a vector.
 * range - PRINTS range of a vector. (This is because range has a min and a max, I can't be bothered to make two seperate methods for now ¯\_(ツ)_/¯)
 * covar - Returns covariance of two vectors.
 * cor - Returns correlation of two vectors.
 */
 
using System;
using System.Collections.Specialized;
using System.Diagnostics.Contracts;
using System.Formats.Asn1;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;


namespace PfProj.Services;
	class DataModeling
	{
		/*static void Main(string[] args)
		{
			Console.WriteLine("Initializing...");
			Reader MyCsvReader = new Reader();
			Console.WriteLine("Initialization complete");
			Console.WriteLine("Input Filepath or blank for default: ");
			string userInput = Console.ReadLine();
			if (userInput == null ||  userInput == "")
				userInput = @"C:\Users\colto\Downloads\C++ Files\Boston.csv";
			MyCsvReader.ReadFile(userInput,500); //MyCsvReader.ReadFile(@"C:\Users\colto\Downloads\C++ Files\Boston.csv",500);
			Console.WriteLine("Number of records: " + MyCsvReader.getObservations());
			Console.WriteLine("Stats for rm: ");
			print_stats(MyCsvReader.getrm()); // first col (in ex = room count)
			Console.WriteLine("Stats for medv: ");
			print_stats(MyCsvReader.getmedv()); // 2nd col (in ex = median housing value)
			Console.WriteLine("Covariance = " + covar(MyCsvReader.getrm(),MyCsvReader.getmedv()));
			Console.WriteLine("Correlation = " + cor(MyCsvReader.getrm(),MyCsvReader.getmedv()));
			Console.WriteLine("Program terminated.");
			return;
		}*/
		public void print_stats(List<double> target)
		{
			Console.WriteLine("Sum of vector: " + sumVector(target));
			Console.WriteLine("Mean of vector: " + meanVector(target));
			Console.WriteLine("Median of vector: " + medianVector(target));
			Console.WriteLine("Range of vector: ");
			rangeVector(target);
		}
		public void printVector(List<double> target){
			Console.WriteLine("Printing vector: ");
			for (int i = 0; i < target.Count(); i++)
				Console.WriteLine(target[i]);
		}
		public double sumVector(List<double> target){
			double sum = 0;
			for (int i = 0; i < target.Count(); i++)
				sum += target[i];
				return sum;
		}
		public double meanVector(List<double> target){
			return (sumVector(target)/target.Count());
		}
		public double medianVector(List<double> target){
			if (target.Count() == 0)
				return 0;
			target.Sort();
			if (target.Count() % 2 == 0)
				return (target[target.Count() / 2 - 1] + target[target.Count() / 2]) / 2;
			else
				return target[target.Count() / 2];
		}
		public void rangeVector(List<double> target){
			double max = Double.MinValue;
			double min = Double.MaxValue;
			for (int i = 0; i < target.Count(); i++)
				if (target[i] > max)
					max = target[i];
				else if (target[i] < min)
					min = target[i];
			Console.WriteLine("    Min: " + min);
			Console.WriteLine("    Max: " + max);
		}
		public double covar(List<double> r, List<double> m){
			if (r.Count() != m.Count()){
				Console.WriteLine("Covariance matrix relies on the idea that each observation in rm corresponds to an observation in medv.\n Since the vectors are not of equal size, we cannot do a covariance matrix.");
				return 0.0;
			}
			double rMean = meanVector(r);
			double mMean = meanVector(m);
			double sum = 0;
			for (int i = 0; i < r.Count(); i++)
				sum += (r[i]-rMean)*(m[i]-mMean);
			return (sum/(r.Count()-1));
		}
		public double cor(List<double> r, List<double> m){
			double sum = 0;
			double rmSD, medvSD;
			double rmMean = meanVector(r);
			double medvMean = meanVector(m);
			for (int i = 0; i < r.Count(); i++)
				sum += ((r[i]-rmMean)*(r[i]-rmMean));
			sum = sum/(r.Count()-1);
			rmSD = Math.Sqrt(sum);
			sum = 0;
			for (int i = 0; i < m.Count(); i++)
				sum += ((m[i]-medvMean)*(m[i]-medvMean));
			sum = sum/(m.Count()-1);
			medvSD = Math.Sqrt(sum);
			return (covar(r,m)/(rmSD*medvSD));
		}
	}
