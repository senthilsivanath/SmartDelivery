using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tesco.Com.Web.Core.Models
{
    public class Customer
    {
        /// <summary>
        /// 
        /// </summary>
        
        public string CustomerTitle	{get; set;}

        /// <summary>
        /// 
        /// </summary>
        
        public string CustomerSurname {get; set;}

        /// <summary>
        /// 
        /// </summary>
        
        public string Address {get; set;}

        /// <summary>
        /// 
        /// </summary>
        
        public string Postcode {get; set;}

        /// <summary>
        /// 
        /// </summary>
        
        public string PhoneDaytime {get; set;}

        /// <summary>
        /// 
        /// </summary>
        
        public string PhoneEvening {get; set;}

        /// <summary>
        /// 
        /// </summary>
        
        public string PhoneMobile {get; set;}

        /// <summary>
        /// 
        /// </summary>
        
        public string CustomerFullName {get; set;}

        /// <summary>
        /// 
        /// </summary>
        
        public int[] SignaturePoints {get; set;}

        /// <summary>
        /// 
        /// </summary>
        public CustomerCommunication customerCommunication { get; set; }	
    }
}