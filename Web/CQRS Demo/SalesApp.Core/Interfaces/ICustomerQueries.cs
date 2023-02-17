using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PagedList;
using SalesApp.Core.Models;

namespace SalesApp.Core.Interfaces
{
    public interface ICustomerQueries
    {
        // �Ǧ^���w ID ���Ȥ���
        Task<Customer> GetCustomerByIdAsync(int customerId);

        // ���䴩�����B�ƧǡB�z��A�ѹ�@�������� Query ������o�������Ȥ��ƨê����ন�}�C�C
        Task<Customer[]> GetCustomersAsync();   

        // �䴩�����B�ƧǡB�z��]�I�s�ݥi�� PredicateBuilder �إ߿z���ܦ��^
        Task<IPagedList<Customer>> GetCustomersAsync(int page, int pageSize, string sortOrder, Expression<Func<Customer, bool>> filterExpr);

        // �u�Ǧ^ IQueryable<T>�A�ηN�O�� Query ����u���ѳ̶��K�� LINQ �d�ߡA
        // �Ө�l���z��B�ƧǡB�������B�z�����ѩI�s�ݨӭt�d�C����k�P GetCustomersAsync ���D�n�t���Y�b��
        IQueryable<Customer> GetCustomersQuery();
    }
}