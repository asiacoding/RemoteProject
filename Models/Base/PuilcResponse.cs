using Models.Base;
using Models.Standard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Base
{

    public class PublicResponse<TObject>
    {
        public bool Status { set; get; }
        public TObject Data { set; get; }
        public string Message { set; get; }
    }


}

public static class ExDynmicMethod
{

    public static PublicResponse<Target> SuccessRespone<Target>(Target Data, string Msg = "ok") 
    {
        return new PublicResponse<Target>() { Data = Data, Status = true, Message = Msg };
    }

    public static PublicResponse<Target> SafeMerhod<Target>(
        Action MainAction, 
        Action ErrorAction )
    {
        try
        {
            if (MainSqlite.DataBase == null)
            {

                if (ErrorAction != null)
                {
                    ErrorAction();
                }

                return ExError.BadRespone<Target>();
            }

            MainAction();
            return new PublicResponse<Target>() { Status =true, Message = "ok", };
        }
        catch (Exception ex)
        {
            
            if (ErrorAction != null)
            {
                ErrorAction();
            }

            return ExError.BadRespone<Target>(ex.Message);
        }
    }
}

public static class ExError
{
    public static PublicResponse<ErrorType> BadRespone<ErrorType>(string ErrorString = "Failed to get the databases")
    {
        return new PublicResponse<ErrorType>() { Status = false, Message = ErrorString, };
    }
}
