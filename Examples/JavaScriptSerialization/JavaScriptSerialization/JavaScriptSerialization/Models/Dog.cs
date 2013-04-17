using JavaScriptSerialization.MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JavaScriptSerializer_MVC4.Models
{ 
    
     
    public class Dog : Animal
    {
        public int DogID { get; set; }
         
        public DogBreed breed { get; set; }

    }



    public enum DogBreed
    {

        GermanShepherd,

        LabradorRetriever

    }

}