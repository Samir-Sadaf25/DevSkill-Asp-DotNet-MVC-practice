namespace Demo.web.Codes
{
    public class UnitOfWork
    {
        //List<object> _tracker; // products,users,orders

        public Repository<Product> Products { get; set; }
        //public Repository<Order> orders { get; set; }

       
        public void save()
        {
            //transaction start

            //loop over tracker
            // do each type of oparation

            //close transaction
        }

    }
}
