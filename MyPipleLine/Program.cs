using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace MyPipleLine
{
    class Program
    {
        public static List<Func<RequestDelegate, RequestDelegate>> _list = new List<Func<RequestDelegate, RequestDelegate>>();
        static void Main(string[] args)
        {
            Use(next =>
            {
                return context =>
                {
                    context.Write("1");
                    return next.Invoke(context);
                };
            });
            Use(next =>
            {
                return context =>
                {
                    context.Write("2");
                    return next.Invoke(context);
                };
            });
            _list.Reverse();
            RequestDelegate end = (context) =>
            {
                context.Write("end");
                return Task.CompletedTask;
            };
            foreach (var middleware in _list)
            {
                end = middleware.Invoke(end);
            }
            end.Invoke(new Context());
            Console.ReadLine();
        }

        public static void Use(Func<RequestDelegate, RequestDelegate> middleWare)
        {
            _list.Add(middleWare);
        }
    }
}
