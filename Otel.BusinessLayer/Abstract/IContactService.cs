using Otel.EntityLayer.Concrete;

namespace Otel.BusinessLayer.Abstract
{
    public interface IContactService : IGenericService<Contact>
    {
        List<Contact> TGetRepliedContactsCount();
        List<Contact> TGetUnRepliedContactCount();
    }
}
