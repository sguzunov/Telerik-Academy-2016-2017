using Cosmetics.Engine;
using Cosmetics.Products;

namespace Cosmetics
{
    public class CosmeticsProgram
    {
        public static void Main()
        {
            var factory = new CosmeticsFactory();
            var shoppingCart = new ShoppingCart();
            var commandProvider = new ConsoleCommandProvider();
            var engine = new CosmeticsEngine(factory, shoppingCart, commandProvider);

            engine.Start();
        }
    }
}
