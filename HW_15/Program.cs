using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HW_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///1.С помощью рефлексии получить список методов класса Console и вывести на экран
            Type consoleType = typeof(Console);

            MethodInfo[] methods = consoleType.GetMethods();

            foreach (var method in methods)
            {
                Console.WriteLine(method.Name);
            }

            Console.WriteLine("\n\n**************************\n\n");

            ///2.Описать класс с несколькими свойствами. Создать экземпляр класса и инициализировать его свойства. 
            ///С помощью рефлексии получить свойства и их значения из созданного экземпляра класса. 
            ///Вывести полученные значения на экран
            MyClass myObject = new MyClass { Property1 = 42, Property2 = "Hello, Reflection!" };

            Type myType = myObject.GetType();

            PropertyInfo[] properties = myType.GetProperties();
            foreach (var property in properties)
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(myObject)}");
            }

            Console.WriteLine("\n\n**************************\n\n");

            ///3.С помощью рефлексии вызвать метод Substring класса String и извлечь из строки подстроку заданного размера.
            string originalString = "Hello, who are you? I am yuu, What?";

            Type stringType = typeof(string);

            MethodInfo substringMethod = stringType.GetMethod("Substring", new Type[] { typeof(int), typeof(int) });

            object[] parameters = { 7, 5 }; 
            string result = (string)substringMethod.Invoke(originalString, parameters);

            Console.WriteLine(result);

            Console.WriteLine("\n\n**************************\n\n");

            ///4. Получить список конструкторов класса List<T>
            Type listType = typeof(List<>);

            ConstructorInfo[] constructors = listType.GetConstructors();

            foreach (var constructor in constructors)
            {
                Console.WriteLine(constructor);
            }
        }
    }
}
