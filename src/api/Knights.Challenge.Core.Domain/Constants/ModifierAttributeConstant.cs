namespace Knights.Challenge.Core.Domain.Constants
{
    public static class ModifierAttributeConstant
    {
        public static Dictionary<int, int> Table
        {
            get
            {
                return new Dictionary<int, int>()
                {
                    { 8, -2 },
                    { 10, -1 },
                    {12, 0 },
                    { 15, 1 },
                    { 18, 2 },
                    { 20, 3 },
                };
            }
        }

        public static int GetValue(int number) {
            
            var mod = 0;

            foreach (var attr in Table)
            {
                if (number <= attr.Key)
                {
                    mod = attr.Value;
                    break;
                }
            }

            return mod;
        }
    }
}
