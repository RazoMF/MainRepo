using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.WebUI.Models
{
    public class CartIndexVModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}