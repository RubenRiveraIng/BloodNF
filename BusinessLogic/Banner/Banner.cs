using DAO;
using DAO.BannerOp;

namespace BusinessLogic.Banner
{
    public class Banner
    {
        private IBannerOperations  _operations;
        public Banner(bloodbog_bdEntities context)
        {
            this._operations = new BannerOperations(context);
        }

        public dynamic getBanner()
        {
            return _operations.getBanner();
        }

        
        

    }
}
