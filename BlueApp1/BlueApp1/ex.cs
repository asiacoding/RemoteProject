using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace BlueApp1

{
    //public delegate void ReportSearchClick(object sender, Webapi.ElementSearchReport element);
   

    public static partial class Extension
    {

        public static class StantderValue
        {
            //CRM.WebView.Layer.TempletPage.Report.CanStartReport.html
            public const string CanStartRrpoetAboutFile = "CRM.WebView.Layer.TempletPage.Report.CanStartReport.html";
        }

        public static Color ConvertToColor(this string FormatingColor)
        {
            if (!string.IsNullOrEmpty(FormatingColor))
            {
                return Color.FromHex(FormatingColor);
            }
            else
            {
                return Color.Transparent;
            }
        }

        public static int GetSizeOfObject(object obj) => Marshal.SizeOf(obj);


        //public static void getIamgeFromWebSite(this ImageButton Image, string PathImage)
        //{
        //    Image.Source = Api.Api.ApiLinkHost + PathImage;
        //}

        //public static void getIamgeFromWebSite(this Image Image, string PathImage)
        //{
        //    Image.Source = Api.Api.ApiLinkHost + PathImage;
        //}

        public static void InitException(this Exception exception, string E = "", bool InartSceen = true)
        {
            if (exception.InnerException != null)
            {
       //         exception.AddLogs(exception.InnerException.ToString(), InartSceen);
            }
            else
            {
         //       exception.AddLogs(exception.Message, InartSceen);
            }
        }


        public static ImageSource ConvertStringBase64ToImageSource(string StringBase64)
        {
            return ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(StringBase64)));
            //TargetImage.Source = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(Image)));
        }

        //public static ImageSource ConvertStringBase64ToImageSource(string StringBase64)
        //{
        //    return ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(StringBase64)));
        //}

        public const string CountryCurrencyType = " EG";

        //public static Ret Controls<Ret>(this Element Targe, string Name = null)
        //{
        //    return NameScopeExtensions.FindByName<Ret>(Targe, Name);
        //}

        //public static class Query
        //{
        //    public static string GetOldInv => $"select * From {typeof(DbWebApi.sqllite.Receipt).Name} " +
        //        $" where UserID = {Extension.User.id} and " +
        //        $" BranchID = {Extension.User.BranchID} and " +
        //        $" SpaceID = {Extension.User.SpaceID} and " +
        //        $" Type = $ChangeType " +
        //        $" --MC ;";

        //    public static string MyClinets => $"select * From {typeof(DbWebApi.sqllite.Client).Name} " +
        //        $" where SpaceID = {Extension.User.SpaceID} " +
        //        $" --MC ;";
        //    public static string MyArea => $"select * From {typeof(DbWebApi.sqllite.Area).Name} " +
        //        $" where SpaceID = {Extension.User.SpaceID} " +
        //        $" --MC ;";
        //    /// <summary>
        //    /// Plases Repl '$ID' To Any Clients IDs (Need Number) | ty ;)
        //    /// </summary>
        //    public static string GetClinets => $"SELECT * FROM {typeof(DbWebApi.sqllite.Client).Name} " +
        //        $" where ClientID = $ID " +
        //        $" LIMIT 1 " +
        //        $" --MC";

        //    public static string MyListManagersVisit => $"SELECT * FROM {typeof(DbWebApi.sqllite.ManagersVisit).Name} " +
        //        $" where UserID = {Extension.User.id} and " +
        //        $" Branch = {Extension.User.BranchID} " +
        //        $" --MC ";
        //    public static string Client => $"select * FROM {typeof(DbWebApi.sqllite.Client).Name} " +
        //        " --MC";//select * from Client
        //    public static string GetItemsReceipt => $"SELECT * FROM {typeof(DbWebApi.sqllite.ItemsBill).Name} " +
        //        $" --MC ";
        //    public static string Area => $"SELECT * FROM {typeof(DbWebApi.sqllite.Area).Name}  " +
        //        $" --MC ;"; // $clinetID $areaID $spID
        //    public static string Users => $"select * FROM {typeof(DbWebApi.sqllite.Users_Company).Name} " +
        //        $" --MC";
        //    public static string GetUserRoles => $"select *FROM {typeof(DbWebApi.sqllite.UserRole).Name} " +
        //        $" --MC";
        //    public static string GetBranch => $"select * FROM {typeof(DbWebApi.sqllite.Branch).Name} " +
        //        $" --MC ";
        //    public static string GetReceipt => $"select * FROM {typeof(DbWebApi.sqllite.Receipt).Name} " +
        //        $" --MC ";
        //    public static string ItemsDetails => $"select * FROM {typeof(DbWebApi.sqllite.ItemsDetail).Name} " +
        //        $" --MC  ";
        //    public static string GetTbSupplier => $"select * FROM {typeof(DbWebApi.sqllite.Supplier).Name}  " +
        //        $" --MC  ";
        //}

        //public static string AddLogs(this object page, string Massgeing = "", bool Show = false,
        //    [CallerLineNumber] int lineNumber = 0,
        //    [CallerMemberName] string caller = null, bool SeeScreen = true)
        //{
        //    Type type = page.GetType();
        //    var Bug = new DbWebApi.sqllite.BugTracking()
        //    {
        //        TypeErorr = type.FullName,
        //        DateTime = DateTime.Now,
        //        ErrorCount = 1,
        //        Filename = caller,
        //        Text = Massgeing.Replace("'", ""),
        //        Line = lineNumber,
        //    };

        //    if (page is Exception Exs)
        //    {
        //        if (Exs.InnerException != null)
        //        {
        //            Bug.Text = Exs.InnerException.ToString().Replace("'", "");
        //        }
        //        else Bug.Text = Exs.Message.Replace("'", "");
        //    }

        //    if (SeeScreen)
        //    {
        //        if (Device.RuntimePlatform == Device.iOS)
        //        {
        //            // Add here Code Ios
        //            Bug.ScreenErorr = ReadFle("CRM.Models.HrmlFile.Logo_Apple.txt");
        //        }
        //        else if (Device.RuntimePlatform == Device.Android)
        //        {
        //            var screenshotData = DependencyService.Get<ISettingAndroid>().Capture();
        //            if (screenshotData.Length > 0)
        //            {
        //                Bug.ScreenErorr = Convert.ToBase64String(screenshotData);
        //            }
        //            else
        //            {
        //                Bug.ScreenErorr = CRM.WebView.Layer.ExtensionsClass.ReadFle("CRM.WebView.Layer.StandardFile.otherimage.noImage.txt");
        //            }
        //        }
        //    }




        //    DbWebApi.sqllite.BugTracking.SaveLog(Bug);

        //    if (Show && page is Xamarin.Forms.Page Taget)
        //    {
        //        Taget.SandAlert(Bug.Text);
        //    }


        //    return (Show) ? Massgeing : "";
        //}

        //public static DbWebApi.sqllite.Client GetClinet(int ID)
        //{
        //    var MyQ = Query.Client.Replace("--MC", $"where ClientID = {ID} LIMIT 1; --MC");
        //    var Clinetelm = SQLiteConnection.Query<DbWebApi.sqllite.Client>(MyQ).FirstOrDefault();

        //    if (Clinetelm != null)
        //    {
        //        return Clinetelm;
        //    }

        //    return null;
        //}

        public static bool PageIsBusy(this bool m, Xamarin.Forms.Page page = null)
        {
            if (page != null && m)
                page.SendAlert
                    ("There is another process in progress");

            return m;
        }

        /// <summary>
        ///  var query = people.DistinctBy(p => p.Id);
        /// </summary>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static DateTime[] GetWeek(DateTime date)
        {
            while (date.DayOfWeek != DayOfWeek.Friday) date = date.AddDays(-1);
            return new DateTime[] { date, date.AddDays(7) };
        }

        public static List<DateTime> ListDateToDate(DateTime date, DateTime Max)
        {
            if (date > Max)
            {
                return new List<DateTime>();
            }
            var getdays = new List<DateTime>();
            while (date >= Max)
            {
                getdays.Add(date);
                date.AddDays(1);
            }
            return getdays;
        }

        //public static ReturnObject ReadControlFromXml<ReturnObject>(this Xamarin.Forms.Page This, string Name)
        //{
        //    return global::Xamarin.Forms.NameScopeExtensions.FindByName<ReturnObject>(This, Name);
        //}
        public static string GetDefPathHtmlFileRes(string File)
        {
            return File;
        }

        public static TDestination MappersConverter<TSource, TDestination>(TSource Sorese)
        {
            //Crated Mapper profile
            var config = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
            var IMapperObj = config.CreateMapper();
            var DestinationObject = IMapperObj.Map<TSource, TDestination>(Sorese);
            return DestinationObject;
        }

        public static string ReadFle(string HtmlFile = "CRM.MiniApp.HtmlStyle.InvResult.html")
        {
            try
            {
                Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(Extension)).Assembly;
                Stream stream = assembly.GetManifestResourceStream(HtmlFile);
                string text = "";
                using (var reader = new System.IO.StreamReader(stream))
                {
                    text = reader.ReadToEnd();
                }
                //CRM.Models.HrmlFile.Logo.txt
                //using (StreamReader reader = new System.IO.StreamReader(assembly.GetManifestResourceStream("CRM.Models.HrmlFile.Logo.txt")))
                //{
                //    text = text.Replace("<!--ImageLogo-->", $"{reader.ReadToEnd()}")
                //        .Replace("@Footer", "");
                //}
              //  ICreatedDBSqlite DbKey = Xamarin.Forms.DependencyService.Get<ICreatedDBSqlite>();
                return text;
            }
            catch (Exception ex)
            {
                ex.InitException();
                return "";
            }

        }

    


       
        public static void GOTO(this Xamarin.Forms.Page This, Xamarin.Forms.Page TO)
        {
            This.Navigation.PushAsync(TO, false);
        }

        public static void Back(this Xamarin.Forms.Page This)
        {
            This.Navigation.PopAsync(false);
        }

        public static void Back(this Xamarin.Forms.Page This, bool At = false)
        {
            This.Navigation.PopAsync(At);
        }

        /// <summary>
        /// Back Page and Select More Pages 
        /// </summary>
        /// <param name="This"></param>
        /// <param name="Page"></param>
        public static void Back(this Xamarin.Forms.Page This, Type Page)
        {
            Xamarin.Forms.Page Opened = This;
            foreach (var item in This.Navigation.ModalStack)
            {
                Type type = item.GetType();
                var Cur = type;
                Type TargetPage = Page;
                if (Cur.FullName != TargetPage.FullName)
                {
                    Opened = item;
                    break;
                }
                else
                {
                    This.Navigation.RemovePage(item);
                }
            }
            This.Navigation.PopAsync(false);
        }

  


     
        //public static string GetMonth(int _month)
        //{
        //    string[] Mon = {
        //        "" ,
        //        "January",//
        //        "February",//  
        //        "March", //
        //        "April",//
        //        "May",//May
        //        "June",// June
        //        "July", // July 
        //        "August", //  August
        //        "September", // September
        //        "october", // october
        //        "November", // November
        //        "December" // December
        //    };

        //    return Mon[_month];
        //}

        //public static string GetMonthArb(int _month)
        //{
        //    string[] Mon = {
        //        "" ,
        //        "يناير",
        //        "فبراير",
        //        "مارس",
        //        "ابريل",
        //        "مايو",
        //        "يونيو",
        //        "يوليو",
        //        "اغسطس",
        //        "سبتمبر",
        //        "اكتوبر",
        //        "نوفمبر",
        //        "ديسمبر"
        //    };

        //    return Mon[_month];
        //}

        public static void SendAlert(this Xamarin.Forms.Page T, string M)
        {
            T.DisplayAlert("system alert", M, "back");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="T"></param>
        /// <param name="M"></param>
        /// <param name="Questions">need 2 string Arry index 0 = No , and index 1 = yes </param>
        /// <returns></returns>
        public static async Task<bool?> SendAlert(this Xamarin.Forms.Page T, string M, string[] Questions)
        {
            if (Questions.Length == 2)
            {
                return await T.DisplayAlert("system alert", M, Questions[1], Questions[0]);
            }
            else
            {
                return null;
            }
        }


        public static string GetNumbers(this string value)
        {
            return new string(value.Where(a => char.IsDigit(a)).ToArray());
        }

        public static string ConvertFileToString(string Files)
        {
            return Convert.ToBase64String(File.ReadAllBytes(Files)); //
        }

        public static void ConvertStringToFile(string Files, string BaseCode)
        {
            File.WriteAllBytes(Files, Convert.FromBase64String(BaseCode));
        }

        public static decimal GetPriceAfterDisconuts(decimal Price, int Discount, decimal Quantity)
        {
            decimal price = Price;
            decimal Discount_ = (Convert.ToDecimal(Discount));
            decimal Quantity_ = (Quantity);
            decimal GetPriceAfterDiscount;
            if (Discount_ != 0)
            {
                var _DisCount = (Discount_ / 100);
                GetPriceAfterDiscount = price * _DisCount;
            }
            else
            {
                GetPriceAfterDiscount = 0;
            }
            decimal All = (price - GetPriceAfterDiscount) * Quantity_;
            return All;
        }

        //public static bool GetRoles(CRM.Enum.TransTypeRolse roles)
        //{
        //    try
        //    {
        //        int ID = (int)roles;
        //        DbWebApi.Users_Company User = Extension.User;

        //        DbWebApi.sqllite.UserRole Role = SQLiteConnection.Query<DbWebApi.sqllite.UserRole>(Query.GetUserRoles.Replace("--MC",

        //            $" where UserID = {User.id} and " +
        //            $"BranchID = {User.BranchID} and " +
        //            $"IsEnabled = 1 and " +
        //            $"RolesID = {ID} ")

        //            ).ToList().LastOrDefault();

        //        if (Role == null)
        //            return false;

        //        return Role.IsEnabled;
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.InitException();
        //        return false;
        //    }
        //}
        public static void SeeNotification(string Description, string Title, int BadgeNumber, string ReturningData, int NotificationId)
        {
            NotificationRequest notification = new NotificationRequest
            {
                BadgeNumber = BadgeNumber,
                Description = Description,
                Title = Title,
                ReturningData = ReturningData,
                NotificationId = NotificationId,
            };
            LocalNotificationCenter.Current.Show(notification);
        }


   


    }

    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }
            // Do your translation lookup here, using whatever method you require
            var imageSource = ImageSource.FromResource(Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);
            return imageSource;
        }
    }

    public static class Paths
    {
        public static string PathDB_Base()
        {
            string applicationFolderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "API");
            _ = System.IO.Directory.CreateDirectory(applicationFolderPath);
            string databaseFileName = Path.Combine(applicationFolderPath, "Base2.System");
            return databaseFileName;
        }
    }

    public static class StringCipher
    {
        #region Need It ..

        /// <summary>
        /// Normal Txt to > Encrypt
        /// </summary>
        public static string Encrypt(string clearText)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes("abc123", new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }

            }

            return clearText;
        }
        /// <summary>
        ///  Encrypt to > Normal Txt
        /// </summary>
        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "abc123";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        #endregion

    }


}
