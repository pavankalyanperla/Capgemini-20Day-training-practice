
/*
Domain: Healthcare – ICU Patient Monitoring

Real-World Scenario:
In an Intensive Care Unit (ICU), patient vital signs are monitored continuously to detect abnormal health conditions. Healthcare systems analyze heart rate, oxygen saturation (SpO₂), blood pressure, and timestamps to identify early warning signs and alert medical staff. In this assignment, you will implement core monitoring features using C# while strengthening your understanding of Arrays, Structures, Searching, Sorting, Sliding Window, and Problem Solving.

Learning Objectives

After completing this assignment, you will be able to:

Work with arrays of structures.
Implement sliding window algorithms.
Calculate averages and median values.
Perform searching and sorting without built-in collection classes.
Detect abnormal vital signs using threshold-based logic.
Write clean and modular C# code.
Problem Statement

A hospital stores a patient's vital signs every minute.

Each record contains:

Heart Rate (BPM)
Oxygen Level (SpO₂ %)
Systolic Blood Pressure
Diastolic Blood Pressure
Timestamp

Develop a monitoring system that identifies abnormal readings and generates useful reports. 
*/

using System;

class Program
{
    static void Main()
    {
    
            Vital[] vitals =
            {
                new Vital(72,98,120,80,new DateTime(2025,6,1,9,0,0)),
                new Vital(110,93,150,95,new DateTime(2025,6,1,9,1,0)),
                new Vital(85,97,125,82,new DateTime(2025,6,1,9,2,0)),
                new Vital(58,94,118,76,new DateTime(2025,6,1,9,3,0)),
                new Vital(90,99,130,85,new DateTime(2025,6,1,9,4,0))
            };

            FindAbnormal(vitals);
            AverageHeartRate(vitals);
            SearchByTime(vitals, new DateTime(2025,6,1,9,2,0));
            SortByHeartRate(vitals);
    }

    static void FindAbnormal(Vital[] vitals)
        {
            Console.WriteLine("\n--- Abnormal Readings ---");

            bool found = false;

            foreach (Vital v in vitals)
            {
                if (v.HeartRate < 60 || v.HeartRate > 100 ||
                    v.Oxygen < 95 ||
                    v.Systolic > 140 ||
                    v.Diastolic > 90)
                {
                    Console.WriteLine($"Time: {v.Time}");
                    Console.WriteLine($"HR: {v.HeartRate} BPM | SpO₂: {v.Oxygen}% | BP: {v.Systolic}/{v.Diastolic}");
                    Console.WriteLine();

                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No abnormal readings.");
        }
    static void AverageHeartRate(Vital[] vitals)
        {
            int sum = 0;

            foreach (Vital v in vitals)
                sum += v.HeartRate;

            double average = (double)sum / vitals.Length;

            Console.WriteLine("\nAverage Heart Rate: " + average);
        }
    static void SearchByTime(Vital[] vitals, DateTime time)
        {
            Console.WriteLine("\n--- Search Result ---");

            bool found = false;

            foreach (Vital v in vitals)
            {
                if (v.Time == time)
                {
                    Console.WriteLine($"HR: {v.HeartRate} BPM");
                    Console.WriteLine($"SpO₂: {v.Oxygen}%");
                    Console.WriteLine($"BP: {v.Systolic}/{v.Diastolic}");

                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("Record not found.");
        }


    static void SortByHeartRate(Vital[] vitals)
        {
            for (int i = 0; i < vitals.Length - 1; i++)
            {
                for (int j = 0; j < vitals.Length - i - 1; j++)
                {
                    if (vitals[j].HeartRate > vitals[j + 1].HeartRate)
                    {
                        Vital temp = vitals[j];
                        vitals[j] = vitals[j + 1];
                        vitals[j + 1] = temp;
                    }
                }
            }

        Console.WriteLine("\n--- Sorted by Heart Rate ---");

        foreach (Vital v in vitals)
        {
            Console.WriteLine($"HR: {v.HeartRate} BPM | SpO₂: {v.Oxygen}% | BP: {v.Systolic}/{v.Diastolic}");
        }
    }
}

class Vital{
        public int HeartRate;
        public int Oxygen;
        public int Systolic;
        public int Diastolic;
        public DateTime Time;

    public Vital(int heartRate, int oxygen, int systolic, int diastolic, DateTime time){
        HeartRate = heartRate;
        Oxygen = oxygen;
        Systolic = systolic;
        Diastolic = diastolic;
        Time = time;
    }
}


