using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace BasicML
{
    internal class Operations
    {
        private Dictionary<int, string> memory = new Dictionary<int, string>();

        // Constructor

        // test function
        public Operations(string filePath)
        {
            InitializeMemory(filePath);
        }

        // Method to initialize memory from file

        // test function
        private void InitializeMemory(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                if (line.Length >= 4) // Ensure line is at least 4 characters long
                {
                    Console.WriteLine($"Splitting {line}");
                    var key = line.Substring(1, 2);
                    Console.Write(key);
                    Console.WriteLine();

                    var value = line.Substring(3, 2);

                    Console.Write(value);
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }

        // Read from keyboard and store in memory
        public void Read(int location)
        {
            Console.Write("Enter a value: ");
            string input = Console.ReadLine();
            memory[location] = input;
        }

        // Write to screen from memory
        public void Write(int location)
        {
            if (memory.ContainsKey(location))
                Console.WriteLine($"Value at location {location}: {memory[location]}");
            else
                Console.WriteLine($"Location {location} is empty.");
        }

        // Store accumulator value into memory
        public void Store(int location, int accumulator)
        {
            memory[location] = accumulator.ToString();
        }

        // Load value from memory into accumulator
        public void Load(int location, ref int accumulator)
        {
            if (memory.ContainsKey(location))
                accumulator = int.Parse(memory[location]);
            else
                Console.WriteLine($"Location {location} is empty.");
        }
        // indexer: instruction code as key value
        // instructions dictionary
        public string this[int instruction]
        {
            get
            {
                return memory.ContainsKey(instruction) ? memory[instruction] : null;
            }
        }
    }
}
