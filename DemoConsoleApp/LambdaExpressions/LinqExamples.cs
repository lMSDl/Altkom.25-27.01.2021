using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp.LambdaExpressions
{
    public class LinqExamples
    {
        int[] numbers = new[] { 1, 3, 4, 2, 5, 7, 8, 6, 9, 0 };
        List<string> strings = "wlazł kotek na płotek i mruga".Split(' ').ToList();

        List<Person> students = new List<Person>
        {
            new Person { FirstName = "Adam", LastName = "Adamski", BirthDate = new DateTime(1978, 2, 21), Gender = Gender.Male },
            new Person { FirstName = "Ewa", LastName = "Ewowska", BirthDate = new DateTime(2000, 1, 1), Gender = Gender.Female  } ,
            new Person { FirstName = "Adam", LastName = "Ewowska", BirthDate = new DateTime(1978, 2, 21), Gender = Gender.Male },
            new Person { FirstName = "Ewa", LastName = "Adamska", BirthDate = new DateTime(1994, 1, 1), Gender = Gender.Female  } ,
            new Person { FirstName = "Piotr", LastName = "Adamski", BirthDate = new DateTime(1978, 2, 21), Gender = Gender.Male },
            new Person { FirstName = "Kamila", LastName = "Ewowska", BirthDate = new DateTime(1934, 1, 1), Gender = Gender.Female  } ,
    };

        public void Test()
        {
            var queryResilt1 = from item in numbers where item > 4 select item;
            var queryResilt1_ = from item in numbers where item < 4 || item > 7 select item;
            var queryResult2 = numbers.Where(item => item > 4).ToList();
            var queryResult3 = numbers.Where(item => item > 4).OrderBy(x => x).ToList();
            var queryResult4 = numbers.Where(item => item > 4).OrderByDescending(x => x).ToList();
            var queryResult5 = numbers.Where(item => item > 4 && item < 7).ToList();
            var queryResult6 = numbers.Where(item => item > 4).Where(item => item < 7).ToList();
            var queryResult7 = numbers.Where(item => item < 4 || item > 7).ToList();

            var queryResult8 = strings.Where(x => x.Length == 5).Select(x => x.ToUpper()).ToList();
            var queryResult9 = strings.Select(x => x.Length).Where(x => x != 5).ToList();

            var queryResult10 = students.Where(x => x.LastName == "Adamski").Select(x =>
            {
                var item = $"{x.LastName} {x.FirstName}";
                return item;
            }).ToList();

            //TODO wybierz studentów o imieniu Ewa

            //TODO Wybierz studentów urodzonych przed 1990 rokiem

            //TODO wybierz pierwszego studenta, który ma w nazwisku "Adam" i jest kobietą

            //TODO posortuj studentów po nazwisku a następnie o imieniu

            //TODO wybierz datę urodzenia najmłodszej kobiety (ze studentów)

            //TODO podaj średni wiek studentów

        }
    }
}
