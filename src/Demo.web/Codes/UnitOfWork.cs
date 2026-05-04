namespace Demo.web.Codes
{
    public class UnitOfWork
    {
        List<object> _tracker; // product,user,order

        public void insert(object o)
        {
            _tracker.Add(o);
        }
        public void update(object o)
        {
            _tracker[0] = o;
        }
        public void delete(object o)
        {
            _tracker.Remove(o);
        }
        public void save()
        {
            //transaction start

            //loop over tracker
            // do each type of oparation

            //close transaction
        }

    }
}
