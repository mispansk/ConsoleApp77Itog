using System;
using System.Drawing;

namespace ConsoleApp77Itog
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Basket basket = new Basket();
            var Order = basket.ConvertToOrder<HomeDelivery>();
            // ...
        }
    }
    #region  Перечисления

    /// <summary>
    /// Единицы изменения
    /// </summary>
    enum Unit
    {
        /// <summary>
        /// штука
        /// </summary>
        pieces,
        pair, // пара
        kilogram // килограмм
    }

    /// <summary>
    /// Размеры для одежды
    /// </summary>
    enum ClothesSizes
    {
        S,
        M,
        L,
        XL,

    }


    #endregion Перечисления

    #region Свойства товаров

    /// <summary>
    /// Характеристики базовый класс
    /// </summary>
    public abstract class Property
    {
        /// <summary>
        /// Название характеристики
        /// </summary>
        public string name;
    }

    /// <summary>
    /// Размеры геометрические
    /// </summary>
    public class DimensionsProp : Property
    {
        /// <summary>
        /// Длина
        /// </summary>
        public int Width;

        /// <summary>
        /// Высота
        /// </summary>
        public int Height;

        /// <summary>
        /// Глубина
        /// </summary>
        public int Depth;
    }

    /// <summary>
    /// цвет товара
    /// </summary>
    public class ColorProp : Property
    {
        public Color color;
    }

    /// <summary>
    /// Размер одежды
    /// </summary>
    /// <typeparam name="T">Размерность одежды (число,X,L)</typeparam>
    public class Size<T> : Property
    {
        public T size;
    }

    #endregion Свойства товаров

    /// <summary>
    /// Класс Товар
    /// </summary>
    class Product
    {
        /// <summary>
        /// наименование товара
        /// </summary>
        public string name;
        /// <summary>
        /// цена товара
        /// </summary>
        private double price;
        /// <summary>
        /// описание товара
        /// </summary>
        public string description;
        /// <summary>
        /// ед. измерения товара
        /// </summary>
        public Unit unit; 
        /// <summary>
        /// набор характеристик для товара
        /// </summary>
        public Property[] properties;
        /// <summary>
        /// свойство цены товара
        /// </summary>
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Цена товара должна быть больше нуля");
                }
                else
                {
                    price = value;
                }
            }
        }
    }

    /// <summary>
    /// строка табличной части заказа
    /// </summary>
    class ProductRow
    {
        public Product product;
        /// <summary>
        /// Количество товара
        /// </summary>
        public int quantity;
        /// <summary>
        /// расчет стоимости товара (цена*количество)
        /// </summary>
        public double Sum { get { return product.Price * quantity; } }
    }

    /// <summary>
    /// корзина 
    /// </summary>
    class Basket
    {
        public ProductRow[] productRows;
        public Customer Customer;

        /// <summary>
        /// создание заказа из корзины
        /// </summary>
        /// <typeparam name="T"> тип доставки </typeparam>
        /// <returns> сформированный заказ </returns>
        internal Order<T> ConvertToOrder<T>() where T : Delivery
        {
            return new Order<T>();

        }
    }
    /// <summary>
    /// клиент (имя, телефон)
    /// </summary>
    class Customer
    {
        public string name;
        public string phone;
    }

    /// <summary>
    /// заказ
    /// </summary>
    /// <typeparam name="TDelivery"></typeparam>
    class Order<TDelivery> where TDelivery : Delivery
    {
        public TDelivery Delivery;
        public int Number;
        public string Description;
        public ProductRow[] productRows;

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }
    }
    /// <summary>
    /// доставка
    /// </summary>
    abstract class Delivery
    {
        public string Address;
    }
    /// <summary>
    /// доставка на дом
    /// </summary>
    class HomeDelivery : Delivery
    {
        
    }
    /// <summary>
    /// доставка в пункт выдачи
    /// </summary>
    class PickPointDelivery : Delivery
    {
        
    }
    /// <summary>
    /// доставка в магазин
    /// </summary>
    class ShopDelivery : Delivery
    {
        
    }
}
