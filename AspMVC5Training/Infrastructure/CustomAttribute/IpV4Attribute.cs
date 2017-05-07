using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;

namespace AspMVC5Training.Infrastructure.CustomAttribute
{
    public class IpV4Attribute : ValidationAttribute, IClientValidatable
    {
        public IpV4Attribute()
        {

        }

        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            IPAddress inputValue;
            if (IPAddress.TryParse(value?.ToString() ?? string.Empty , out inputValue) &&
                inputValue.AddressFamily == AddressFamily.InterNetwork)
            {
                return ValidationResult.Success;
            }

            //return new ValidationResult(
            //           FormatErrorMessage(validationContext.DisplayName)
            //       );
            return new ValidationResult("這不是IpV4啦");
            
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata,
            ControllerContext context)
        {
            var rule = new ModelClientValidationRule();

            //低調用戶端驗證規則中的驗證型別名稱必須只能包含小寫字母。無效名稱: "notGreaterThanToday"，
            //用戶端規則型別: System.Web.Mvc.ModelClientValidationRule
            rule.ValidationType = "ipvfour";

            // 前端顯示 :欄位 IpV4不是IpV4格式 無效。
            //rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName() + "不是IpV4格式");

            // 前端顯示 : 欄位 IpV4格式錯誤 無效。
            //rule.ErrorMessage = FormatErrorMessage("IpV4格式錯誤");

            // 前端顯示 : IpV4格式錯誤
            //rule.ErrorMessage = "IpV4格式錯誤";

            yield return rule;
        }
    }
}