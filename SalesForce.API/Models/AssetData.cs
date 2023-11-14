namespace SalesForce.Models
{
    public class AssetData
    {
        public AssetData(Asset asset, Account account, Contact contact, Product2 product)
        {
            //Preconditions.CheckNull(asset, nameof(asset));
            //Preconditions.CheckNull(product, nameof(product));

            Asset = asset;
            Account = account;
            Contact = contact;
            ProductDetails = product;
        }

        public Asset Asset { get; set; }
        public Account Account { get; set; }
        public Contact Contact { get; set; }
        public Product2 ProductDetails { get; set; }
    }
}