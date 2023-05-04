namespace AbstractFactory
{

    // It's creation pattern
    // The intent of the abstract factory pattern is to provide an interface for creating families of related or dependent objects 
    // without specifying their concrete classes
    // We need one factory per family

    // Use cases: When the system should be independent of how its products are created, composed and represented
    //            When you want to provide a class library of products and you only want to reveal their interfaces, not their implementations
    //            When a family of related  products objects i designed to be used together


    // Pros: Isolates concrete classes, clients are isolated of implementation class
    //-- new products can easily be introduced without breaking client code: open/closed principle
    // code to create products is contained in one place: single responsibility principle
    // it promotes consistency among products

    // Cons: Supporting new kinds of products is rather difficult


    ///<summary>
    /// AbstractFactory
    /// </summary>
    public interface IShoppingCartPurchaseFactory
    {
        IDiscountService CreateDiscountService();
        IShippingCostsService CreateShippingCoststService();
    }


    ///<summary>
    /// AbstractProduct
    /// </summary>
    public interface IDiscountService
    {
        int DiscountPercentage { get; }
    }

    ///<summary>
    /// ConcreteProduct
    /// </summary>
    public class BelgiumDiscountService : IDiscountService
    {
        public int DiscountPercentage => 20;
    }

    ///<summary>
    /// ConcreteProduct
    /// </summary>
    public class FranceDiscountService : IDiscountService
    {
        public int DiscountPercentage => 10;
    }

    ///<summary>
    /// AbstractProduct
    /// </summary>
    public interface IShippingCostsService
    {
        decimal ShippingCosts { get; }
    }

    ///<summary>
    /// ConcreteProduct
    /// </summary>
    public class BelgiumShippingCostsService : IShippingCostsService
    {
        public decimal ShippingCosts => 20;
    }

    ///<summary>
    /// ConcreteProduct
    /// </summary>
    public class FranceShipingCostsService : IShippingCostsService
    {
        public decimal ShippingCosts => 25;
    }

    ///<summary>
    /// ConcreteFactory
    /// </summary>
    public class BelgiumShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new BelgiumDiscountService();
        }

        public IShippingCostsService CreateShippingCoststService()
        {
            return new BelgiumShippingCostsService();
        }
    }

    ///<summary>
    /// ConcreteFactory
    /// </summary>
    public class FranceShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new FranceDiscountService();
        }

        public IShippingCostsService CreateShippingCoststService()
        {
            return new FranceShipingCostsService();
        }
    }

    ///<summary>
    /// ClientClass
    /// </summary>
    public class ShoppingCart
    {
        private readonly IDiscountService _discountService;
        private readonly IShippingCostsService _shippingCostsService;
        private int _orderCosts;

        public ShoppingCart(IShoppingCartPurchaseFactory factory)
        {
            _discountService = factory.CreateDiscountService();
            _shippingCostsService = factory.CreateShippingCoststService();
            _orderCosts = 200;
        }

        public void CalculateCosts()
        {
            Console.WriteLine($"Total costs = {_orderCosts - (_orderCosts / 100 * _discountService.DiscountPercentage) + _shippingCostsService.ShippingCosts}");
        }
    }
}
