using System.Linq;
namespace Infrastracture
{
	/// <summary>
	/// BaseController has:
	/// 1-MyDatabaseContext,
	/// 2-Dispose,
	/// 3-UnitOfWork,
	/// </summary>
	public class BaseController : System.Web.Mvc.Controller
    {
        public BaseController():base()
        {

        }


		/// <summary>
		/// Lazy Loading = Lazy Initialization
		/// Best Practic
		/// 
		/// </summary>
		private Models.DatabaseContext myDatabaseContext;
		protected Models.DatabaseContext MyDatabaseContext
		{
			get
			{
				if (myDatabaseContext == null)
				{
					myDatabaseContext =
						new Models.DatabaseContext();
				}

				return (myDatabaseContext);
			}
		}

		
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (myDatabaseContext != null)
				{
					myDatabaseContext.Dispose();
					myDatabaseContext = null;
					//MyDatabaseContext = null;مشکل فاجعه آمیز
				}
			}

			base.Dispose(disposing);
		}

		private DAL.UnitOfWork unitOfWork;

		public DAL.UnitOfWork UnitOfWork
		{
			get
			{
				if (unitOfWork==null)
				{
					unitOfWork = new DAL.UnitOfWork(MyDatabaseContext);
				}

				return (unitOfWork);
			}
		}

		//*********************************************************************************************
		protected override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
		{
			// کد ذیل برای آن است که اول بسم الله سایت به چه زبانی دیده شود
			if (Session["Culture"] == null)
			{
				Session["Culture"] = "en-US";
				//Session["Culture"] = "fa-IR";
			}

			// دقت کنید که دستورات ذیل، در داخل شرط فوق قرار ندارند
			System.Globalization.CultureInfo cultureInfo =
				new System.Globalization.CultureInfo(Session["Culture"].ToString());

			System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
			System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
		}
	}
}