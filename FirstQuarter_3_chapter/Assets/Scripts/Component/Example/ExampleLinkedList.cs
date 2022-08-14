using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{

    public sealed class ExampleLinkedList
    {
        private sealed class User
        {
            public string FirstName { get; }
            public string LastName { get; }

            public User (string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }
        }

        List<string> name = new List<string> ();

        List<int> id = new List<int> ();

        public int idCount = 0;
        public void Main()
        {
            id.Add (1);
            id.Add (2);
            id.Add (3);
            id.Add (4);
            id.Add (3);

            for(int i = 0; i < id.Count; i++)
            {
                if(id[i] == 3)
                {
                    idCount++;
                }
            }
            Debug.Log($"Количество цифры 3 в листе : {idCount}");//2 раза

            idCount = 0;
            for(int i = 0; i < id.Count; i++)
            {
                for(int j = 0; j < id.Count; j++)
                {
                    if(id[i] == id[j])
                    {
                        idCount++;
                    }
                }
                Debug.Log($"Количество {id[i]} в коллекции = {idCount}");
                idCount = 0;
            }

            name.Add("Test");
            name.Add("Example");
            name.Add("Apple");
            name.Add("Beacon");
            name.Sort ();

            for(int i = 0; i < name.Count; i++)
            {
                Debug.Log (name [i]);
            }
            LinkedList<int> numbers = new LinkedList<int> ();

            numbers.AddLast (1);
            numbers.AddFirst (2);
            numbers.AddAfter (numbers.Last, 3);

            Debug.Log(numbers);
            foreach(int i in numbers)
            {
                //Debug.Log (i);
            }

            LinkedList<User> person = new LinkedList<User> ();



            LinkedListNode<User> users = person.AddLast(new User("Lera", "Petrova"));
            person.AddLast(new User("Igor", "Ivanov"));
            person.AddFirst(new User("Ilya", "Petrov"));

            Debug.Log(users.Previous.Value.FirstName);
            Debug.Log(users.Previous.Value.LastName);
        }
    }
}
