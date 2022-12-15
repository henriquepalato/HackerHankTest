// See https://aka.ms/new-console-template for more information

using HackerHankTest;

List<List<int>> forest = new() {
    new() { 2, 1, 3, 2, 4 },
    new() { 2, 0, 2, 0, 1 },
    new() { 6, 2, 1, 3, 0 },
    new() { 3, 1, 0, 4, 3 },
    //12
};

List<List<int>> forest1 = new()
{
    new () { 2, 1, 3, 2, 4, 1},
    new () { 1, 0, 4, 0, 3, 2},
    new () { 6, 2, 5, 3, 0, 4},
    new () { 3, 1, 0, 4, 3, 2},
    new () { 2, 3, 2, 5, 1, 0},
    //60
};

Question.BusyBeaver(forest);
Console.WriteLine("----------------------------------");

Question.BusyBeaver(forest1);