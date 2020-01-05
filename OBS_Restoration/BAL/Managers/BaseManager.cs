namespace BAL.Managers
{
    public class BaseManager
    {
        public long UserId { get; private set; }
        public string UserName { get; private set; }


        public BaseManager() { }

        public BaseManager(long userId, string userName)
        {
            SetUser(userId, userName);
        }

        public void SetUser(long userId, string userName)
        {
            this.UserId = userId;
            this.UserName = userName;
        }
    }
}
