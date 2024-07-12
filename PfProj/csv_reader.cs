/* Filename: csv_reader.cs
 * Author: Colton Townsend
 * Date: Created 7/10/2024
 * Procedures:
 * csvReader - default constructor
 * ReadFile - populates two vectors using a .csv at filePath.
 * getrm - self describing
 * getmedv - self describing
 */
using System;
using System.IO;
using System.Collections.Generic;

namespace PfProj
{
	public class Reader
	{
		private string filePath;
		private string rm_in, medv_in; // avg, median
		private List<double> rm = new List<double>();
		private List<double> medv = new List<double>();
		private int numObservations = 0;
		
		public Reader(){}
		public void ReadFile(string fP, int observationLimit)
		{
			StreamReader reader;
			string line;
			filePath = fP;
			Console.WriteLine("Opening file " + this.filePath);
			try
			{
				reader = new StreamReader(this.filePath);
				if (reader == null)
				{
					Console.WriteLine("Could not open file " + this.filePath);
					return; // stop further execution
				}
				Console.WriteLine("Reading line 1");
				line = reader.ReadLine();
				Console.WriteLine("Heading: " + line);
				
				while ((line = reader.ReadLine()) != null && (numObservations < observationLimit)){
						var values = line.Split(',');
						rm_in = values[0];
						medv_in = values[1];

						rm.Add(Convert.ToDouble(rm_in));
						medv.Add(Convert.ToDouble(medv_in));

						numObservations++;
					}
					
				//Console.WriteLine("Length: " + rm.Count);
				Console.WriteLine("Closing file");
				reader.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error: " + e.Message);
				return;
			}
		} //EoF
		public List<double> getrm(){ return rm; }
		public List<double> getmedv(){ return medv; }
		public int getObservations(){return numObservations; }
	}
}
