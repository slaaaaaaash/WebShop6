using System.Buffers;
using System.Text;

namespace WebShop6;

public record Customer(string Username, List<Product> Cart) : IUser;