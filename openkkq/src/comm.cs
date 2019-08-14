namespace openkkq
{

    public partial class program
    {
        private class comm
        {
            private readonly string[] _keys;

            public comm(string input)
            {
                _keys = input.Split(' ');
                main = _keys[0];
                ArgsCount = _keys.Length - 1;
            }

            public string main { get; }

            public int ArgsCount { get; }

            public string getkey(int i)
            {
                if (i >= 0 && i < ArgsCount)
                    return _keys[i + 1];
                return "";
            }
        }
      
     
     


    }

    //игра заканчивается тут
}