using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationJAY.Models;
using WebApplicationJay2.Models;

namespace WebApplicationJay2.ViewModels
{
    public class ContactViewModel
    {
        public List<Share> MesShares { get; set; }
        public Utilisateur Utilisateur { get; set; }
    }
}