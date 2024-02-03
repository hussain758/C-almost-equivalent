bool StringsAreAlmostEquivalent(string s1, string s2)
{
    // check if strings length is equal
    if (s1.Length != s2.Length)
    {
        return false;
    }

    // build differences dictionary
    Dictionary<char, int> differences = new Dictionary<char, int>();
    
    //s1 = "abaa"
    // ( " a = 3  " )
    //("  b= 1   ")


    foreach (char c in s1)
    {
        if (differences.Keys.Contains(c))
        {
            differences[c]++;
        }
        else
        {
            differences.Add(c, 1);
        }
    }

    // s2 = "abbc"
    // ( " a = 2  " )
    //("  b= -1   ")
    //(  " c = -1 ")
    foreach (char c in s2)
    {
        if (differences.Keys.Contains(c))
        {
            differences[c]--;
        }
        else
        {
            differences.Add(c, -1);
        }
    }


    // ( " a = 2  " )
    //("  b=  1   ")
    //(  " c =  1 ") 

    foreach(KeyValuePair<char, int> entry in differences)
    {
         
        if (Math.Abs(entry.Value) > 3)
        {
            return false;
        }
    }


    return true;
}

string[] AreAlmostEquivalent(string[] s, string[] t)
{
    string[] output = new string[s.Length];

    // check if array lengths are equal
    if (s.Length != t.Length) throw new Exception("Arrays are not equal");

    for (int i=0; i<s.Length; i++)
    {
        output[i] = StringsAreAlmostEquivalent(s[i], t[i]) ? "YES" : "NO";
    }

    return output;
}

string[] s = {"aabaab", "aaaaabb", "test2222"};
string[] t = {"bbabbc", "abb", "test1112"};

string[] output = AreAlmostEquivalent(s, t);
for (int i=0; i<output.Length; i++)
{
    Console.WriteLine(output[i]);
}