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

namespace PfProj.Services;
	public class Reader
	{
		private string filePath;
		private string rm_in, medv_in; // avg, median
		private List<double> rm = new List<double>(); // test
		private List<double> medv = new List<double>(); // target
		private int numObservations = 0;
		
		public Reader(){}

		public void ReadFile(string fP, int observationLimit, string testingName, string targetName)
		{
			StreamReader reader;
			string? line;
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
				// Expanded Functionality to Specify Columns
				String[] ColumnNames = line.Split(',');
				// snip off ""
				for(int i = 0; i < ColumnNames.Length; i++)
				{
					ColumnNames[i] = ColumnNames[i].Trim().Substring(1,ColumnNames[i].Length-2);
					//Console.WriteLine(ColumnNames[i].ToString()); // VERBOSE
				}
				// find index of test and target
				int testingColIndex = Array.IndexOf(ColumnNames, testingName);
				int targetColIndex = Array.IndexOf(ColumnNames, targetName);
				if (testingColIndex == -1)
					Console.WriteLine(testingName + " was not found in header");
				if (targetColIndex == -1)
					Console.WriteLine(targetName + " was not found in header");
				if (testingColIndex == -1 || targetColIndex == -1)
					return;
				// read rows
				while ((line = reader.ReadLine()) != null && (numObservations < observationLimit)){
					var values = line.Split(',');
					rm_in = values[testingColIndex];
					medv_in = values[targetColIndex];

					rm.Add(Convert.ToDouble(rm_in));
					medv.Add(Convert.ToDouble(medv_in));

					numObservations++;
				}
			Console.WriteLine("Closing file");
			reader.Close();
			}
			//Console.WriteLine("Length: " + rm.Count);
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
