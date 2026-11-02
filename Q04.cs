using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Questions
{
    internal class Q04
    {
        public static void Main(string[] args)
        {
            int[][] technicianJobs = new int[4][];
            technicianJobs[0] = new int[] { 45, 60, 30 };
            technicianJobs[1] = new int[] { 90 };
            technicianJobs[2] = new int[] { };
            technicianJobs[3] = new int[] { 20, 35, 50, 40 };

            PrintReport(technicianJobs);

            Console.Write("Select Technician index (0 to 3): ");
            int selectedTech = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter new job duration in minutes: ");
            int newDuration = Convert.ToInt32(Console.ReadLine());

            int oldLength = technicianJobs[selectedTech].Length;
            int[] newRow = new int[oldLength + 1];

            for (int i = 0; i < oldLength; i++)
            {
                newRow[i] = technicianJobs[selectedTech][i];
            }
            newRow[oldLength] = newDuration;
            technicianJobs[selectedTech] = newRow;

            Console.WriteLine("\n--- Updated Workload Summary ---");
            PrintReport(technicianJobs);
        }

        private static void PrintReport(int[][] jobs)
        {
            string idleTechs = "";
            string overworkedTechs = "";

            for (int i = 0; i < jobs.Length; i++)
            {
                int count = jobs[i].Length;
                int totalMinutes = 0;

                for (int j = 0; j < count; j++)
                {
                    totalMinutes += jobs[i][j];
                }

                Console.WriteLine("Technician " + i + " - Jobs: " + count + ", Total Minutes: " + totalMinutes);

                if (count == 0)
                {
                    idleTechs += i + " ";
                }

                if (totalMinutes > 120)
                {
                    overworkedTechs += i + " (" + totalMinutes + " mins) ";
                }
            }

            Console.WriteLine("Technicians with no work: " + (idleTechs == "" ? "None" : idleTechs));
            Console.WriteLine("Technicians assigned more than 120 minutes: " + (overworkedTechs == "" ? "None" : overworkedTechs));
        }
    }
}
