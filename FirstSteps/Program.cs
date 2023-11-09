namespace FirstSteps
{
    public class Types
    {
        static void Main(string[] args)
        {
            static void KnowingTypes()
            {
                int intNumber = 0;

                float floatNumber = 10.9f;

                double doubleNumber = 0d;

                decimal decimalNumber = 30.1m;

                bool boolValue = false;

                char character = 'a';

                string str = "Vagner";

                var city = "Iguatu";

                var age = 25;

                Console.Write($"{age}, {city}, {str}, {character}, {boolValue}, {decimalNumber}, {doubleNumber}, {floatNumber}, {intNumber}");
            }

            KnowingTypes();
        }
    }
}