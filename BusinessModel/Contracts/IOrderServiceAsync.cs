using BusinessModel.Models;

namespace BusinessModel.Contracts
{
    public interface IOrderServiceAsync
    {
        Task<Order?> CurrentOrder(string userName);
        Task<bool> FinishOrder(string userName);
        Task<int> UpdateOrder(string userName, Recipe? recipe, int quantity);
    }
}