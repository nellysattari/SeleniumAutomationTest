
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test.Runner
{
    public class Enums
    {
        public enum ContactUs_Subject
        {
            [Description("Expired Card")]
            optionExpiredCard,
            [Description("Card Not Working")]
            CardNotWorking,
            [Description("Lost or Stolen")]
            LostorStolen,
            [Description("Customer Feedback")]
            CustomerFeedback,
            [Description("Purchasing a Gift Card")]
            PurchasingaGiftCard,
            [Description("Other")]
            Other
        }

    }



    public static class EnumExtension
    {
        public static string GetDescription(this Enum enumItem)
        {
            Type type = enumItem.GetType();

            MemberInfo[] memInfo = type.GetMember(enumItem.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return enumItem.ToString();
        }
    }
}
