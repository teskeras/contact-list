using System.Collections.Generic;

namespace ContactList.Data
{
    class ContactIdComparer : IEqualityComparer<Contact>
    {
        #region IEqualityComparer<Contact> Members

        public bool Equals(Contact x, Contact y)
        {
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode(Contact obj)
        {
            return obj.Id.GetHashCode();
        }

        #endregion
    }
}
