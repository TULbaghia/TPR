namespace Zadanie3
{
    public class MyProduct : Product
    {
        public MyProduct(Product product)
        {
            foreach (var property in product.GetType().GetProperties())
            {
                if(property.CanWrite)
                {
                    property.SetValue(this, property.GetValue(product));
                }
            }
        }
    }
}
