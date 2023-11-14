namespace SalesForce.Models
{
    public class ContactData
    {
        public ContactData(Contact contact, Account account)
        {
            Contact = contact;
            Account = account;
        }

        public Contact Contact { get; private set; }
        public Account Account { get; private set; }
    }
}
