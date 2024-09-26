using Otel.EntityLayer.Concrete;

namespace Otel.DataAccessLayer.Abstract
{
    public interface IContactDal : IGenericDal<Contact>
    {
        List<Contact> GetRepliedContactsCount();
        List<Contact> GetUnRepliedContactCount();
    }
}
