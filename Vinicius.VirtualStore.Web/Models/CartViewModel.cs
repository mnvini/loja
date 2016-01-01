using Vinicius.VirtualStore.Domain.Entities;

namespace Vinicius.VirtualStore.Web.Models
{
    public class CartViewModel
    {
        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }
    }
}