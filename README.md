# Random Permutation Generator (C#)

This solution generates a random permutation of integers between 1 and 10,000  
using the [Fisher–Yates shuffle algorithm](https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle).  

It ensures:
- Every number between 1 and 10,000 appears exactly once
- The order is uniformly random each time the program runs
- Time complexity: O(n)
- Space complexity: O(n)
- Basic exception handling is included (e.g., file writes, logging)
- Logging outputs to both console and a timestamped log file for traceability
- Inline documentation explains algorithm choices and design decisions

---

## Projects in this Solution

- RandomPermutationApp – functional/static version (simple static method).
- RandomPermutationTests – unit tests for the functional version.
- RandomPermutationOOApp – object-oriented version encapsulated in a class.
- RandomPermutationOOTests – unit tests for the OO version.

---

## Setup Instructions

Requires:
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download)  
- [Git](https://git-scm.com/downloads) to clone the repository  

Run the following commands in Windows CMD or PowerShell:

:: Clone the repository
git clone https://github.com/<your-username>/RandomPermutationSolution.git

:: Navigate into the solution folder
cd RandomPermutationSolution

:: Build the solution
dotnet build

:: Run the functional version
dotnet run --project RandomPermutationApp

:: Run the object-oriented version
dotnet run --project RandomPermutationOOApp

:: Run all tests (functional + OO)
dotnet test --logger "console;verbosity=detailed"

:: Run only the functional version tests
dotnet test RandomPermutationTests --logger "console;verbosity=detailed"

:: Run only the object-oriented version tests
dotnet test RandomPermutationOOTests --logger "console;verbosity=detailed"

##Notes

- Output includes a summary of the permutation (length, uniqueness check, range, sample of first 20 values).
- The full permutation is dumped into a timestamped text file inside a permutations folder.
- A log file (RandomPermutation.log / RandomPermutationOO.log) is created in the base folder with timestamped entries.
- Both functional and OO solutions include unit tests to verify correctness.
