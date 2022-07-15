using System;
using System.Collections.Generic;
using System.Linq;

namespace IEnumerableCasting{
    class IEnumerableCasting{
        // I'm doing this to test for the casting ofIEnumerables to other vars.
        // and vice versa. It worked Very simple just like the normal inreface
        // remember upcast is implicit and downcast is explicit
        static void Main(String[] args){
            List<string> testVar = new List<string>(){"Paul","Tom","John"};
            ResponseStore oneObj = new ResponseStore(testVar);
            foreach(string oneVar in testVar){
                Console.WriteLine(oneVar);
            }
            Console.WriteLine();
            // sO YOU CAN ALSO DECLARE IT WITH THE IENUMERABLE since its an upcast which is an
            // implicit casting. Congrats.
            IEnumerable<string> testing = new List<string>(){"Paul","Tom","jOHN"};
            // you see it works.

            // always remember a Linq query result is an IEnumerable
            IEnumerable<string> finalResult = testing.Where(i => i == "Paul");
            foreach(string oneVar in finalResult){
                
                Console.WriteLine(oneVar);
            }
        }
    }
    public class ResponseStore{
        private static List<string> response;
        
        // Constructor
        public ResponseStore(List<string> respon){
            // this keyword is not valid for a static variable.
            //this.response = respon;
            response = respon;
        }
        /* However since List implements the IEnumerable you can return a list into an
         IEnumerable type. But we can not convert an Enumerable to a list. Meaning that
         we can actually convert a list to an IEnumerable but not vice versa.*/
        public static IEnumerable<string> Response{
            // this keyword is not valid for a static variable.
            // This is implicit conversion here.
            // but rememeber to never declare a list together with the IEnumerable<>
            // during declaration.
            get{ return response;}
            // the settter method wont work cause that is a downcast and hence requires
            // explicit casting ulike the get which is an upcast.
        }
    }
}