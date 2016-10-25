using MVC5_HW1016.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC5_HW1016.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人
    { }
    /*:IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.客戶Id == 客戶Id && this.Email == Email)
            {
                yield return new ValidationResult("同一客戶內不得有重複的EMAIL", new string[] { "客戶Id", "Email" });
            }
            yield break;
        }
    }*/
}


    
    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("客戶名稱")]
        public int 客戶Id { get; set; }
        
        [StringLength(50, ErrorMessage= "{0}不得大於{1}個字元")]
        [Required]
        public string 職稱 { get; set; }
        
        [StringLength(50, ErrorMessage= "{0}不得大於{1}個字元")]
        [Required]
        public string 姓名 { get; set; }
        
        [StringLength(250, ErrorMessage= "{0}不得大於{1}個字元")]
        [Required]
        public string Email { get; set; }
        
        [StringLength(50, ErrorMessage= "{0}不得大於{1}個字元")]
        [RegularExpression(@"\d{4}-\d{6}",ErrorMessage ="{0}格式需為09xx-xxxx")]
        public string 手機 { get; set; }
        
        [StringLength(50, ErrorMessage= "{0}不得大於{1}個字元")]
        public string 電話 { get; set; }

        public bool 是否已刪除 { get; set; }
        public virtual 客戶資料 客戶資料 { get; set; }
    }
