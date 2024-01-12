using System.Collections;
const long input = 562949953421312;
const int totalLine = 40;
const string drawChar = "*";
const int ruleset = 225;
Main();

//reference for rules https://plato.stanford.edu/entries/cellular-automata/supplement.html
//https://mathworld.wolfram.com/ElementaryCellularAutomaton.html
static void Main()
{    
    var inputArray = Convert.ToString(input, 2);    
    int totalLength = (((inputArray.Length - 1) * 2) + 1);
    while (inputArray.Length < totalLength)
    {
        inputArray = "0" + inputArray;
    }
    PrintResult(inputArray);
    Console.WriteLine();
    int processedLine = 1;
    while(processedLine < totalLine)
    {
        inputArray = GetNewState(inputArray);
        PrintResult(inputArray);
        Console.WriteLine();
        processedLine++;
    }
    //SetConsoleColors(ConsoleColor.White, ConsoleColor.Black);
    

}

static void SetConsoleColors(ConsoleColor backgroundColor, ConsoleColor foregroundColor)
{
    Console.BackgroundColor = backgroundColor;
    Console.ForegroundColor = foregroundColor;
}
static string CalculateState(string left,string middle,string right)
{
    var ruleInBinary = Convert.ToString(ruleset, 2);
    while(ruleInBinary.Length < 8)
    {
        ruleInBinary = "0" + ruleInBinary;
    }

    if (left == "1" && middle == "1" && right == "1") return ruleInBinary[0].ToString();
    if (left == "1" && middle == "1" && right == "0") return ruleInBinary[1].ToString();
    if (left == "1" && middle == "0" && right == "1") return ruleInBinary[2].ToString();
    if (left == "1" && middle == "0" && right == "0") return ruleInBinary[3].ToString();
    if (left == "0" && middle == "1" && right == "1") return ruleInBinary[4].ToString();
    if (left == "0" && middle == "1" && right == "0") return ruleInBinary[5].ToString();
    if (left == "0" && middle == "0" && right == "1") return ruleInBinary[6].ToString();
    if (left == "0" && middle == "0" && right == "0") return ruleInBinary[7].ToString();
    return "0";
}

static void PrintResult(string state)
{
    for (int i = 0; i<state.Length; i++)
    {
        if (state[i].ToString() == "0")
        {
            SetConsoleColors(ConsoleColor.White, ConsoleColor.Black);
           
            Console.Write(drawChar);
            
            Console.ResetColor();
        }
        else
        {            
            Console.Write(drawChar);
            
        }
    }
}

static string GetNewState(string currentState)
{
    string newstate = string.Empty;
    newstate += currentState[0];
    for (int i = 1; i<currentState.Length-1; i++)
    {
        string curr = CalculateState(currentState[i-1].ToString(), currentState[i].ToString(), currentState[i+1].ToString());
        newstate += curr;
    }
    newstate += currentState[currentState.Length-1];
    return newstate;
}