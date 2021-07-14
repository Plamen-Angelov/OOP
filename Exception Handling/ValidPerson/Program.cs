using System;

namespace ValidPerson
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Student student = new Student(Console.ReadLine());
            }
            catch (InvalidPersonNameException se)
            {
                Console.WriteLine(se.TextMessage);
            }


            try
            {
                string firstName = Console.ReadLine();
                string lastName = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());

                Person person = new Person(firstName, lastName, age);
            
            }
            catch (NameLenghtException ne)
            {
                Console.WriteLine(ne.GetMessage);
            }
            catch (InvalidAgeException ae)
            {
                Console.WriteLine(ae.GetMessage);
            }
            //catch (ArgumentOutOfRangeException re)
            //{
            //    Console.WriteLine(re.Message);
            //}
            //catch (ArgumentException ae)
            //{
            //    Console.WriteLine(ae.Message);
            //}
        }
    }
}
