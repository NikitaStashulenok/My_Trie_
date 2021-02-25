using System;

namespace My_Trie
{
    class Program
    {
        static void Main(string[] args)
        {
            var trie = new Trie<int>();
            trie.Add("привет", 500);
            trie.Add("пока", 250);
            trie.Add("прелюдия", 50);
            trie.Add("машина", 600);
            trie.Add("маша", 1000);
            trie.Add("моль", 20);
            trie.Add("кирпич", 59);
            trie.Add("кирка", 48);

            trie.Remove("прелюдия");
            trie.Remove("моль");
            trie.Remove("лошадь");


            Search(trie, "кирка");
            Search(trie, "прелюдия");
            Search(trie, "каша");
            Console.ReadKey();
        }

        private static void Search(Trie<int> trie, string word)
        {
            if (trie.TrySearch(word + " ", out int value))
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine($"Не найдено :( -> {word}");
            }
        }
    }
}
