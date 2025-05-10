using skillhub.CommonLayer.Model.Users;

namespace skillhub.Interfaces.IServiceLayer
{
    public interface IWalletSL
    {
        public Task<bool> MakeWallet(WalletRequest request);
        public Task<bool> UpdateWallet(WalletRequest walletRequest);
        public Task<Wallet> FindWallet(int userId);

    }
}
