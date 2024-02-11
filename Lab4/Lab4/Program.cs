using System;
using System.Reflection;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("Toyota", 2022, "Camry", "Red", 25000.0);

            // 2. Продемонструвати роботу з Type і TypeInfo;
            TypeInfo typeInfo = car.GetType().GetTypeInfo();
            Type type = typeInfo.AsType();
            
            Console.WriteLine($"Full Name: {typeInfo.FullName}, Name: {typeInfo.Name}");
            Console.WriteLine($"Is Interface: {typeInfo.IsInterface}");
            Console.WriteLine($"Is Abstract: {typeInfo.IsAbstract}");
            Console.WriteLine($"IsClass: {typeInfo.IsClass}");
            Console.WriteLine($"Is Sealed: {typeInfo.IsSealed}");
            Console.WriteLine($"Assembly: {type.Assembly}");
            Console.WriteLine($"Attributes: {type.Attributes}");

            // 3. Продемонструвати роботу з MemberInfo;
            Console.WriteLine("\nMemberInfo: ");
            MemberInfo[] members = typeInfo.GetMembers();
            Console.Write("There are {0} members in ", members.GetLength(0));
            foreach (var member in members)
            {
                Console.WriteLine($"{member.MemberType}: {member.Name}, ReflectedType: {member.ReflectedType}, Module: {member.Module}");
            }

            // 4. Продемонструвати роботу з FieldInfo;
            Console.WriteLine("\nFieldInfo: ");
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (var field in fields)
            {
                Console.WriteLine($"Field: {field.Name}, Value: {field.GetValue(field.IsStatic ? null : car)}, Type: {field.FieldType}, " +
                    $"Attributes: {field.Attributes}");
            }

            // 5. Продемонструвати роботу з MethodInfo. Викликати будь-який метод через Reflection;
            Console.WriteLine("\nMethodInfo:");
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (var method in methods)
            {
                Console.WriteLine($"Name: {method.Name}, Attributes: {method.Attributes}, ReturnParameter: {method.ReturnParameter}, " +
                    $"ReturnType: {method.ReturnType}, IsPublic: {method.IsPublic}");
            }

            Console.WriteLine();

            MethodInfo start = type.GetMethod("Start");
            MethodInfo accelerate = type.GetMethod("Accelerate", BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo brake = type.GetMethod("Brake", BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo checkPrice = type.GetMethod("CheckPrice");

            start.Invoke(car, null);
            accelerate.Invoke(car, null);
            brake.Invoke(car, null);
            checkPrice.Invoke(car, new object[] { 20000.0 });
        }
    }
}