using Microsoft.AspNetCore.Mvc;

namespace BanDoMba.Helper
{
    public class CommonString
    {
        public static string ApiUrl = "";
    }

    public abstract class BaseRepository : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public readonly string _MbaConnection;
        //public readonly string _apiUrl;
        //public readonly RedisEndpoint _redisEndpoint;
        //public RedisHelper _redisHelper;

        protected BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _MbaConnection = _configuration["ConnectionStrings:Mba"];
            //_apiUrl = _configuration["ConnectionStrings:apiUrl"];

            var urlRedis = _configuration.GetValue<string>("ConnectionStrings:Redis");
            var redisEndPointEvn = Environment.GetEnvironmentVariable("RedisEndPoint");

            //if (!string.IsNullOrEmpty(redisEndPointEvn))
            //    _redisEndpoint = new RedisEndpoint(redisEndPointEvn, 6379);
            //else _redisEndpoint = new RedisEndpoint(urlRedis, 6379);

            //_redisHelper = new RedisHelper(_redisEndpoint);
        }

        protected void WriteLog(string content)
        {
            try
            {
                //var m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppDomain.CurrentDomain.RelativeSearchPath ?? "");
                using (StreamWriter w = System.IO.File.AppendText(path + "\\" + "log.txt"))
                {
                    w.Write("\r\nLog Entry : ");
                    w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                        DateTime.Now.ToLongDateString());
                    w.WriteLine("  :{0}", content);
                    w.WriteLine("-------------------------------");
                }
            }
            catch (Exception except)
            {
                Console.WriteLine(except.Message);
            }
        }
    }
}
