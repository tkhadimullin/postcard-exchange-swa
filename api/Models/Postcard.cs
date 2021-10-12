using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models {
    public class Postcard {
        public int Id {get;set;}
        public User Sender {get;set;}
        public User Recipient {get;set;}

        [DataType(DataType.Date)]
        public DateTime Date {get;set;}

        public bool IsSent {get;set;}
        public bool IsReceived {get;set;}
    }
}