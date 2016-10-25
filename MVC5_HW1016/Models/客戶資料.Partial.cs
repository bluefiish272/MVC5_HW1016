namespace MVC5_HW1016.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(客戶資料MetaData))]
    public partial class 客戶資料
    {
    }
    
    public partial class 客戶資料MetaData
    {
        [Required]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage= "{0}不得大於{1}個字元")]
        [Required]
        public string 客戶名稱 { get; set; }
        
        [Required]
        [RegularExpression(@"\d{8}", ErrorMessage = "請輸入8位數字")]
        public string 統一編號 { get; set; }
        
        [StringLength(50, ErrorMessage= "{0}不得大於{1}個字元")]
        [Required]
        public string 電話 { get; set; }
        
        [StringLength(50, ErrorMessage= "{0}不得大於{1}個字元")]
        [Required]
        public string 傳真 { get; set; }

        [StringLength(100, ErrorMessage= "{0}不得大於{1}個字元")]
        public string 地址 { get; set; }
        
        [StringLength(250, ErrorMessage= "{0}不得大於{1}個字元")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public bool 是否已刪除 { get; set; }

        public virtual ICollection<客戶銀行資訊> 客戶銀行資訊 { get; set; }
        public virtual ICollection<客戶聯絡人> 客戶聯絡人 { get; set; }
    }
}
