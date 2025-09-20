using System;
using System.IO;
using System.Linq;

namespace RandomPermutationApp
{
    public class Program
    {
        /// <summary>
        /// Entry point for the functional Random Permutation generator.
        /// Logs summary information to console and a log file,
        /// and dumps the full permutation into a timestamped text file.
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Functional ---");

            int n = 10000;
            var perm = PermutationGenerator.Generate(n);

            // Use application base directory for consistent paths.
            // This ensures the program behaves the same whether run
            // from an IDE or from the command line.
            string baseFolder = AppContext.BaseDirectory;
            string logFilePath = Path.Combine(baseFolder, "RandomPermutation.log");
            string fullLogPath = Path.GetFullPath(logFilePath);

            string dumpFolder = Path.Combine(baseFolder, "permutations");
            Directory.CreateDirectory(dumpFolder);

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
            string dumpFilePath = Path.Combine(dumpFolder, $"Permutation_{timestamp}.txt");
            string fullDumpPath = Path.GetFullPath(dumpFilePath);

            // Capture the writer in a using block, ensuring it's closed/disposed properly.
            using (var writer = new StreamWriter(logFilePath, append: true))
            {
                // Local helper method for logging to both console and log file.
                void Log(string message)
                {
                    Console.WriteLine(message);

                    string timestamped = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] {message}";
                    try
                    {
                        writer.WriteLine(timestamped);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR: Failed to write log file: {ex.Message}");
                    }
                }

                // ---- Write summary ----
                Log($"Length: {perm.Count}");
                Log($"Unique: {perm.Distinct().Count() == perm.Count}");
                Log($"Range: {perm.Min()} - {perm.Max()}");
                Log("Sample (first 20): " + string.Join(", ", perm.Take(20)));

                // ---- Dump full permutation to file ----
                try
                {
                    File.WriteAllLines(dumpFilePath, perm.Select(num => num.ToString()));
                    Log($"Full permutation written to {fullDumpPath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: Failed to write permutation file: {ex.Message}");
                }

                Log(new string('-', 40));
                Console.WriteLine($"Output also written to {fullLogPath}");
            }
        }
    }
}
