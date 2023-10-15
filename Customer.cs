using System.Buffers;
using System.Text;

namespace WebShop6;

public record Customer(string username, List<Product> cart) : IUser;