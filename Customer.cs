using System.Buffers;
using System.Text;

namespace WebShop6;

public record Customer(string Username, Cart cart) : IUser; 
