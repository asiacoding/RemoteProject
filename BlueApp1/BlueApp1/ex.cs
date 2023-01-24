using Plugin.LocalNotification;
using QRCoder;
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
namespace BlueApp
{
    //public delegate void ReportSearchClick(object sender, Webapi.ElementSearchReport element);


    public static partial class Extension
    {
        public static void DisplayErrorAlert(this Page This)
        {
            This.SendAlert("There was a problem, please try again");
        }

        public static Color ConvertToColor(this string FormatingColor)
        {
            return !string.IsNullOrEmpty(FormatingColor) ? Color.FromHex(FormatingColor) : Color.Transparent;
        }

        public static int GetSizeOfObject(object obj)
        {
            return obj is null ? 0 : Marshal.SizeOf(obj);
        }

        public static void InitException(this Exception exception, string E = "")
        //,bool InartSceen )

        {
            if (exception.InnerException != null)
            {
                //         exception.AddLogs(exception.InnerException.ToString(), InartSceen);
            }
            else
            {
                //       exception.AddLogs(exception.Message, InartSceen);
            }

            if (E is null)
            {
                throw new ArgumentNullException(nameof(E));
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

        public static ImageSource ConvertStringTOSQCOde(this string Data, QRCodeGenerator.ECCLevel ECCLevels,int GraphicSize = 20)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            QRCodeData qrCodeData = qrGenerator.CreateQrCode(Data, ECCLevels);
            PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeBytes = qRCode.GetGraphic(GraphicSize);
            return ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
        }

        public static bool PageIsBusy(this bool m, Page page = null)
        {
            if (page != null && m)
            {
                page.SendAlert
                    ("There is another process in progress");
            }

            return m;
        }

        /// <summary>
        ///  var query = people.DistinctBy(p => p.Id);
        /// </summary>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
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
            while (date.DayOfWeek != DayOfWeek.Friday)
            {
                date = date.AddDays(-1);
            }

            return new DateTime[] { date, date.AddDays(7) };
        }

        public static Page CurrentPage(this NavigableElement element)
        {
            IReadOnlyList<Page> MyList = element.Navigation.NavigationStack;
            return MyList.Count > 1 ? MyList[MyList.Count - 1] : MyList[0];
        }
        public static void CloesPage(this NavigableElement element, List<Type> PageTypes)
        {
            //PageTypes
            List<Page> MyPage = element.Navigation.NavigationStack.ToList();
            foreach (Page item in MyPage)
            {
                if (PageTypes.Contains(item.GetType()))
                {
                    element.Navigation.RemovePage(item);
                }
            }

            //            element.Navigation.NavigationStack. = MyPage;
        }

        public static List<DateTime> ListDateToDate(DateTime date, DateTime Max)
        {
            if (date > Max)
            {
                return new List<DateTime>();
            }
            List<DateTime> getdays = new List<DateTime>();
            while (date >= Max)
            {
                getdays.Add(date);
                _ = date.AddDays(1);
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
            AutoMapper.MapperConfiguration config = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
            AutoMapper.IMapper IMapperObj = config.CreateMapper();
            TDestination DestinationObject = IMapperObj.Map<TSource, TDestination>(Sorese);
            return DestinationObject;
        }

        public static string ReadFle(string HtmlFile = "Add Here 'Def Path' ")
        {
            try
            {
                Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(Extension)).Assembly;
                Stream stream = assembly.GetManifestResourceStream(HtmlFile);
                string text = "";
                using (StreamReader reader = new StreamReader(stream))
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





        public static void GOTO(this Page This, Page TO)
        {
            _ = This.Navigation.PushAsync(TO, false);
        }

        public static void Back(this Page This)
        {
            _ = This.Navigation.PopAsync(false);
        }

        public static void Back(this Page This, bool At = false)
        {
            _ = This.Navigation.PopAsync(At);
        }

        /// <summary>
        /// Back Page and Select More Pages 
        /// </summary>
        /// <param name="This"></param>
        /// <param name="Page"></param>
        public static void Back(this Page This, Type Page)
        {
            foreach (Page item in This.Navigation.ModalStack)
            {
                Type type = item.GetType();
                Type Cur = type;
                Type TargetPage = Page;
                if (Cur.FullName != TargetPage.FullName)
                {
                    break;
                }
                else
                {
                    This.Navigation.RemovePage(item);
                }
            }
            _ = This.Navigation.PopAsync(false);
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

        public static void SendAlert(this Page T, string M, bool ShowTital = false)
        {
            if (T is null)
            {
                return;
            }

            _ = T.DisplayAlert(ShowTital ? "system alert" : "", M, "back");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="T"></param>
        /// <param name="M"></param>
        /// <param name="Questions">need 2 string Arry index 0 = No , and index 1 = yes </param>
        /// <returns></returns>
        public static async Task<bool?> SendAlert(this Page T, string M, string[] Questions)
        {
            return Questions.Length == 2 ? await T.DisplayAlert("", M, Questions[1], Questions[0]) : (bool?)null;
        }


        public static string GetNumbers(this string value)
        {
            string v = new string(value.Where(a => char.IsDigit(a)).ToArray());
            return v;
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
            decimal Discount_ = Convert.ToDecimal(Discount);
            decimal Quantity_ = Quantity;
            decimal GetPriceAfterDiscount;
            if (Discount_ != 0)
            {
                decimal _DisCount = Discount_ / 100;
                GetPriceAfterDiscount = price * _DisCount;
            }
            else
            {
                GetPriceAfterDiscount = 0;
            }
            decimal All = (price - GetPriceAfterDiscount) * Quantity_;
            return All;
        }

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
            _ = LocalNotificationCenter.Current.Show(notification);
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
            ImageSource imageSource = ImageSource.FromResource(Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);
            return imageSource;
        }
    }

    public static class Paths
    {
        public static string PathDB_Base()
        {
            string applicationFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "API");
            _ = Directory.CreateDirectory(applicationFolderPath);
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
