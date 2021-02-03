using System;

namespace Simple_Strategy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webApplication = new WebApplication(LoginType.Email);
            webApplication.SendAsyncRequestToServer("test");
        }
    }

    public interface IAsyncRequestStrategy
    {
       public AsyncResponse SendRequest(String url);
    }

    public class AsyncResponse
    {
        public object Response { get; set; }
    }

    // Login Using Email
    public class LoginUsingEmail : IAsyncRequestStrategy
    {
        public AsyncResponse SendRequest(String url)
        {
            var asyncResponse = new AsyncResponse();
            Console.WriteLine("Sent login request using email");
            return asyncResponse;
        }
    }

    // Login Using Phone
    public class LoginUsingPhone : IAsyncRequestStrategy
    {
       public AsyncResponse SendRequest(String url)
        {
            var asyncResponse = new AsyncResponse();
            Console.WriteLine("Sent login request using phone");
            return asyncResponse;
        }
    }

    // Login Using Social Media
    public class LoginUsingSocialMedia : IAsyncRequestStrategy
    {
        public AsyncResponse SendRequest(String url)
        {
            var asyncResponse = new AsyncResponse();
            Console.WriteLine("Sent login request using social media account");
            return asyncResponse;
        }
    }

    public enum LoginType
    {
        Email = 1,
        Phone = 2,
        SocialMediaAccount = 3
    }

    public class WebApplication
    {
        private LoginType _loginType;

        public WebApplication(LoginType loginType)
        {
            _loginType = loginType;
        }

        public AsyncResponse SendAsyncRequestToServer(string url)
        {
            IAsyncRequestStrategy asyncRequestStrategy;
            AsyncResponse asyncResponse = null;
            switch (_loginType)
            {
                case LoginType.Email:
                      asyncRequestStrategy = new LoginUsingEmail();
                      return asyncRequestStrategy.SendRequest(url);

                case LoginType.Phone:
                      asyncRequestStrategy = new LoginUsingPhone();
                       return asyncRequestStrategy.SendRequest(url);
                case LoginType.SocialMediaAccount:
                    asyncRequestStrategy = new LoginUsingSocialMedia();
                    return asyncRequestStrategy.SendRequest(url);
            }

            return asyncResponse;
        }
    }
}
