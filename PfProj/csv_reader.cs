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

class read_csv
{
	private string filePath;
	private string rm_in, medv_in; // avg, median for linear regression modeling
	private List<double> rm;
	private List<double> medv;
	
	public csvReader(string filePath)
    {
        filePath = filePath;
        rm = new List<double>();
        medv = new List<double>();
    }
	
	public void ReadFile()
    {
        StreamReader reader;
        string line;
		if (!filePath)
			filePath = "Boston.csv"; // default
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
			
			int numObservations = 0;
			while ((line = sr.ReadLine()) != null){
                    var values = line.Split(',');
                    rm_in = values[0];
                    medv_in = values[1];

                    rm.Add(Convert.ToDouble(rm_in));
                    medv.Add(Convert.ToDouble(medv_in));

                    numObservations++;
                }
				
			rm.resize(numObservations);
			medv.resize(numObservations);
			Console.WriteLine("New length: " + rm.Count);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
            return;
        }
        finally
        {
            if (reader != null)
				Console.WriteLine("Closing file");
                reader.Close();
        }
	
	public List<double> getrm(){ return rm; }
	public List<double> getmedv(){ return medv; }
    }
