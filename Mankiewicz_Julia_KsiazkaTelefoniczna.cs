using System;

namespace BookTelepfone.ConsoleApp
{
    static class BookTelephone
    {
        public static SortedDictionary<string, string> numbers = new SortedDictionary<string , string>
        {
            {"123456789", "Jan Kowalski"},
            {"672839145", "Paulina Nowak"},
            {"556790354", "Weronika Buk"},
            {"346720987", "Natalia Kozak"},
            {"345298734", "Karolina Krzemyk"},
            {"657820142", "Tomasz Pyk"},
            {"234091324", "Maciej Powalczyk"},
            {"985430265", "Dorota Wlaczyk"},
            {"987354620", "Patryk Sajek"},
            {"897345102", "Ryszard Gołba"}

        };
        
        public static void Main(string[] args)
        {
            ConsoleKeyInfo KeyInfo;
            void ShowWholeBook()
            {
                foreach (KeyValuePair<string, string> product in numbers)
                {
                        Console.WriteLine($" - {product.Value} - {product.Key}");
                }
                
                Console.ReadKey();
                
            }
            void HuntWithName()
            {
                Console.Clear();
                Console.WriteLine("Podaj Imię i Nazwisko:");
                string nameAndSurename = Console.ReadLine();


                
                if (LookForKey(numbers, nameAndSurename) != null)
                {
                    string key = LookForKey(numbers, nameAndSurename);
                    Console.WriteLine($"Numer telefonu {nameAndSurename} - {key}");
                }
                else
                {
                    Console.WriteLine($"Nie odnaleziono osoby: {nameAndSurename}");
                }
                Console.ReadLine();
            }
            void HuntWithNumberPhone()
            {
                Console.Clear();
                
                Console.WriteLine("Podaj numer telefonu:");
                string lookforname = Console.ReadLine();
                if(numbers.TryGetValue(lookforname, out string person))
                {
                    Console.WriteLine($"Ten numer telefonu należy do: {person}");
                }
                else
                {
                    Console.WriteLine("Nie znaleziono takiego numeru w bazie");
                }
                Console.ReadKey();
            }


            void AddNewContact()
            {
                
                Console.Clear();
                    
                Console.WriteLine("Podaj Imie i Nazwisko");
                string surenameAndName = Console.ReadLine();
                Console.WriteLine("Podaj numer telefonu");
                string numer = Console.ReadLine();
                numbers.Add(numer, surenameAndName);
                

            }
            do
            {
                Console.Clear();
                Console.WriteLine("Wybierz czynność:");
                Console.WriteLine("[w]  Wyświetlanie całej książki telefonicznej");
                Console.WriteLine("[s] Szukanie po nazwisku i imieniu");
                Console.WriteLine("[a] Szukanie po numerze telefonu");
                Console.WriteLine("[d] Dodawanie nowego wpisu do książki");

                char choice = char.Parse(Console.ReadLine());

                if (choice == 'w')
                {
                    ShowWholeBook();
                }
                if (choice == 's')
                {
                    HuntWithName();
                }
                if (choice == 'a')
                {
                    
                    HuntWithNumberPhone();
                }
                if (choice == 'd')
                {
                    AddNewContact();
                }
               
                


            }
            while (true);
            
 
 
        }
        public static T LookForKey<T, W>(this SortedDictionary<T, W> numbers, W value) 
        {
            T key = default;
            foreach (KeyValuePair<T, W> pair in numbers)
            {
                if (EqualityComparer<W>.Default.Equals(pair.Value, value))
                {
                    key = pair.Key;
                    break;
                }
            }
            return key;
        }
    }
}