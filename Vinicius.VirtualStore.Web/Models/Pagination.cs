using System;

namespace Vinicius.VirtualStore.Web.Models
{
    public class Pagination
    {
        public int TotalItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int PagesTotal
        {
            get { return (int) Math.Ceiling((decimal)
                TotalItems/ItemsPerPage);
            }
            
        }
    }
}