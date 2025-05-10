using skillhub.CommonLayer.Model.Users;

namespace skillhub.Interfaces.IRepositryLayer
{
    public interface IWalletRL
    {
        public Task<bool> MakeWallet(Wallet wallet);
        public Task<bool> UpdateWallet(Wallet wallet);
        public Task<Wallet> FindWallet(int userId);


    }
}
