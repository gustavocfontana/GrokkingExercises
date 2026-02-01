# GrokkingExercises

Simple console app to practice exercises by chapter using Clean Architecture.

## Structure

```
GrokkingExercises/
├── Core/
│   └── Domain/
│       └── Exercises/
│           └── Chapter01/
│               ├── BinarySearch.cs
│               └── BinarySearchExercises.cs
├── Presentation/
│   └── Console/
│       ├── ConsoleMenu.cs
│       └── Menus/
│           └── Chapter01Runner.cs
├── Infrastructure/
│   └── IO/
│       ├── IConsoleIO.cs
│       └── ConsoleIO.cs
└── Program.cs
```

## Layers

- **Core/Domain** - Business logic and exercises
- **Presentation/Console** - UI layer (menus, runners)
- **Infrastructure/IO** - External dependencies (console IO)

## Run

```zsh
cd /Users/gustavofontana/RiderProjects/GrokkingExercises/GrokkingExercises
dotnet run
```
