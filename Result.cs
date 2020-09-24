using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.Crmf;
using Remotion.Linq.Parsing.ExpressionVisitors.MemberBindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Service
{
    public class Result<T>
    {
        public int Code = 1;
        public string msg = "";
        public T res = default(T);
        public static Result Ok(T result)
        {
            return new Result() { res = result };
        }
        public static Result Ok(string messgge,T Result=default(T))
        {
            return new Result() { msg = messgge, res = Result };
        }
        public static Result Err (string messgge)
        {
            return new Result() { Code = -1, msg = messgge };
        }
    }
    public class Result: Result<dynamic>
    {

    }
}
