namespace EnumTesting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var allSomethings = Something.GetAll();
            var joinedSomethings = string.Join(", ", allSomethings);
            Console.WriteLine(joinedSomethings);

            var joinedSomethingsFormatted = string.Join(", ", allSomethings.Select(x => $"{x.Key} - {x.Value}" ));
            Console.WriteLine(joinedSomethingsFormatted);

            var somethingFromKey = Something.FromKey("Charlie");
            Console.WriteLine(somethingFromKey);

            var somethingFromValue = Something.FromValue("AlphaValue");
            Console.WriteLine(somethingFromValue);

            ////////////////////////////////////
            
            Console.WriteLine("------------------");

            var allSomethingMores = SomethingMore.GetAll();
            var joinedSomethingMores = string.Join(", ", allSomethingMores);
            Console.WriteLine(joinedSomethingMores);

            var joinedSomethingsMoresFormatted = string.Join(", ", allSomethingMores.Select(x => $"{x.Key} - {x.Value}"));
            Console.WriteLine(joinedSomethingsMoresFormatted);

            var somethingMoreFromKey = SomethingMore.FromKey("Foxtrot");
            Console.WriteLine(somethingMoreFromKey);

            var somethingMoreFromValue = SomethingMore.FromValue("DeltaValue");
            Console.WriteLine(somethingMoreFromValue);

        }
    }
}
