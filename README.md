# Console Pulse

A collection of small, self-contained C# console programs exploring **data structures, algorithms, and benchmarking**. Each program lives in its own folder under [src/](src/) as a single `.cs` file using top-level statements — there are no `.csproj` or `.sln` files, since every file is a [file-based app](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/top-level-statements).

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download) or later (required for running `.cs` files directly with `dotnet run`, and for the `#:package` directive used by the benchmarks).

## Project Structure

```
src/
├── Benckmarks/                 # BenchmarkDotNet: MD5 vs SHA256 hashing benchmark
├── BigONotation/               # Interactive demo of O(1), O(log n), O(n), O(n²)
├── BigSorting/                 # Sorting huge numbers represented as strings
├── HeapRandomIntegers/         # Max-heap built from random integers
├── IntegersBinarySearchTree/   # Binary search tree with in-order traversal
└── InteractiveTrees/           # Expression tree built from an arithmetic expression
```

## How to Run Each File

All programs are run the same way — pass the `.cs` file directly to `dotnet run` from the repository root:

### BigSorting

Sorts a list of very large numbers (too big for `long`) kept as strings, using a custom `IComparer<string>` that compares by length first, then ordinally. Prints the input list and the sorted result.

```bash
dotnet run src/BigSorting/BigSorting.cs
```

### BigONotation

Interactive menu demonstrating algorithmic complexity on a sample array: **O(1)** get first element, **O(log n)** binary search, **O(n)** linear search, and **O(n²)** bubble sort. Choose options `1`–`4`, or `5` to exit.

```bash
dotnet run src/BigONotation/BigONotation.cs
```

### HeapRandomIntegers

Generates 10 cryptographically random integers (1–100) and inserts them one at a time into a **max-heap**, printing the heap's array representation after each insertion.

```bash
dotnet run src/HeapRandomIntegers/HeapRandomIntegers.cs
```

### IntegersBinarySearchTree

Inserts the integers `1..10` into a **binary search tree** and prints the in-order traversal.

```bash
dotnet run src/IntegersBinarySearchTree/IntegersBinarySearchTree.cs
```

### InteractiveTrees

Builds an **expression tree** for the arithmetic expression `( 4 * 8 ) / 6 - 3` using operator/operand stacks with precedence handling, then prints the tree with ASCII branches. Press <kbd>Enter</kbd> to exit.

```bash
dotnet run src/InteractiveTrees/InteractiveTrees.cs
```

### Benckmarks

Compares **MD5 vs SHA256** hashing performance with [BenchmarkDotNet](https://benchmarkdotnet.org/) (including memory diagnostics). The `#:package BenchmarkDotNet@0.14.0` directive restores the package automatically, and benchmarks run in-process since there is no project file. This one takes a few minutes to complete.

```bash
dotnet run src/Benckmarks/Benckmarks.cs
```

## License

Licensed under the [MIT License](LICENSE).
