using skillhub.CommonLayer.Model.Users;
using skillhub.Interfaces.IRepositryLayer;
using skillhub.Interfaces.IServiceLayer;

namespace skillhub.ServiceLayer
{
    public class WalletSL : IWalletSL
    {
        public readonly IWalletRL walletInterface;
        public WalletSL(IWalletRL walletInterface)
        {
            this.walletInterface = walletInterface;
        }

        public Task<Wallet> FindWallet(int userId)
        {
            return walletInterface.FindWallet(userId);
        }

        public Task<bool> MakeWallet(WalletRequest request)
        {
            Wallet wallet = new Wallet(request.userID);
            return walletInterface.MakeWallet(wallet);
        }

        public async Task<bool> UpdateWallet(WalletRequest walletRequest)
        {
            Wallet wallet =await FindWallet(walletRequest.userID);
            return await walletInterface.UpdateWallet(wallet);
        }
    }
}
