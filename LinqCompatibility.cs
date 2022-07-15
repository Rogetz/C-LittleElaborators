using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqCompatibilityWithVariables{
    class LinqCompatibilityWithVariables{
        static void Main(String[] args){


            // USER DEFINED LIST
            List<NewObject> testObject = new List<NewObject>();
            NewObject objectOne = new NewObject("Paul",32);
            testObject.Add(objectOne);
            // Ensure you type cast the linq expression to an IEnumerable interface
            // if you are working with user defined objects.
            // Also dont implicitly convert the List object to an IEnumerable when
            // declaring the List of the user defiined object cause it will generate
            // an error.
            // Note that this means that in order for a List object to use the Linq lambda
            // expressions at any given point in time. It must implement the IEnumerable interface
            IEnumerable<NewObject> finalQuery = testObject.Where(i => i.Age > 20);
            // note that you can not implicitly convert a list object to an IEnumerable
            // and vice versa.
            foreach(NewObject obj in finalQuery){
                Console.WriteLine("My Name is {0} and am aged: {1}",obj.Name,obj.Age);
            }

            // PRIMITIVE TYPE LIST
            List<string> testString = new List<string>();
            testString.Add("Paul");
            testString.Add("Raul"); 
            // So it applies to all
            // To use the IEnumerable Interface use it at Linq POINTS cause you can
            // not implicitly convert it to a list and vice versa.
            IEnumerable<string> finalString = testString.Where(i => i == "Paul");


            // TRYING OUT THE IList
            IList<string> testString2 = new List<string>();
            testString2.Add("Paul");
            testString2.Add("Raul");
            // In short Linq lambda expressions are assumed to be of type IEnumerable
            // Thats why they can also not be implicitly cast to an IList.
            // However you can cast it through an explicit cast.
            // IList<string> finalString2 = testString2.Where(i => i == "Paul");
        }
    }
    public class NewObject{
        private string name;
        private int age;
        
        // constructor
        public NewObject(string testName, int testAge){
            this.name = testName;
            this.age = testAge; 
        }
        public string Name{
            get{return name;}
            set{name = value;}
        }
        public int Age{
            get{return age;}
            set{age = value;}
        } 
    }
}