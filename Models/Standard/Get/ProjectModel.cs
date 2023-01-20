using Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.Standard.Get
{
    public class ProjectModel<T>
    {

        //

        public static PublicResponse<List<RemoteProjectModels>> GetALI()
        {

            /////----------------------------

            //
            // Old Code "not my job" or Bad Code 
            //

            //try
            //{
            //    if (MainSqlite.DataBase == null)
            //    {
            //        return ExError.BadRespone<List<RemoteProjectModels>>();
            //    }
            //    var Objectsc = MainSqlite.DataBase.Table<RemoteProjectModels>().ToList(); ;
            //    return new PublicResponse<List<RemoteProjectModels>>() { Data = Objectsc, Status = true, Message = "ok" };
            //}
            //catch (Exception ex)
            //{
            //    return ExError.BadRespone<List<RemoteProjectModels>>(ex.Message);
            //}



            /////----------------------------

            //
            // New Code is Professional coding
            //

            List<RemoteProjectModels> Data = new List<RemoteProjectModels>();

            //This method is recommended
            PublicResponse<List<RemoteProjectModels>> safeing = ExDynmicMethod.SafeMerhod<List<RemoteProjectModels>>(delegate
            {

                //Add Here Main
                Data = MainSqlite.DataBase.Table<RemoteProjectModels>().ToList();

            }, null /*Do Error Code*/ );
            return !safeing.Status ? safeing  /* Set error Method */ : ExDynmicMethod.SuccessRespone(Data) /*  Original Data  */ ;
        }



        public static PublicResponse<List<RemoteProjectModels>> GetByProject(string Guid)
        {
            //--------------------------------------------------------------------------------------------------------------------------------------------
            //
            // Old Code "not my job" or Bad Code 
            //
            // try
            // {
            //     if (MainSqlite.DataBase == null)
            //     {
            //         return ExError.BadRespone<List<RemoteProjectModels>>();
            //     }
            //     var Data = 
            //     return new PublicResponse<List<RemoteProjectModels>>() { Data = Data, Message = " ok", Status = true };
            // }
            // catch (Exception ex)
            // {
            //     return ExError.BadRespone<List<RemoteProjectModels>>(ex.Message);
            // }
            //
            //--------------------------------------------------------------------------------------------------------------------------------------------
            //
            // New Code is Professional coding
            //

            List<RemoteProjectModels> Data = new List<RemoteProjectModels>();
            PublicResponse<List<RemoteProjectModels>> safeing = ExDynmicMethod.SafeMerhod<List<RemoteProjectModels>>(delegate
            {

                //Add Here Main
                string NameClass = typeof(RemoteProjectModels).Name;
                Data = MainSqlite.DataBase.Query<RemoteProjectModels>($"select * from {NameClass} where Guid = @p0", Guid).ToList();

            }, null /*Do Error Code*/ );
            return !safeing.Status ? safeing  /* Set error Method */ : ExDynmicMethod.SuccessRespone(Data) /*  Original Data  */ ;
        }


        //public static PublicResponse<List<RemoteProjectModels>> GetByProject1(string Guid)
        //{
        //    try
        //    {
        //        if (MainSqlite.DataBase == null)
        //        {
        //            return ExError.BadRespone<List<RemoteProjectModels>>();
        //        }

        //        var Data = MainSqlite.DataBase.Query<RemoteProjectModels>("select * from RemoteProjectModels where Guid = @p0", //Guid).ToList();
        //        return new PublicResponse<List<RemoteProjectModels>>() { Data = Data, Message = " ok", Status = true };
        //    }
        //    catch (Exception ex)
        //    {
        //        return ExError.BadRespone<List<RemoteProjectModels>>(ex.Message);
        //    }

        //    List<RemoteProjectModels> Data = new List<RemoteProjectModels>();

        //    PublicResponse<List<RemoteProjectModels>> safeing =
        //        ExDynmicMethod.SafeMerhod<List<RemoteProjectModels>>(delegate
        //        {
        //            var NameClass = typeof(RemoteProjectModels).Name;
        //            Data = MainSqlite.DataBase.Query<RemoteProjectModels>($"select * from {NameClass} where Guid = @p0", Guid).ToList();
        //        },
        //        delegate
        //        {
        //            Do Error Code
        //        });

        //    if (!safeing.Status)
        //    {
        //        return safeing;
        //    }

        //    return !safeing.Status ? safeing : new PublicResponse<List<RemoteProjectModels>>() { Data = Data, Status = true, Message = "ok" };
        //}


        //public PublicResponse<RemoteButtonModels> SystemPad(string PadName)
        //{
        //    try
        //    {

        //        if (MainSqlite.DataBase == null)
        //        {
        //            return SetErorr<RemoteProjectModels>();
        //        }

        //        var NameTabel = typeof(RemoteButtonModels).Name;

        //        var MyKeyPad = MainSqlite.DataBase.Query<RemoteButtonModels>($"select * from {NameTabel} where Name = @p0", PadName).ToList();

        //        if ((MyKeyPad == null) || MyKeyPad.Count <= 0)
        //        {
        //            return null;
        //        }

        //        return MyKeyPad.FirstOrDefault();
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}


    }
}

