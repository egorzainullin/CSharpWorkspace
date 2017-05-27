namespace UniqueListing
{
    public class UniqueList : List
    {
        public override void Add(int value)
        {
            if (IsContaining(value))
            {
                throw new AlreadyInListException();
            }
            base.Add(value);
        }

        public override void Remove(int value)
        {
            if (!IsContaining(value))
            {
                throw new IsNotContainingInListException();
            }
            base.Remove(value);
        }
    }
}
