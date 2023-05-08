using System;
using System.Collections.Generic;
using System.Drawing;

namespace GradingSystem
{
    class PrintTable
    {
        static void Main(string[] args)
        {
            MyGrades numbofTab = new MyGrades();
            numbofTab.PrintGrades();
            numbofTab.CalcGPA();
        }
    }
    class MyGrades
    {   
        // Declaring the vai
        public List<string> coursCode = new();
        public List<double> coursUnit = new();
        public List<string> grade = new();
        public List<int> gradeUnit = new();
        public List<int> weiPnt = new();
        public List<string> remrk = new();
        public double score;
        public int numbOfSub;
        public void PrintGrades()
        {   
            // Asking the user to put in the number of subjects he would like to offer
            Console.Write("How many subjects do you offer? ");
            numbOfSub = Convert.ToInt32(Console.ReadLine());
            
            // For loop to loop through and take in details based on the users number of subjects 
            for (int i = 0; i < numbOfSub; i++)
            { 
                Console.Write(" Enter Course title and code: ");
                coursCode.Add(Console.ReadLine());
                Console.Write("Enter Course Unit: ");
                coursUnit.Add(Convert.ToDouble(Console.ReadLine()));
                
                Console.Write("Enter your Score: ");
                score = Convert.ToDouble((Console.ReadLine()));
                Console.Clear();

                grade.Add(score >= 70 ? "A" : score >= 60 ? "B" : score >= 50 ? "C" : score >= 45 ? "D" : score >= 40 ? "E" : "F");
                gradeUnit.Add(score >= 70 ? 5 : score >= 60 ? 4 : score >= 50 ? 3 : score >= 45 ? 2 : score >= 40 ? 1 : 0);
                remrk.Add(gradeUnit[i] == 5 ? "Excellent" : gradeUnit[i] == 4 ? "Very Good" : gradeUnit[i] == 3 ? "Good" : gradeUnit[i] == 2 ? "Fair" : gradeUnit[i] == 1 ? "Pass" : "Fail");
                weiPnt.Add((int)coursUnit[i] * gradeUnit[i]);
            }
            // Top Header table for arrangement of user details.
            Console.WriteLine("       |------------------|----------------|------------|--------------|--------------|------------|");
            Console.WriteLine("       |  COURSE & CODE   |   COURSE UNIT  |    GRADE   |  GRADE-UNIT  |   WEIGHT Pt. |   REMARK   |");
            Console.WriteLine("       |------------------|----------------|------------|--------------|--------------|------------|");

            // Loop to print results per the subject counts inputed by the user
            for (int i = 0; i < numbOfSub; i++)
            {
                Console.WriteLine($"       |     {coursCode[i]}       |       {coursUnit[i]}        |     {grade[i]}      |      {gradeUnit[i]}       |      {weiPnt[i]}       |   {remrk[i]}     |");
            }
            Console.WriteLine("\n");
        }
        public void CalcGPA()
        {
            // GPA
            double totalCourseUnit = coursUnit.Sum();
            int totalWeigthPoint = weiPnt.Sum();
            int totalGradeunit = gradeUnit.Sum();
            // GPA = total weightPoint / total courseUnit
            double Gpa = totalWeigthPoint / totalCourseUnit;
            string GpaIn2Decimal = Gpa.ToString("F2");

            // Total course Unit registered
            Console.WriteLine($"Total course Unit registered: {totalCourseUnit}");

            // Total Course Unit Passed
            Console.WriteLine($"Total Course Unit Passed: {totalGradeunit}");

            //Total Weight Point is 
            Console.WriteLine($"Total Weight Point is: {totalWeigthPoint}");

            Console.WriteLine($"Your GPA is: {GpaIn2Decimal}");
        }
    }
}
